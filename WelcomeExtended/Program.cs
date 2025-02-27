using Welcome.Model;
using Welcome.Others;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;
using WelcomeExtended.Others.FileLoggerDelegates;

namespace WelcomeExtended
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UserData userData = new();

                User studentUser = new()
                {
                    Name = "student",
                    Password = "student123",
                    Role = UserRolesEnum.STUDENT
                };
                User studentUser2 = new()
                {
                    Name = "student2",
                    Password = "123",
                    Role = UserRolesEnum.STUDENT
                };
                User teacherUser = new()
                {
                    Name = "teacher",
                    Password = "1234",
                    Role = UserRolesEnum.PROFESSOR
                };
                User adminUser = new()
                {
                    Name = "admin",
                    Password = "admin123",
                    Role = UserRolesEnum.ADMIN
                };
                userData.AddUser(studentUser);
                userData.AddUser(studentUser2);
                userData.AddUser(teacherUser);
                userData.AddUser(adminUser);

                DateTime date = DateTime.Now;

                userData.SetActive("student", date);

                Console.WriteLine("Enter username: ");
                string username = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                string password = Console.ReadLine();

                userData.ValidateCredentials(username, password);
                User u = userData.GetUser(username, password);
                Console.WriteLine(UserHelper.ToString(u));
            }
            catch (Exception e)
            {
                var logError = new ActionOnLog(UFLDelegates.LogError);
                logError(e.Message);
            }
        }
    }
}
