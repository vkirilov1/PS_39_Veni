using Welcome.Model;
using WelcomeExtended.Data;
using WelcomeExtended.Exceptions;

namespace WelcomeExtended.Helpers
{
    internal static class UserHelper
    {
        public static string ToString(this User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User cannot be null.");
            }
            string expiresFormatted = user.Expires == default(DateTime) ? "N/A" : user.Expires.ToString("yyyy-MM-dd HH:mm:ss");
            return $"Name: {user.Name}, Role: {user.Role}, Expires: {expiresFormatted}";
        }

        public static void ValidateCredentials(this UserData userData, string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new UserInvalidCredentialsException("username");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new UserInvalidCredentialsException("password");
            }
            userData.ValidateUser(username, password);
        }

        public static User GetUser(this UserData userData, string username, string password)
        {
            return userData.GetUser(username, password);
        }
    }
}
