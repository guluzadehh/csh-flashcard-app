using CommandApp.Feature;

namespace FlashcardLib
{
    public class CreateStackFeature : BaseFeature
    {
        public override void Run()
        {
            string name = App.Input.Get("Enter name");
            StackModel stack = SqlAccess.CreateStack(name);
            SendResponse($"Stack [{stack.Id}] ({stack.Name}) was created successfully!");
        }
    }
}