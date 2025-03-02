using DataLayer.Database;
using DataLayer.Model;
using Welcome.Others;

namespace DataLayer.Others.Menus
{
    internal class UserActionsMenu
    {
        private readonly DatabaseContext _dbContext;
        private readonly ActionOnLog _logInformation;
        private readonly ActionOnLog _logError;

        public UserActionsMenu(DatabaseContext dbContext, ActionOnLog logInformation, ActionOnLog logError)
        {
            _dbContext = dbContext;
            _logInformation = logInformation;
            _logError = logError;
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== User Management Menu ====");
                Console.WriteLine("1. Show all users");
                Console.WriteLine("2. Add new user");
                Console.WriteLine("3. Delete user by name");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ShowAllUsers();
                        break;
                    case "2":
                        AddUser();
                        break;
                    case "3":
                        DeleteUser();
                        break;
                    case "4":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }

        private void ShowAllUsers()
        {
            var users = _dbContext.Users.ToList();
            Console.WriteLine("\n==== Registered Users ====");
            users.ForEach(user => Console.WriteLine($"Name: {user.Name}, Role: {user.Role}"));
        }

        private void AddUser()
        {
            Console.Write("\nEnter username: ");
            string name = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            var newUser = new DatabaseUser
            {
                Name = name,
                Password = password,
                Role = UserRolesEnum.STUDENT,  // Default role
                Expires = DateTime.Now.AddYears(4)
            };

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();

            String userAddedMessage = $"User '{name}' added successfully!";
            Console.WriteLine(userAddedMessage);
            _logInformation(userAddedMessage);
        }

        private void DeleteUser()
        {
            Console.Write("\nEnter username to delete: ");
            string name = Console.ReadLine();

            var user = _dbContext.Users.FirstOrDefault(u => u.Name == name);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();

                string userRemovedMessage = $"User '{name}' deleted successfully.";
                Console.WriteLine(userRemovedMessage);
                _logInformation(userRemovedMessage);
            }
            else
            {
                string userNotFoundMessage = "User not found.";
                Console.WriteLine(userNotFoundMessage);
                _logError(userNotFoundMessage);
            }
        }
    }
}

