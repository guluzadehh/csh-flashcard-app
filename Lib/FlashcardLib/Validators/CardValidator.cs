using CommandApp.Exceptions;

namespace FlashcardLib
{
    public static class CardValidator
    {
        public static void ValidateCardProperties(CardProperties properties)
        {
            ValidateTitle(properties.Title);
            ValidateAnswer(properties.Answer);
        }

        public static void ValidateTitle(string title)
        {
            if (title.Length == 0)
            {
                throw new BaseException("Card title can't be empty");
            }
        }

        public static void ValidateAnswer(string answer)
        {
            if (answer.Length == 0)
            {
                throw new BaseException("Card answer can't be empty");
            }
        }
    }
}