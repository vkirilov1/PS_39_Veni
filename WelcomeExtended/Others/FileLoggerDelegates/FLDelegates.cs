using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelcomeExtended.Loggers;

namespace WelcomeExtended.Others.FileLoggerDelegates
{
    internal class FLDelegates
    {
        public static readonly FileLogger logger = new("Logger");

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
