using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Todo.Domain.Handlers.Contracts;

namespace Todo.Domain.Handlers
{
    public class Notification : INotification
    {
        public Notification()
        {
            _notifications = new ValidationResult();
            _notifications.Errors.Clear();
        }

        private ValidationResult _notifications { get; set; }

        public ReadOnlyCollection<ValidationFailure> Notifications => _notifications.Errors.AsReadOnly();

        public bool HasNotifications => _notifications?.Errors?.Count > 0;

        public void AddNotification(string propertyName, string message)
        {
            _notifications.Errors.Add(new ValidationFailure(propertyName, message));
        }

        public void AddNotification(string message)
        {
            _notifications.Errors.Add(new ValidationFailure(string.Empty, message));
        }

        public void AddNotifications(IEnumerable<ValidationFailure> notifications)
        {
            _notifications.Errors.AddRange(notifications);
        }

        public void AddNotifications(List<string> messages)
        {
            _notifications.Errors.AddRange(messages.Select(m => new ValidationFailure(string.Empty, m)));
        }

        public void AddNotifications(ValidationResult validationResult)
        {
            _notifications.Errors.AddRange(validationResult.Errors);
        }
    }
}