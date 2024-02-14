using CommandApp.Feature;

namespace FlashcardLib
{
    public class EditStackFeature : BaseFeature
    {
        public override void Run()
        {
            StackServices stackServices = new(App);
            StackModel stack = stackServices.GetStack();

            App.Output.Write($"Current name: {stack.Name}");
            string name = App.Input.Get("Enter name");

            stack = StackRepo.EditStack(stack, name);

            SendResponse($"Stack [{stack.Id}] was updated successfully!");
        }
    }
}