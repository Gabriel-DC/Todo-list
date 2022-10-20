using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Todo.Domain.Handlers.Contracts
{
    public interface INotification
    {
        public ReadOnlyCollection<Notification> Notifications { get; }
        void AddNotification(string propertyName, string message);
        void AddNotification(string message);
        void AddNotifications(IEnumerable<ValidationFailure> notifications);
        void AddNotifications(List<string> messages);
        public bool HasNotifications { get; }
        void AddNotifications(ValidationResult validationResult);
    }
}