using CommandApp.Feature;

namespace FlashcardLib
{
    public class DeleteStackFeature : BaseFeature
    {
        public override void Run()
        {
            StackServices stackServices = new(App);

            StackModel stack = stackServices.GetStack();
            StackRepo.DeleteStack(stack);

            SendResponse($"Stack [{stack.Id}] was deleted successfully!");
        }
    }
}