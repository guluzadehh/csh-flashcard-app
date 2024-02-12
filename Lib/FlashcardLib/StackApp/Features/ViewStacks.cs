using CommandApp.Feature;

namespace FlashcardLib
{
    public class ViewStacksFeature : BaseFeature
    {
        public override void Run()
        {
            List<StackModel> stacks = SqlAccess.ReadStacks();

            foreach (StackModel stack in stacks)
            {
                App.Output.Write($"{stack.Id}. {stack.Name}");
            }

            App.Output.Wait();
        }
    }
}