using CommandApp.Command;
using CommandApp.Feature;

namespace FlashcardLib
{
    public class ChangeStackCommand : BaseCommand
    {
        public override string Value { get; } = "X";

        public override string Description { get; } = "Change current stack";

        public override IFeature Feature { get; } = new ChangeStackFeature();
    }

    public class ViewAllCardsCommand : BaseCommand
    {
        public override string Value { get; } = "V";

        public override string Description { get; } = "View all Cards in stack";

        public override IFeature Feature { get; } = new ViewAllCardsFeature();
    }

    public class ViewXCardsCommand : BaseCommand
    {
        public override string Value { get; } = "A";

        public override string Description { get; } = "View X amount of Cards in stack";

        public override IFeature Feature { get; } = new ViewXCardsFeature();
    }

    public class CreateCardCommand : BaseCommand
    {
        public override string Value { get; } = "C";

        public override string Description { get; } = "Create a Card in current stack";

        public override IFeature Feature { get; } = new CreateCardFeature();
    }

    public class EditCardCommand : BaseCommand
    {
        public override string Value { get; } = "E";

        public override string Description { get; } = "Edit a Card";

        public override IFeature Feature { get; } = new EditCardFeature();
    }

    public class DeleteCardCommand : BaseCommand
    {
        public override string Value { get; } = "D";

        public override string Description { get; } = "Delete a Card";

        public override IFeature Feature { get; } = new DeleteCardFeature();
    }
}