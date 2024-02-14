using CommandApp.Exceptions;
using Npgsql;

namespace FlashcardLib
{
    public static class StackRepo
    {
        public static StackModel CreateStack(string name)
        {
            StackValidator.ValidateName(name);

            Dictionary<string, object> parameters = [];
            parameters.Add("@Name", name);

            string query = $@"INSERT INTO ""Stacks""(""Name"") VALUES (@Name) RETURNING ""Id"", ""Name"";";

            StackModel stack = new();

            ReaderCallback assignStack = (NpgsqlDataReader reader) =>
            {
                if (!reader.HasRows)
                {
                    throw new BaseException("Something went wrong while creating a stack");
                }

                reader.Read();
                stack.SetFrom(reader);
            };

            SqlAccess.ExecuteReader(query, parameters, assignStack);

            return stack;
        }

        public static StackModel GetStack(int id)
        {
            string query = @"SELECT * FROM ""Stacks"" WHERE ""Id"" = @Id LIMIT 1;";

            Dictionary<string, object> parameters = [];
            parameters.Add("@Id", id);

            StackModel stack = new();

            ReaderCallback assignStack = (NpgsqlDataReader reader) =>
            {
                if (!reader.HasRows)
                {
                    throw new BaseException($"Stack [{id}] doesn't exist");
                }

                reader.Read();
                stack.SetFrom(reader);
            };

            SqlAccess.ExecuteReader(query, parameters, assignStack);

            return stack;
        }

        public static List<StackModel> AllStack()
        {
            string query = @"SELECT * FROM ""Stacks"";";

            List<StackModel> stacks = [];

            ReaderCallback fillStacks = (NpgsqlDataReader reader) =>
            {
                if (!reader.HasRows) return;

                while (reader.Read())
                {
                    StackModel stack = new();
                    stack.SetFrom(reader);
                    stacks.Add(stack);
                }
            };

            SqlAccess.ExecuteReader(query, [], fillStacks);

            return stacks;
        }

        public static StackModel EditStack(StackModel stack, string name)
        {
            StackValidator.ValidateName(name);

            string query = @"UPDATE ""Stacks"" SET ""Name"" = @Name WHERE ""Id""=@Id;";

            Dictionary<string, object> parameters = [];
            parameters.Add("@Id", stack.Id);
            parameters.Add("@Name", name);

            SqlAccess.ExecuteNonQuery(query, parameters);

            stack.Name = name;

            return stack;
        }

        public static void DeleteStack(StackModel stack)
        {
            string query = @"DELETE FROM ""Stacks"" WHERE ""Id"" = @Id;";

            Dictionary<string, object> parameters = [];
            parameters.Add("@Id", stack.Id);

            SqlAccess.ExecuteNonQuery(query, parameters);
        }
    }
}