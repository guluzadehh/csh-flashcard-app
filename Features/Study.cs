using CommandApp.Exceptions;
using CommandApp.Feature;
using FlashcardLib;

namespace FlashcardApp
{
    public class StudyFeature : BaseFeature
    {
        public override void Run()
        {
            StackServices stackServices = new(App);
            StackModel stack = stackServices.GetStack();

            List<CardModel> cards = CardRepo.AllCards(stack);

            if (cards.Count == 0)
            {
                throw new BaseException($"{stack.Name} doesn't have any cards");
            }

            int score = 0;
            int current = 0;
            foreach (CardModel card in cards)
            {
                current++;

                App.Output.Write($"{stack.Name}");
                App.Output.Write($"({current}/{stack.CardsCount}) {card.Title} -> ?");

                string answer = App.Input.Get("Answer");
                bool isCorrect = string.Equals(card.Answer, answer, StringComparison.CurrentCultureIgnoreCase);

                if (isCorrect)
                {
                    score++;
                }

                App.Output.Write($"{card.Title} -> {card.Answer}");
                App.Output.Write($"Your answer: {(isCorrect ? "\u001b[32m" : "\u001b[31m")} {answer}\u001b[0m");

                App.Output.Wait();
            }

            App.Output.Write($"Your score: {score}/{cards.Count}\n");

            string save = App.Input.Get($"Do you want to save the result (y/n)?");
            if (string.Equals(save, "y", StringComparison.CurrentCultureIgnoreCase))
            {
                StudySessionModel studySession = StudySessionRepo.CreateStudySession(stack.Id, score);
                SendResponse($"Session [{studySession.Id}] was created successfully!");
            }
        }
    }
}