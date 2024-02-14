namespace FlashcardLib
{
    public class DeleteCardFeature : CardBaseFeature
    {
        public override void Run()
        {
            CardServices cardServices = new(App);
            CardModel card = cardServices.GetCard(CurrentStack);

            CardRepo.DeleteCard(card);
            SendResponse($"Card [{card.Id}] was deleted successfully!");
        }
    }
}