using CommandApp.App;
using CommandApp.Command;
using FlashcardLib;

namespace FlashcardApp
{
    public class MainApp : DefaultApp
    {
        public MainApp(ICommandCollection commands) : base(commands)
        {
            SqlAccess.InitDatabase();
        }
    }
}