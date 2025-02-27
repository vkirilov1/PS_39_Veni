using Microsoft.Extensions.Logging;
using WelcomeExtended.Loggers;

namespace WelcomeExtended.Others.HashLoggerDelegates
{
    internal class HLDelegates
    {
        public static readonly HashLogger logger = new("Logger");

        public static void LogError(string error)
        {
            logger.LogError(error);
        }

        public static void LogInformation(string information)
        {
            logger.LogInformation(information);
        }

        public static void DisplayAllLogs()
        {
            logger.DisplayAllLogs();
        }

        public static void DisplayLogByKey(int keyId)
        {
            logger.DisplayLogByKey(keyId);
        }

        public static void DeleteLogByKey(int keyId)
        {
            logger.DeleteLogByKey(keyId);
        }
    }
}

