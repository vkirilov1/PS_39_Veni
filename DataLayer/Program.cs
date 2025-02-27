using DataLayer.Database;
using DataLayer.Others.DBLoggerDeleagates;
using DataLayer.Others.Menus;

namespace DataLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using var dbContext = new DatabaseContext();

            dbContext.Database.EnsureCreated();

            var logInformation = new ActionOnLog(DBLoggerDelegates.LogInformation);
            var logError = new ActionOnLog(DBLoggerDelegates.LogError);

            var userMenu = new UserActionsMenu(dbContext, logInformation, logError);
            userMenu.ShowMenu();
        }
    }
}
