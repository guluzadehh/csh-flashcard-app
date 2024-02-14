using System.Data.Common;

namespace FlashcardLib
{
    public class StackModel : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void SetFrom(DbDataReader reader)
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id"));
            Name = reader.GetString(reader.GetOrdinal("Name"));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}