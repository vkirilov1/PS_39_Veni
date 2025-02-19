namespace WelcomeExtended.Exceptions
{
    public class LogNotFoundException : Exception
    {
        public int KeyId { get; }

        public LogNotFoundException(int keyId)
            : base($"Log with key {keyId} not found.")
        {
            KeyId = keyId;
        }
    }
}
