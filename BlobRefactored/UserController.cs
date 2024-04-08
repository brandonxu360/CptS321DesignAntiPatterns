using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobRefactored
{
    public class UserController
    {
        private List<User> users = new List<User>();

        public UserController(NotificationService notificationService)
        {
            notificationService.NotificationSent += OnNotificationSent;
        }

        // Adds a new user to the system
        public void AddUser(string name, string email, string password)
        {
            var newUserSettings = new Settings(true, "Default");
            var newUser = new User(name, email, password, newUserSettings);
            users.Add(newUser);
            Console.WriteLine($"New user added: {name}");
        }

        // Authenticates a user based on email and password
        public bool AuthenticateUser(string email, string password)
        {
            var user = users.FirstOrDefault(u => u.Email == email);
            if (user != null && user.Password == password)
            {
                Console.WriteLine($"{email} authenticated successfully.");
                return true;
            }
            else
            {
                Console.WriteLine("Authentication failed.");
                return false;
            }
        }

        // Finds a user by email and updates their email
        public void UpdateUserEmail(string oldEmail, string newEmail)
        {
            var user = users.FirstOrDefault(u => u.Email == oldEmail);
            if (user != null)
            {
                user.UpdateEmail(newEmail);
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        // Finds a user by email and updates their password
        public void UpdateUserPassword(string email, string newPassword)
        {
            var user = users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                user.UpdatePassword(newPassword);
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        // Finds a user by email and updates their theme
        public void UpdateUserTheme(string email, string newTheme)
        {
            var user = users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                user.UpdateTheme(newTheme);
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        // Finds a user by email and updates their notification settings
        public void UpdateUserNotifications(string email, bool receiveNotifications)
        {
            var user = users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                user.UpdateNotifications(receiveNotifications);
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        // Method to display all users (for debugging or administrative purposes)
        public void DisplayAllUsers()
        {
            foreach (var user in users)
            {
                user.DisplayUserInfo();
                user.DisplaySettings();
            }
        }

        // Event handler
        private void OnNotificationSent(object source, NotificationEventArgs args)
        {
            NotifyUser(args.Email, args.Message);
        }

        // Sends a notification to a user
        private void NotifyUser(string email, string message)
        {
            var user = users.FirstOrDefault(u => u.Email == email);
            user.ReceiveNotification(email, message);
        }
    }
}
