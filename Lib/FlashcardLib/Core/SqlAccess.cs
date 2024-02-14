using Npgsql;

namespace FlashcardLib
{
    public delegate void ReaderCallback(NpgsqlDataReader reader);

    public class SqlAccess
    {
        public static void InitDatabase()
        {

        }

        public static void ExecuteReader(string query, Dictionary<string, object> parameters, ReaderCallback cb)
        {
            using NpgsqlConnection conn = new(Helpers.GetConnectionString("FlashcardDB"));
            NpgsqlCommand command = PrepareCommand(conn, query, parameters);
            conn.Open();

            NpgsqlDataReader reader = command.ExecuteReader();
            cb(reader);

            reader.Close();
        }

        public static object? ExecuteScalar(string query, Dictionary<string, object> parameters)
        {
            using NpgsqlConnection conn = new(Helpers.GetConnectionString("FlashcardDB"));
            NpgsqlCommand command = PrepareCommand(conn, query, parameters);
            conn.Open();
            return command.ExecuteScalar();
        }

        public static int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            using NpgsqlConnection conn = new(Helpers.GetConnectionString("FlashcardDB"));
            NpgsqlCommand command = PrepareCommand(conn, query, parameters);
            conn.Open();
            return command.ExecuteNonQuery();
        }

        protected static NpgsqlCommand PrepareCommand(NpgsqlConnection conn, string query, Dictionary<string, object> parameters)
        {
            NpgsqlCommand command = new(query, conn);
            foreach (KeyValuePair<string, object> kv in parameters)
            {
                command.Parameters.AddWithValue(kv.Key, kv.Value);
            }
            return command;
        }
    }
}