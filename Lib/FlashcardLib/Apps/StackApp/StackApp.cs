using CommandApp.App;
using CommandApp.Command;

namespace FlashcardLib
{
    public class StackApp(ICommandCollection commands) : DefaultApp(commands)
    {
        public static IApp Create()
        {
            ICommandCollection commands = new DefaultCommandCollection();
            commands.Register(new ViewStacksCommand());
            commands.Register(new CreateStackCommand());
            commands.Register(new EditStackCommand());
            commands.Register(new DeleteStackCommand());

            IApp app = new StackApp(commands);
            return app;
        }
    }
}