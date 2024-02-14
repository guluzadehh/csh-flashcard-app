using System.Data.Common;

namespace FlashcardLib
{
    public interface IModel
    {
        void SetFrom(DbDataReader reader);
    }
}