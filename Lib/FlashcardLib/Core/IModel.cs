using System.Data.Common;

namespace FlashcardApp
{
    public interface IModel
    {
        void SetFrom(DbDataReader reader);
    }
}