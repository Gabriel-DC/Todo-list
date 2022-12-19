using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;
using Todo.Infra.Context;

namespace Todo.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _dataContext;

        public TodoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Create(TodoItem todo)
        {
            _dataContext.Todos.Add(todo);
            _dataContext.SaveChanges();
        }

        public IEnumerable<TodoItem> GetAll(string user)
        {
            return _dataContext.Todos.AsNoTracking()
                .Where(TodoQueries.GetAll(user))
                .OrderBy(t => t.Date);
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            return _dataContext.Todos.AsNoTracking()
                .Where(TodoQueries.GetAllDone(user))
                .OrderBy(t => t.Date);
        }

        public IEnumerable<TodoItem> GetAllUndone(string user)
        {
            return _dataContext.Todos.AsNoTracking()
                .Where(TodoQueries.GetAllUndone(user))
                .OrderBy(t => t.Date);
        }

        public IEnumerable<TodoItem> GetByDate(string user, DateTime date, bool? done)
        {
            return _dataContext.Todos.AsNoTracking()
                .Where(TodoQueries.GetByDate(user, date, done))
                .OrderBy(t => t.Date);
        }

        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime initDate, DateTime finalDate, bool? done)
        {
            return _dataContext.Todos.AsNoTracking()
                .Where(TodoQueries.GetByPeriod(user, initDate, finalDate, done))
                .OrderBy(t => t.Date);
        }

        public TodoItem? GetTodoById(Guid todoId, string user)
        {
            return _dataContext.Todos.FirstOrDefault(TodoQueries.GetById(todoId, user));
        }

        public void Update(TodoItem todo)
        {
            _dataContext.Entry(todo).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }

        public bool DeleteTodo(Guid todoId, string user)
        {
            var todoItem = _dataContext.Todos.FirstOrDefault(t => t.Id == todoId && t.User == user);

            if (todoItem is null)
                return false;

            _dataContext.Remove(todoItem);

            _dataContext.SaveChanges();

            return true;
        }
    }
}
