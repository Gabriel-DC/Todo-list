using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
        void Create(TodoItem todo);
        void Update(TodoItem todo);
        TodoItem? GetTodoById(Guid todoId);

        IEnumerable<TodoItem> GetAll(string user);
        IEnumerable<TodoItem> GetAllDone(string user);
        IEnumerable<TodoItem> GetAllUndone(string user);
        IEnumerable<TodoItem> GetByDate(string user, DateTime date, bool? done);
        IEnumerable<TodoItem> GetByPeriod(string user, DateTime initDate, DateTime finalDate, bool? done);
    }
}