using FluentValidation.Results;

namespace Todo.Domain.Commands.Contracts
{
    public interface ICommand
    {
        ValidationResult Validate();
    }
}