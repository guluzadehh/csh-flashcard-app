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
            @"CREATE TABLE IF NOT EXISTS public.""Stacks"" (
                ""Id"" SERIAL PRIMARY KEY,
                ""Name"" character varying(255) NOT NULL,
                UNIQUE(""Name"")
            );
            CREATE TABLE IF NOT EXISTS public.""Cards"" (
                ""Id"" SERIAL PRIMARY KEY,
                ""StackId"" integer NOT NULL,
                ""Title"" text NOT NULL,
                ""Answer"" text NOT NULL,
                FOREIGN KEY (""StackId"") REFERENCES public.""Stacks""(""Id"") ON DELETE CASCADE
            );
            CREATE TABLE IF NOT EXISTS public.""StudySessions"" (
                ""Id"" SERIAL PRIMARY KEY,
                ""StackId"" integer NOT NULL,
                ""CreatedAt"" timestamp without time zone DEFAULT now() NOT NULL,
                ""Score"" integer NOT NULL,
                FOREIGN KEY (""StackId"") REFERENCES public.""Stacks""(""Id"") ON DELETE CASCADE
            );";

            SqlAccess.ExecuteNonQuery(initDatabase, []);
        }
    }
}