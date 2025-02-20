namespace WelcomeExtended.Exceptions
{
    internal class UserNotFoundException : Exception
    {
        public UserNotFoundException(string name)
            : base($"User \"{name}\" not found!")
        {
        }
    }
}
