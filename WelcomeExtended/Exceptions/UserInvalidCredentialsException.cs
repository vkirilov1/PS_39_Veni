using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
