using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class UpdateTodoCommand : ICommand
    {
        public UpdateTodoCommand(string title, string user, DateTime date)
        {
            Title = title;
            User = user;
        }

        public Guid TodoId { get; set; }

        public string Title { get; set; }

        public string User { get; set; }

        public ValidationResult Validate() => new UpdateTodoCommandValidator().Validate(this);

        public sealed class UpdateTodoCommandValidator : AbstractValidator<UpdateTodoCommand>
        {
            public UpdateTodoCommandValidator()
            {
                RuleFor(r => r.TodoId)
                    .NotEmpty()
                    .WithMessage("Id inválido");

                RuleFor(r => r.Title)
                    .MinimumLength(3)
                    .WithMessage("O título deve conter pelo menos 3 caracteres")
                    .MaximumLength(10)
                    .WithMessage("O título não pode ultrapassar 10 caracteres");

                RuleFor(r => r.User)
                    .NotEmpty()
                    .WithMessage("Usuário inválido");
            }
        }
    }
}