using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobRefactored
{
    public class NotificationService
    {
        // Define a delegate and an event
        public delegate void NotificationEventHandler(object source, NotificationEventArgs args);
        public event NotificationEventHandler NotificationSent;

        // Method to 'send' a notification
        public void SendNotification(string email, string message)
        {
            Console.WriteLine($"Preparing to send notification to {email}: {message}");
            OnNotificationSent(email, message);
        }

        // Method to raise the event
        protected virtual void OnNotificationSent(string email, string message)
        {
            NotificationSent?.Invoke(this, new NotificationEventArgs { Email = email, Message = message });
        }
    }
}
