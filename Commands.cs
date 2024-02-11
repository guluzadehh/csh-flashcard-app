using CommandApp.Command;
using CommandApp.Feature;

namespace FlashcardApp
{
    public class ManageStacksCommand : BaseCommand
    {
        public override string Value { get; } = "ms";

        public override string Description { get; } = "Manage stacks";

        public override IFeature Feature { get; } = new ManageStacksFeature();
    }

    public class ManageFlashcardsCommand : BaseCommand
    {
        public override string Value { get; } = "mf";

        public override string Description { get; } = "Manage flashcards";

        public override IFeature Feature { get; } = new ManageFlashcardsFeature();
    }

    public class StudyCommand : BaseCommand
    {
        public override string Value { get; } = "s";

        public override string Description { get; } = "Study";

        public override IFeature Feature { get; } = new StudyFeature();
    }

    public class ViewStudySessionCommand : BaseCommand
    {
        public override string Value { get; } = "v";

        public override string Description { get; } = "View study session data";

        public override IFeature Feature { get; } = new ViewStudySessionFeature();
    }
}