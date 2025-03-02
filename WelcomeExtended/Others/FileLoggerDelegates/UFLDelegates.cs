using Microsoft.Extensions.Logging;
using WelcomeExtended.Loggers;

namespace WelcomeExtended.Others.FileLoggerDelegates
{
    internal class UFLDelegates
    {
        public static readonly UserFileLogger logger = new("Logger");

        public static void LogError(string error)
        {
            logger.LogError(error);
        }

        public static void LogInformation(string information)
        {
            logger.LogInformation(information);
        }
    }
}
