using CommandApp.Feature;

namespace FlashcardLib
{
    public class ViewStacksFeature : BaseFeature
    {
        public override void Run()
        {
            StackServices stackServices = new(App);
            stackServices.ListStacks();
            App.Output.Wait();
        }
    }
}