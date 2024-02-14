namespace FlashcardLib
{
    public class ViewAllCardsFeature : CardBaseFeature
    {
        public override void Run()
        {
            CardServices cardServices = new(App);
            cardServices.ListCards(CurrentStack);
            App.Output.Wait();
        }
    }
}