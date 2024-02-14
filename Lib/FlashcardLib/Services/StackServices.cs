using CommandApp.App;

namespace FlashcardLib
{
    public class StackServices(IApp app) : BaseService(app)
    {
        public void ListStacks()
        {
            List<StackModel> stacks = StackRepo.AllStack();
            foreach (StackModel stack in stacks)
            {
                App.Output.Write($"{stack.Id}. {stack.Name}");
            }
        }

        public StackModel GetStack()
        {
            ListStacks();
            int id = Helpers.GetIntInput(App.Input, "Enter id");
            return StackRepo.GetStack(id);
        }
    }
}