using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    [Authorize]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<TodoItem> GetAll(
            [FromServices] ITodoRepository repository)
        {
            string user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value!;
            return repository.GetAll(user!);
        }

        [HttpGet("done")]
        public IEnumerable<TodoItem> GetAllDone(
            [FromServices] ITodoRepository repository)
        {
            string user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value!;
            return repository.GetAllDone(user);
        }

        [HttpGet("undone")]
        public IEnumerable<TodoItem> GetAllUndone(
            [FromServices] ITodoRepository repository)
        {
            string user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value!;
            return repository.GetAllUndone(user);
        }

        [HttpGet("date/{date}")]
        public IEnumerable<TodoItem> GetAllByDate(
            DateTime date,
            [FromQuery] bool? done,
            [FromServices] ITodoRepository repository)
        {
            string user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value!;
            return repository.GetByDate(user,date.Date,done);
        }

        [HttpGet("period/{date}/{date2}")]
        public IEnumerable<TodoItem> GetAllByDate(
            DateTime date,
            DateTime date2,
            [FromQuery] bool? done,
            [FromServices] ITodoRepository repository)
        {
            string user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value!;
            return repository.GetByPeriod(user, date.Date, date2.Date, done);
        }

        [HttpPost]
        public GenericCommandResponse CreateTodo(
            [FromBody] CreateTodoCommand command,
            [FromServices] TodoHandler handler)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value!;
            return (GenericCommandResponse)handler.Handle(command);
        }

        [HttpPut]
        public GenericCommandResponse Update(
            [FromBody] UpdateTodoCommand command,
            [FromServices] TodoHandler handler)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value!;
            return (GenericCommandResponse)handler.Handle(command);
        } 


        [HttpPatch("mark-as-done")]
        public GenericCommandResponse MarkAsDone(
            [FromBody] MarkTodoAsDoneCommand command,
            [FromServices] TodoHandler handler)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value!;
            return (GenericCommandResponse)handler.Handle(command);
        }


        [HttpPatch("mark-as-undone")]
        public GenericCommandResponse MarkAsUndone(
            [FromBody] MarkTodoAsUndoneCommand command,
            [FromServices] TodoHandler handler)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value!;
            return (GenericCommandResponse)handler.Handle(command);
        }
    }
}
