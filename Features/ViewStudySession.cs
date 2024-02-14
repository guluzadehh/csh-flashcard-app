using CommandApp.Feature;
using FlashcardLib;

namespace FlashcardApp
{
    public class ViewStudySessionFeature : BaseFeature
    {
        public override void Run()
        {
            App.Output.Write("Study Sessions:\n\n");

            foreach (StudySessionModel studySession in StudySessionRepo.AllStudySessions())
            {
                App.Output.Write($"{studySession.Id}. [{studySession.CreatedAt}] ({studySession.Stack?.Name}) -> {studySession.Score}/{studySession.Stack?.CardsCount}\n");
            }

            App.Output.Wait();
        }
    }
}