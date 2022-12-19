using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Handlers.Contracts
{
    public interface IHandler<in T, out T2>
    where T : ICommand
    where T2 : ICommandResponse
    {
        T2 Handle(T command);
    }
}