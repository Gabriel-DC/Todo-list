using FluentValidation;
using FluentValidation.Results;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class MarkTodoAsDoneCommand : ICommand
    {
        public MarkTodoAsDoneCommand(Guid todoId, string user)
        {
            TodoId = todoId;
            User = user;
        }

        public Guid TodoId { get; set; }
        public string User { get; set; }

        public ValidationResult Validate() => new MarkTodoAsDoneCommandValidator().Validate(this);

        public sealed class MarkTodoAsDoneCommandValidator : AbstractValidator<MarkTodoAsDoneCommand>
        {
            public MarkTodoAsDoneCommandValidator()
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