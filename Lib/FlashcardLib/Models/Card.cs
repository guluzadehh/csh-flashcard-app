using System.Data.Common;

namespace FlashcardLib
{
    public class CardModel : IModel
    {
        public int Id { get; set; }
        public int StackId { get; set; }
        public StackModel? Stack { get; set; }
        public string Title { get; set; }
        public string Answer { get; set; }


        public void SetFrom(DbDataReader reader)
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id"));
            StackId = reader.GetInt32(reader.GetOrdinal("StackId"));
            Title = reader.GetString(reader.GetOrdinal("Title"));
            Answer = reader.GetString(reader.GetOrdinal("Answer"));

            try
            {
                StackModel stack = new();
                stack.SetFrom(reader);

                Stack = stack;
            }
            catch
            { }
        }
    }
}