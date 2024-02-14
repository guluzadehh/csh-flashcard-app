using CommandApp.App;
using CommandApp.Feature;
using FlashcardLib;

namespace FlashcardApp
{
    public class ManageFlashcardsFeature : BaseFeature
    {
        public override void Run()
        {
            StackServices stackServices = new(App);
            StackModel stack = stackServices.GetStack();

            IApp app = CardApp.Create();
            app.Context.Add("Stack", stack);
            app.Start();
        }
    }
}