using CommandApp.App;
using CommandApp.Command;

namespace FlashcardApp
{
    public static class Program
    {
        public static void Main()
        {
            ICommandCollection commands = new DefaultCommandCollection();
            RegisterCommands(commands);

            IApp app = new DefaultApp(commands);
            app.Start();
        }

        public static void RegisterCommands(ICommandCollection commands)
        {

        }
    }
}