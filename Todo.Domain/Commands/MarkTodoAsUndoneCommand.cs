using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class MarkTodoAsUndoneCommand : ICommand
    {
        public MarkTodoAsUndoneCommand(Guid todoId)
        {
            TodoId = todoId;            
        }

        public Guid TodoId { get; set; }

        public string? User { get; set; }

        public ValidationResult Validate() => new MarkTodoAsUndoneCommandValidator().Validate(this);

        public sealed class MarkTodoAsUndoneCommandValidator : AbstractValidator<MarkTodoAsUndoneCommand>
        {
            public MarkTodoAsUndoneCommandValidator()
            {
                RuleFor(r => r.TodoId)
                    .NotEmpty()
                    .WithMessage("Id inválido");

                RuleFor(r => r.User)
                    .NotEmpty()
                    .WithMessage("Usuário inválido");
            }
        }
    }
}