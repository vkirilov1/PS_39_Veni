namespace WelcomeExtended.Exceptions
{
    internal class UserInvalidCredentialsException : Exception
    {
        public UserInvalidCredentialsException(string emptyField)
            : base($"The {emptyField} field cannot be empty!")
        {
        }
    }
}
