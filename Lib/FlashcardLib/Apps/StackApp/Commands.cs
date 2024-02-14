using CommandApp.Command;
using CommandApp.Feature;

namespace FlashcardLib
{
    public class ViewStacksCommand : BaseCommand
    {
        public override string Value { get; } = "V";

        public override string Description { get; } = "View Stacks";

        public override IFeature Feature { get; } = new ViewStacksFeature();
    }

    public class CreateStackCommand : BaseCommand
    {
        public override string Value { get; } = "C";

        public override string Description { get; } = "Create a Stack";

        public override IFeature Feature { get; } = new CreateStackFeature();
    }

    public class EditStackCommand : BaseCommand
    {
        public override string Value { get; } = "E";

        public override string Description { get; } = "Edit a Stack";

        public override IFeature Feature { get; } = new EditStackFeature();
    }

    public class DeleteStackCommand : BaseCommand
    {
        public override string Value { get; } = "D";

        public override string Description { get; } = "Delete a Stack";

        public override IFeature Feature { get; } = new DeleteStackFeature();
    }
}