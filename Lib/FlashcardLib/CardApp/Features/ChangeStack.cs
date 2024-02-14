namespace FlashcardLib
{
    public class ChangeStackFeature : CardBaseFeature
    {
        public override void Run()
        {
            StackServices stackServices = new(App);
            StackModel stack = stackServices.GetStack();
            CurrentStack = stack;
            SendResponse($"Current Stack was set to {CurrentStack.Name}");
        }
    }
}