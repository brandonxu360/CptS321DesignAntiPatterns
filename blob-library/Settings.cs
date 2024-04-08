using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blob_library
{
    internal class Settings
    {
        public bool ReceiveNotifications { get; private set; }
        public string Theme { get; private set; }

        public Settings(bool receiveNotifications, string theme)
        {
            ReceiveNotifications = receiveNotifications;
            Theme = theme;
        }

        public void UpdateNotifications(bool receiveNotifications)
        {
            ReceiveNotifications = receiveNotifications;
            Console.WriteLine($"Notification settings updated: {(ReceiveNotifications ? "On" : "Off")}");
        }

        public void UpdateTheme(string theme)
        {
            Theme = theme;
            Console.WriteLine($"Theme updated to: {Theme}");
        }

        public void DisplaySettings()
        {
            Console.WriteLine($"Notifications: {(ReceiveNotifications ? "On" : "Off")}, Theme: {Theme}");
        }
    }
}
