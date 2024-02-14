namespace FlashcardLib
{
    public class ViewXCardsFeature : CardBaseFeature
    {
        public override void Run()
        {
            int amount = Helpers.GetIntInput(App.Input, "Enter amount");

            CardServices cardServices = new(App);
            cardServices.ListCards(CurrentStack, amount);

            App.Output.Wait();
        }
    }
}