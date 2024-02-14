using CommandApp.App;
using CommandApp.Command;
using CommandApp.Exceptions;

namespace FlashcardLib
{
    public class CardApp(ICommandCollection commands) : DefaultApp(commands)
    {
        public static IApp Create()
        {
            ICommandCollection commands = new DefaultCommandCollection();
            commands.Register(new ChangeStackCommand());
            commands.Register(new ViewAllCardsCommand());
            commands.Register(new ViewXCardsCommand());
            commands.Register(new CreateCardCommand());
            commands.Register(new EditCardCommand());
            commands.Register(new DeleteCardCommand());

            IApp app = new CardApp(commands);
            return app;
        }
    }
}