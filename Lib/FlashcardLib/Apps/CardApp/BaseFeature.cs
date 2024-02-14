using CommandApp.Exceptions;
using CommandApp.Feature;

namespace FlashcardLib
{
    public abstract class CardBaseFeature : BaseFeature
    {
        public StackModel CurrentStack
        {
            get
            {
                object stack = App.Context.GetValueOrDefault("Stack", null) ?? throw new BaseException("Current Stack is not set.");
                return (StackModel)stack;
            }
            set
            {
                App.Context["Stack"] = value;
            }
        }
    }
}