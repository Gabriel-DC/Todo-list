using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class GenericCommandResponse : ICommandResponse
    {
        public GenericCommandResponse() { }

        public GenericCommandResponse(bool success, string? message, object? data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}