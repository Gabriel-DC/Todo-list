using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler :
    IHandler<CreateTodoCommand, ICommandResponse>,
    IHandler<UpdateTodoCommand, ICommandResponse>
    {
        private readonly ITodoRepository _repository;
        private readonly INotification _notificationContext;

        public TodoHandler(ITodoRepository repository, INotification notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public ICommandResponse Handle(CreateTodoCommand command)
        {
            _notificationContext.AddNotifications(command.Validate());

            if (_notificationContext.HasNotifications)
                return new GenericCommandResponse(false, "Erros de validação", _notificationContext.Notifications);

            var todo = new TodoItem(command.Title, command.Date, command.User);

            _repository.Create(todo);

            return new GenericCommandResponse(true, "Tarefa salva", todo);
        }

        public ICommandResponse Handle(UpdateTodoCommand command)
        {
            throw new NotImplementedException("Sossega ae");

            //_notificationContext.AddNotifications(command.Validate());

            // if (_notificationContext.HasNotifications)
            //     return new GenericCommandResponse(false, "Erros de validação", _notificationContext.Notifications.Errors);

            //var todo = _repository//GetById(command.id);
        }
    }
}