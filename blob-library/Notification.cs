using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blob_library
{
    internal class Notification
    {
        public string Message { get; private set; }
        public DateTime Timestamp { get; private set; }

        public Notification(string message)
        {
            Message = message;
            Timestamp = DateTime.Now;
        }
    }
}
