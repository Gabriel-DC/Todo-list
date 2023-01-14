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
    IHandler<UpdateTodoCommand, ICommandResponse>,
    IHandler<MarkTodoAsDoneCommand, ICommandResponse>,
    IHandler<MarkTodoAsUndoneCommand, ICommandResponse>
    {
        private readonly ITodoRepository _repository;
        private readonly INotificationContext _notificationContext;

        public TodoHandler(ITodoRepository repository, INotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public ICommandResponse Handle(CreateTodoCommand command)
        {
            _notificationContext.AddNotifications(command.Validate());

            if (_notificationContext.HasNotifications)
                return new GenericCommandResponse(false, "Erros de validação", _notificationContext.Notifications);

            var todo = new TodoItem(command.Title!, command.Date!.Value, command.User!);

            _repository.Create(todo);

            return new GenericCommandResponse(true, "Tarefa salva", todo);
        }

        public ICommandResponse Handle(UpdateTodoCommand command)
        {
            _notificationContext.AddNotifications(command.Validate());

            if (_notificationContext.HasNotifications)
                return new GenericCommandResponse(false, "Erros de validação", _notificationContext.Notifications);

            var todo = _repository.GetTodoById(command.TodoId, command.User!);

            if (todo == null)
                return new GenericCommandResponse(false, "Tarefa não encontrada", null);

            todo.UpdateTitle(command.Title!);
            todo.UpdateDate(command.Date!.Value);

            _repository.Update(todo);

            return new GenericCommandResponse(true, "Tarefa Atualizada!", todo);
        }

        public ICommandResponse Handle(MarkTodoAsUndoneCommand command)
        {
            _notificationContext.AddNotifications(command.Validate());

            if (_notificationContext.HasNotifications)
                return new GenericCommandResponse(false, "Erros de validação", _notificationContext.Notifications);

            var todo = _repository.GetTodoById(command.TodoId, command.User!);            

            if (todo is null)
                return new GenericCommandResponse(false, "Item não encontrado", null);

            todo.MarkAsUndone();

            _repository.Update(todo);

            return new GenericCommandResponse(true, "Tarefa atualizada", todo);
        }

        public ICommandResponse Handle(MarkTodoAsDoneCommand command)
        {
            _notificationContext.AddNotifications(command.Validate());

            if (_notificationContext.HasNotifications)
                return new GenericCommandResponse(false, "Erros de validação", _notificationContext.Notifications);

            var todo = _repository.GetTodoById(command.TodoId, command.User!);

            if (todo is null)
                return new GenericCommandResponse(false, "Item não encontrado", null);

            todo.MarkAsDone();

            _repository.Update(todo);

            return new GenericCommandResponse(true, "Tarefa atualizada", todo);
        }
    }
}