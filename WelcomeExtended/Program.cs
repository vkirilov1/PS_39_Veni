using Welcome.Model;
using Welcome.Others;
using Welcome.ViewModel;
using Welcome.View;
using WelcomeExtended.Others.HashLoggerDelegates;
using WelcomeExtended.Others.FileLoggerDelegates;

namespace WelcomeExtended
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var logHLInfo = new ActionOnLog(HLDelegates.LogInformation);
                var logFLInfo = new ActionOnLog(FLDelegates.LogInformation);
                logHLInfo("Creating User...");
                logFLInfo("Creating User...");
                var user = new User
                {
                    Name = "John Smith",
                    Password = "password123",
                    Role = UserRolesEnum.STUDENT
                };
                var viewModel = new UserViewModel(user);
                var view = new UserView(viewModel);
                logHLInfo("User created successfully!");
                logFLInfo("User created successfully!");
                view.DisplayError("User does not exist!");
            }
            catch (Exception e)
            {
                var logHLError = new ActionOnLog(HLDelegates.LogError);
                logHLError(e.Message);
                var logFLError = new ActionOnLog(FLDelegates.LogError);
                logFLError(e.Message);
                
            }
            finally
            {
                var logAll = new ActionOnAllLogs(HLDelegates.DisplayAllLogs);
                logAll();
            }
        }
    }
}
