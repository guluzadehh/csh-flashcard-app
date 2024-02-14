using System.Data.Common;

namespace FlashcardLib
{
    public class StackModel : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CardsCount { get; set; } = null;

        public void SetFrom(DbDataReader reader)
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id"));
            Name = reader.GetString(reader.GetOrdinal("Name"));

            try
            {
                CardsCount = reader.GetInt32(reader.GetOrdinal("CardsCount"));
            }
            catch { }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}