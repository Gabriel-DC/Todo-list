using System;
using System.Collections.Generic;

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
            Notifications = new ValidationResult();
            Notifications.Errors.Clear();
        }

        public ValidationResult Notifications { get; set; }

        public bool HasNotifications => Notifications?.Errors?.Count > 0;

        public void AddNotification(string propertyName, string message)
        {
            Notifications.Errors.Add(new ValidationFailure(propertyName, message));
        }

        public void AddNotification(string message)
        {
            Notifications.Errors.Add(new ValidationFailure(string.Empty, message));
        }

        public void AddNotifications(IEnumerable<ValidationFailure> notifications)
        {
            Notifications.Errors.AddRange(notifications);
        }

        public void AddNotifications(List<string> messages)
        {
            Notifications.Errors.AddRange(messages.Select(m => new ValidationFailure(string.Empty, m)));
        }

        public void AddNotifications(ValidationResult validationResult)
        {
            Notifications.Errors.AddRange(validationResult.Errors);
        }
    }
}