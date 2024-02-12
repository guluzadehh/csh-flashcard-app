using CommandApp.App;
using CommandApp.Feature;
using FlashcardLib;

namespace FlashcardApp
{
    public class ManageStacksFeature : BaseFeature
    {
        public override void Run()
        {
            IApp app = StackApp.Create();
            app.Start();
        }
    }
}