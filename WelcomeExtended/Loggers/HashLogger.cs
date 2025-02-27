using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Text;
using WelcomeExtended.Exceptions;

namespace WelcomeExtended.Loggers
{
    internal class HashLogger : ILogger
    {
        private readonly ConcurrentDictionary<int, string> _logMessages;
        private readonly string _name;
        private static int _logCounter = 0;

        public HashLogger(String name)
        {
            _name = name;
            _logMessages = new ConcurrentDictionary<int, string>();
        }

        public void DisplayAllLogs()
        {
            Console.WriteLine("- ALL LOGS -");
            foreach (var log in _logMessages)
            {
                Console.WriteLine($"Key:{log.Key}, Message: {log.Value}");
            }
            Console.WriteLine("- ALL LOGS -");
        }

        public void DisplayLogByKey(int keyId)
        {
            string? message = _logMessages.TryGetValue(keyId, out string? value) ? value : null;
            if (message != null)
            {
                Console.WriteLine($"Log {keyId}: {message}");
            }
            else
            {
                throw new LogNotFoundException(keyId);
            }
        }

        public void DeleteLogByKey(int keyId)
        {
            string? message = _logMessages.Remove(keyId, out string? value) ? value : null;
            Console.Write(message);
            if (message != null)
            {
                Console.WriteLine($"Log \"{keyId}: {message}\" has been deleted!");
            }
            else
            {
                throw new LogNotFoundException(keyId);
            }
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
            TState state, Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            var message = formatter(state, exception);

            int logKey = Interlocked.Increment(ref _logCounter);

            switch (logLevel)
            {
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Console.WriteLine("- LOGGER -");
            var messageToBeLogged = new StringBuilder();
            messageToBeLogged.Append($"[{logLevel}]");
            messageToBeLogged.AppendFormat(" [{0}]", _name);
            Console.WriteLine(messageToBeLogged);
            Console.WriteLine($" {formatter(state, exception)}");
            Console.WriteLine("- LOGGER -");
            Console.ResetColor();
            _logMessages[logKey] = message;
        }
    }
}
