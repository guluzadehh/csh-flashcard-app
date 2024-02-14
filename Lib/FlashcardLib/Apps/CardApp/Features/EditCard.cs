using CommandApp.Exceptions;

namespace FlashcardLib
{
    public class EditCardFeature : CardBaseFeature
    {
        public override void Run()
        {
            CardServices cardServices = new(App);
            CardModel card = cardServices.GetCard(CurrentStack);

            CardProperties properties = new()
            {
                Title = card.Title,
                Answer = card.Answer
            };

            try
            {
                App.Output.Write($"Current title: {card.Title}");
                properties.Title = App.Input.Get("Enter title (q! for default)");
            }
            catch (QuitInputRead) { }

            try
            {
                App.Output.Write($"Current answer: {card.Answer}");
                properties.Answer = App.Input.Get("Enter answer (q! for default)");
            }
            catch (QuitInputRead) { }

            card = CardRepo.EditCard(card, properties);

            SendResponse($"Card [{card.Id}] was updated successfully!");
        }
    }
}