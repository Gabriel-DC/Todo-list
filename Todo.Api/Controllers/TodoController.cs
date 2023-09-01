using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
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
        private readonly ITodoRepository _todoRepository;
        
        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        
        [HttpGet("today")]
        public IEnumerable<TodoItem> GetTodayTodos()
        {
            string user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value!;

            return _todoRepository.GetByDate(user, DateTime.Now, null);
        }

        [HttpGet("tomorrow")]
        public IEnumerable<TodoItem> GetTomorrowTodos()
        {
            string user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value!;

            return _todoRepository.GetByDate(user, DateTime.Now.AddDays(1), null);
        }

        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            string user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value!;
            return _todoRepository.GetAll(user);
        }

        [HttpGet("done")]
        public IEnumerable<TodoItem> GetAllDone()
        {
            string user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value!;
            return _todoRepository.GetAllDone(user);
        }

        [HttpGet("undone")]
        public IEnumerable<TodoItem> GetAllUndone()
        {
            string user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value!;
            return _todoRepository.GetAllUndone(user);
        }

        [HttpGet("date/{date}")]
        public IEnumerable<TodoItem> GetAllByDate(
            DateTime date,
            [FromQuery] bool? done)
        {
            string user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value!;
            return _todoRepository.GetByDate(user,date.Date,done);
        }

        [HttpGet("period/{startDate}/{endDate}")]
        public IEnumerable<TodoItem> GetAllByPeriod(
            DateTime startDate,
            DateTime endDate,
            [FromQuery] bool? done)
        {
            string user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value!;
            return _todoRepository.GetByPeriod(user, startDate.Date, endDate.Date, done);
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

        [HttpDelete("{id}")]
        public GenericCommandResponse DeleteTodo(Guid id)
        {
            string user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value!;

            bool deleted = _todoRepository.DeleteTodo(id, user);

            return new GenericCommandResponse(
                deleted,
                deleted ? "Deletado com sucesso!" : "Falha ao deletar item",
                null
            );
        }
    }
}
