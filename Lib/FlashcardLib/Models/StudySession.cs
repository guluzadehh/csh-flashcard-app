using System.Data.Common;

namespace FlashcardLib
{
    public class StudySessionModel : IModel
    {
        public int Id { get; set; }
        public int StackId { get; set; }
        public int Score { get; set; }
        public DateTime CreatedAt { get; set; }
        public StackModel? Stack { get; set; }

        public void SetFrom(DbDataReader reader)
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id"));
            StackId = reader.GetInt32(reader.GetOrdinal("StackId"));
            Score = reader.GetInt32(reader.GetOrdinal("Score"));
            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"));

            try
            {
                StackModel stack = new();
                stack.SetFrom(reader);
                Stack = stack;
            }
            catch { }
        }
    }
}