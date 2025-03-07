﻿using DataLayer.Database;
using DataLayer.Model;
using Microsoft.Extensions.Logging;

namespace DataLayer.Loggers
{
    internal class DbLogger : ILogger
    {
        private readonly string _name;

        public DbLogger(string name)
        {
            _name = name;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            //This logger does not support scopes.
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            //This logger is always enabled
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId,
            TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            using var context = new DatabaseContext();

            var message = formatter(state, exception);

            var logEntry = new DBLogEntry
            {
                LogLevel = logLevel.ToString(),
                EventId = eventId.Id,
                Message = message,
                Exception = exception?.ToString(),
                Timestamp = DateTime.Now
            };

            context.Logs.Add(logEntry);
            context.SaveChanges();
        }
    }
}
