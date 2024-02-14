namespace FlashcardLib
{
    public class CreateCardFeature : CardBaseFeature
    {
        public override void Run()
        {
            string title = App.Input.Get("Enter title");
            string answer = App.Input.Get("Enter answer");

            CardProperties properties = new()
            {
                StackId = CurrentStack.Id,
                Title = title,
                Answer = answer,
            };

            CardModel card = CardRepo.CreateCard(properties);
            SendResponse($"Card [{card.Id}] for {CurrentStack.Name} was created successfully!");
        }
    }
}