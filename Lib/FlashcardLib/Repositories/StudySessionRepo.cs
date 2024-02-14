using CommandApp.Exceptions;
using Npgsql;

namespace FlashcardLib
{
    public static class StudySessionRepo
    {
        public static StudySessionModel CreateStudySession(int stackId, int score)
        {
            string query =
                @"INSERT INTO ""StudySessions""(""StackId"", ""Score"") 
                VALUES (@StackId, @Score)
                RETURNING ""Id"", ""StackId"", ""Score"", ""CreatedAt"";";

            Dictionary<string, object> parameters = [];
            parameters.Add("@StackId", stackId);
            parameters.Add("@Score", score);

            StudySessionModel studySession = new();

            ReaderCallback assignStudySession = (NpgsqlDataReader reader) =>
            {
                if (!reader.HasRows)
                {
                    throw new BaseException("Something went wrong while creating a study session");
                }

                reader.Read();
                studySession.SetFrom(reader);
            };

            SqlAccess.ExecuteReader(query, parameters, assignStudySession);

            return studySession;
        }

        public static List<StudySessionModel> AllStudySessions()
        {
            string query =
                @"SELECT *, (
                    SELECT COUNT(*) FROM ""Cards"" WHERE ""Cards"".""StackId"" = ""Stacks"".""Id""
                ) AS ""CardsCount"" FROM ""StudySessions""
                INNER JOIN ""Stacks"" ON ""Stacks"".""Id"" = ""StudySessions"".""StackId"";";

            List<StudySessionModel> studySessions = [];

            ReaderCallback fillStudySessions = (NpgsqlDataReader reader) =>
            {
                if (!reader.HasRows) return;
                while (reader.Read())
                {
                    StudySessionModel studySession = new();
                    studySession.SetFrom(reader);
                    studySessions.Add(studySession);
                }
            };

            SqlAccess.ExecuteReader(query, [], fillStudySessions);

            return studySessions;
        }
    }
}