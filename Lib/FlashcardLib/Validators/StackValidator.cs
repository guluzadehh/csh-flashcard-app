using CommandApp.Exceptions;

namespace FlashcardLib
{
    public static class StackValidator
    {
        public static void ValidateName(string name)
        {
            if (name.Length == 0)
            {
                throw new BaseException("Name is empty.");
            }
        }
    }
}