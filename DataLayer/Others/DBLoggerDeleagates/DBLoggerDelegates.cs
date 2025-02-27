using DataLayer.Loggers;
using Microsoft.Extensions.Logging;

namespace DataLayer.Others.DBLoggerDeleagates
{
    internal class DBLoggerDelegates
    {
        public static readonly DbLogger logger = new("DBLogger");
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
