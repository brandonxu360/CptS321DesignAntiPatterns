using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blob_library
{
    internal class User
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public void UpdateEmail(string newEmail)
        {
            Email = newEmail;
            Console.WriteLine($"Email updated to: {Email}");
        }

        public void UpdatePassword(string newPassword)
        {
            Password = newPassword;
            Console.WriteLine("Password updated successfully.");
        }

        public void DisplayUserInfo()
        {
            Console.WriteLine($"User: {Name}, Email: {Email}");
        }
    }
}
