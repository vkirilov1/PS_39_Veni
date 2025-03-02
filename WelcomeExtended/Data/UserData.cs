using Welcome.Model;
using Welcome.Others;
using WelcomeExtended.Exceptions;
using WelcomeExtended.Others.FileLoggerDelegates;

namespace WelcomeExtended.Data
{
    internal class UserData
    {
        private readonly List<User> _users;
        private static int _nextId;

        public UserData()
        {
            _users = new List<User>();
            _nextId = 0;
        }

        public void AddUser(User user)
        {
            user.Id = _nextId++;
            _users.Add(user);
        }
        public void DeleteUser(User user)
        {
            if (!_users.Remove(user))
            {
                throw new UserNotFoundException(user.Name);
            }
        }
        public bool ValidateUser(string name, string password)
        {
            return _users.Where(x => x.Name == name && x.Password == password)
                .FirstOrDefault() != null ? true : false;
        }
        public void SetActive(string name, DateTime date)
        {

            GetUser(name).Expires = date;
        }
        public void AssignUserRole(string name, UserRolesEnum role)
        {
            GetUser(name).Role = role;
        }
        public User GetUser(string name, string password)
        {
            var user = _users.FirstOrDefault(user => user.Name == name && user.Password == password);

            if (user == null)
            {
                throw new UserNotFoundException(name);
            }

            var logLogin = new ActionOnLog(UFLDelegates.LogInformation);
            logLogin($"User {name} has logged in!");

            return user;
        }
        private User GetUser(string name)
        {
            var user = _users.Where(user => user.Name == name).FirstOrDefault();

            if (user == null)
            {
                throw new UserNotFoundException(name);
            }

            return user;
        }

        /*
        * Two more methods that can be used to validate a user's existance and they're both correct!
        * One is using a default syntax, while the other is using LINQ
        * 
            public bool ValidateUser(string name, string password)
            {
                foreach (var user in _users)
                {
                    if (user.Name == name && user.Password == password)
                    {
                        return true;
                    }
                }
            return false;
            }

            public bool ValidateUserLinq(string name, string password)
            {
                var ret = from user in _users
                          where user.Name == name && user.Password == password
                          select user.Id;
                return ret != null ? true : false;
            }
        *
        */
    }
}
