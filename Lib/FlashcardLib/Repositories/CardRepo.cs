using CommandApp.Exceptions;
using Npgsql;

namespace FlashcardLib
{
    public class CardProperties
    {
        public int StackId { get; set; }
        public string Title { get; set; }
        public string Answer { get; set; }
    }

    public static class CardRepo
    {
        public static CardModel CreateCard(CardProperties properties)
        {
            CardValidator.ValidateCardProperties(properties);

            string query = @"INSERT INTO ""Cards""(""StackId"", ""Title"", ""Answer"")
                            VALUES (@StackId, @Title, @Answer)
                            RETURNING ""Id"", ""StackId"", ""Title"", ""Answer"";";

            // string query = @"WITH ""Inserted"" AS(
            //                     INSERT INTO ""Cards""(""StackId"", ""Title"", ""Answer"")
            //                     VALUES (@StackId, @Title, @Answer)
            //                     RETURNING ""Id"", ""StackId"", ""Title"", ""Answer""
            //                 ) SELECT * FROM ""Inserted""
            //                 INNER JOIN ""Stacks"" ON ""Stacks"".""Id"" = ""Inserted"".""StackId"";";

            Dictionary<string, object> parameters = [];
            parameters.Add("@StackId", properties.StackId);
            parameters.Add("@Title", properties.Title);
            parameters.Add("@Answer", properties.Answer);

            CardModel card = new();

            ReaderCallback assignCard = (NpgsqlDataReader reader) =>
            {
                if (!reader.HasRows)
                {
                    throw new BaseException("Something went wrong while creating a stack");
                }

                reader.Read();
                card.SetFrom(reader);
            };

            SqlAccess.ExecuteReader(query, parameters, assignCard);

            return card;
        }

        public static List<CardModel> AllCards(StackModel stack, int? limit = null)
        {
            string limitQuery = limit != null ? $" LIMIT {limit} " : string.Empty;
            string query = $@"SELECT * FROM ""Cards"" WHERE ""StackId"" = @StackId{limitQuery};";

            Dictionary<string, object> parameters = [];
            parameters.Add("@StackId", stack.Id);

            List<CardModel> cards = [];

            ReaderCallback fillCards = (NpgsqlDataReader reader) =>
            {
                if (!reader.HasRows) return;

                while (reader.Read())
                {
                    CardModel card = new();
                    card.SetFrom(reader);
                    cards.Add(card);
                }
            };

            SqlAccess.ExecuteReader(query, parameters, fillCards);

            return cards;
        }

        public static CardModel GetCard(int id)
        {
            string query = @"SELECT * FROM ""Cards"" WHERE ""Id"" = @Id LIMIT 1;";

            Dictionary<string, object> parameters = [];
            parameters.Add("@Id", id);

            CardModel card = new();

            ReaderCallback assignCard = (NpgsqlDataReader reader) =>
            {
                if (!reader.HasRows)
                {
                    throw new BaseException($"Card [{id}] doesn't exist");
                }

                reader.Read();
                card.SetFrom(reader);
            };

            SqlAccess.ExecuteReader(query, parameters, assignCard);

            return card;
        }
        public static CardModel EditCard(CardModel card, CardProperties properties)
        {
            CardValidator.ValidateCardProperties(properties);

            string query = @"UPDATE ""Cards"" SET ""Title"" = @Title, ""Answer"" = @Answer WHERE ""Id""=@Id;";

            Dictionary<string, object> parameters = [];
            parameters.Add("@Id", card.Id);
            parameters.Add("@Title", properties.Title);
            parameters.Add("@Answer", properties.Answer);

            SqlAccess.ExecuteNonQuery(query, parameters);

            card.Title = properties.Title;
            card.Answer = properties.Answer;

            return card;
        }

        public static void DeleteCard(CardModel card)
        {
            string query = @"DELETE FROM ""Cards"" WHERE ""Id"" = @Id;";

            Dictionary<string, object> parameters = [];
            parameters.Add("@Id", card.Id);

            SqlAccess.ExecuteNonQuery(query, parameters);
        }
    }
}