using System.Collections.ObjectModel;
using FluentValidation.Results;

namespace Todo.Domain.Handlers.Contracts
{
    public interface INotificationContext
    {
        public ReadOnlyCollection<Notification> Notifications { get; }
        void AddNotification(string propertyName, string message);
        void AddNotification(string message);
        void AddNotifications(ValidationResult validationResult);
        void AddNotifications(List<string> messages);
        void AddNotifications(IEnumerable<ValidationFailure> notifications);
        public bool HasNotifications { get; }
    }
}