using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobRefactored
{
    internal class User
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        private Settings UserSettings;

        public User(string name, string email, string password, Settings settings)
        {
            Name = name;
            Email = email;
            Password = password;
            UserSettings = settings;
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

        public void UpdateTheme(string newTheme)
        {
            UserSettings.UpdateTheme(newTheme);
        }

        public void UpdateNotifications(bool receiveNotifications)
        {
            UserSettings.UpdateNotifications(receiveNotifications);
        }

        public void DisplaySettings()
        {
            UserSettings.DisplaySettings();
        }

        public void ReceiveNotification(string email, string message)
        {
            Console.WriteLine($"User notified: {email}, Message: {message}");
        }
    }
}