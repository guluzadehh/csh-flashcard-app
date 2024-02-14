using System.Configuration;
using CommandApp.Exceptions;
using CommandApp.IO;

namespace FlashcardLib
{
    public static class Helpers
    {
        public static string GetConnectionString(string db)
        {
            return ConfigurationManager.ConnectionStrings[db].ConnectionString;
        }

        public static int GetIntInput(IAppInput input, string? infoText = null)
        {
            string value = input.Get(infoText);

            try
            {
                return Convert.ToInt32(value);
            }
            catch (Exception)
            {
                throw new BaseException($"Wrong int format `{value}`");
            }
        }
    }
}