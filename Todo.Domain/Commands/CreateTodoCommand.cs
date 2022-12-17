using FluentValidation;
using FluentValidation.Results;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class CreateTodoCommand : ICommand
    {
        public CreateTodoCommand(string title, DateTime date)
        {
            Title = title;
            Date = date;
        }

        public string? Title { get; set; }

        public string? User { get; set; }

        public DateTime? Date { get; set; }

        public ValidationResult Validate() => new CreateTodoCommandValidator().Validate(this);

        public sealed class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
        {
            public CreateTodoCommandValidator()
            {
                RuleFor(r => r.Title)
                    .MinimumLength(3)
                    .WithMessage("O título deve conter pelo menos 3 caracteres")
                    .MaximumLength(120)
                    .WithMessage("O título não pode ultrapassar 120 caracteres");

                RuleFor(r => r.User)
                    .NotEmpty()
                    .WithMessage("Usuário inválido");

                RuleFor(r => r.Date)
                    .NotEmpty()
                    .WithMessage("Data inválida")
                    .GreaterThan(DateTime.Now.AddDays(-1))
                    .WithMessage("Data inválida");
            }
        }
    }
}