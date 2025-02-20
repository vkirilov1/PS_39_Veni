namespace WelcomeExtended.Exceptions
{
    public class LogNotFoundException : Exception
    {
        public LogNotFoundException(int keyId)
            : base($"Log with key {keyId} not found.")
        {
        }
    }
}
