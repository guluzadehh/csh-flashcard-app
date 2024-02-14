using CommandApp.App;

namespace FlashcardLib
{
    public class CardServices(IApp app) : BaseService(app)
    {
        public void ListCards(StackModel stack, int? amount = null)
        {
            List<CardModel> cards = CardRepo.AllCards(stack, amount);
            foreach (CardModel card in cards)
            {
                App.Output.Write($"{card.Id}. {card.Title} -> {card.Answer}");
            }
        }

        public CardModel GetCard(StackModel stack)
        {
            ListCards(stack);
            int id = Helpers.GetIntInput(App.Input, "Enter id");
            return CardRepo.GetCard(id);
        }
    }
}