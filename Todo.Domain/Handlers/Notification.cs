using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Handlers
{
    public class Notification
    {
        public Notification(string? propertyName, string message)
        {
            PropertyName = propertyName;
            Message = message;
        }

        public string? PropertyName { get; }
        public string Message { get; }
    }
}
