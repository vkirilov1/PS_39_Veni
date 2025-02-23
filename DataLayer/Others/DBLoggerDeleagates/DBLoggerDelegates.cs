using DataLayer.Loggers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
