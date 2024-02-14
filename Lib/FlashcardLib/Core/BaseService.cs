using CommandApp.App;

namespace FlashcardLib
{
    public class BaseService(IApp app)
    {
        public IApp App { get; set; } = app;
    }
}