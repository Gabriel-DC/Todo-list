using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void Create(TodoItem todo)
        {
            //TA TUDO CERTO
        }

        public bool DeleteTodo(Guid todoId, string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAll(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllUndone(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetByDate(string user, DateTime date, bool? done)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime initDate, DateTime finalDate, bool? done)
        {
            throw new NotImplementedException();
        }

        public TodoItem GetTodoById(Guid todoId, string user)
        {
            return new TodoItem("Recuperado do Banco", DateTime.Now, "Gabriel Almeida");
        }

        public void Update(TodoItem todo)
        {
            throw new NotImplementedException();
        }
    }
}