using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blob_library
{
    internal class UserManager
    {
        private List<User> users = new List<User>();
        private Dictionary<string, Settings> userSettings = new Dictionary<string, Settings>();
        private Dictionary<string, List<Notification>> userNotifications = new Dictionary<string, List<Notification>>();

        public void AddUser(string name, string email, string password)
        {
            var user = new User(name, email, password);
            users.Add(user);
            userNotifications[email] = new List<Notification>();
            Console.WriteLine("User added successfully.");
        }

        public void DisplayUsers()
        {
            foreach (var user in users)
            {
                user.DisplayUserInfo();
            }
        }

        public void UpdateUserSettings(string email, bool receiveNotifications, string theme)
        {
            var user = users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                if (userSettings.ContainsKey(email))
                {
                    userSettings[email].UpdateNotifications(receiveNotifications);
                    userSettings[email].UpdateTheme(theme);
                }
                else
                {
                    var settings = new Settings(receiveNotifications, theme);
                    userSettings.Add(email, settings);
                }
                Console.WriteLine("User settings updated.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        public void DisplayUserSettings(string email)
        {
            if (userSettings.ContainsKey(email))
            {
                userSettings[email].DisplaySettings();
            }
            else
            {
                Console.WriteLine("Settings not found for this user.");
            }
        }

        public void SubscribeUserToNotifications(string email)
        {
            if (!userNotifications.ContainsKey(email))
            {
                userNotifications[email] = new List<Notification>();
            }
            Console.WriteLine($"{email} subscribed to notifications.");
        }

        public void SendNotificationToUser(string email, string message)
        {
            if (userNotifications.ContainsKey(email))
            {
                var notification = new Notification(message);
                userNotifications[email].Add(notification);
                Console.WriteLine($"Notification sent to {email}: {message}");
            }
            else
            {
                Console.WriteLine("User not found or not subscribed to notifications.");
            }
        }

        public void DisplayAllNotificationsForUser(string email)
        {
            if (userNotifications.ContainsKey(email) && userNotifications[email].Count > 0)
            {
                foreach (var notification in userNotifications[email])
                {
                    Console.WriteLine($"Notification: {notification.Message}, Time: {notification.Timestamp}");
                }
            }
            else
            {
                Console.WriteLine("No notifications found for this user.");
            }
        }
    }
}
