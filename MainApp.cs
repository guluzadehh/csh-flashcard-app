using CommandApp.App;
using CommandApp.Command;
using FlashcardLib;

namespace FlashcardApp
{
    public class MainApp : DefaultApp
    {
        public MainApp(ICommandCollection commands) : base(commands)
        {
            string initDatabase =
            @"CREATE TABLE public.""Cards"" (
                    ""Id"" integer NOT NULL,
                    ""StackId"" integer NOT NULL,
                    ""Title"" text NOT NULL,
                    ""Answer"" text NOT NULL
                );
                ALTER TABLE public.""Cards"" ALTER COLUMN ""Id"" ADD GENERATED ALWAYS AS IDENTITY (
                    SEQUENCE NAME public.""Cards_Id_seq""
                    START WITH 1
                    INCREMENT BY 1
                    NO MINVALUE
                    NO MAXVALUE
                    CACHE 1
                );
                CREATE TABLE public.""Stacks"" (
                    ""Id"" integer NOT NULL,
                    ""Name"" character varying(255) NOT NULL
                );
                ALTER TABLE public.""Stacks"" ALTER COLUMN ""Id"" ADD GENERATED ALWAYS AS IDENTITY (
                    SEQUENCE NAME public.""Stacks_Id_seq""
                    START WITH 1
                    INCREMENT BY 1
                    NO MINVALUE
                    NO MAXVALUE
                    CACHE 1
                );
                CREATE TABLE public.""StudySessions"" (
                    ""Id"" integer NOT NULL,
                    ""StackId"" integer NOT NULL,
                    ""CreatedAt"" timestamp without time zone DEFAULT now() NOT NULL,
                    ""Score"" integer NOT NULL
                );
                ALTER TABLE public.""StudySessions"" ALTER COLUMN ""Id"" ADD GENERATED ALWAYS AS IDENTITY (
                    SEQUENCE NAME public.""StudySession_Id_seq""
                    START WITH 1
                    INCREMENT BY 1
                    NO MINVALUE
                    NO MAXVALUE
                    CACHE 1
                );
                ALTER TABLE ONLY public.""Cards""
                ADD CONSTRAINT ""Cards_pkey"" PRIMARY KEY (""Id"");
                ALTER TABLE ONLY public.""Stacks""
                ADD CONSTRAINT ""Stacks_pkey"" PRIMARY KEY (""Id"");
                ALTER TABLE ONLY public.""StudySessions""
                ADD CONSTRAINT ""StudySession_pkey"" PRIMARY KEY (""Id"");
                ALTER TABLE ONLY public.""Stacks""
                ADD CONSTRAINT ""Unique name"" UNIQUE (""Name"");
                ALTER TABLE ONLY public.""Cards""
                ADD CONSTRAINT ""Stack reference"" FOREIGN KEY (""StackId"") REFERENCES public.""Stacks""(""Id"") ON DELETE CASCADE;
                ALTER TABLE ONLY public.""StudySessions""
                ADD CONSTRAINT ""Stack reference"" FOREIGN KEY (""StackId"") REFERENCES public.""Stacks""(""Id"") ON DELETE CASCADE;";

            SqlAccess.ExecuteNonQuery(initDatabase, []);
        }
    }
}