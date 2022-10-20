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
        }

        public TodoItem GetTodoById(Guid todoId)
        {
            return new TodoItem("Recuperado do Banco", DateTime.Now, "Gabriel Almeida");
        }

        public void Update(TodoItem todo)
        {
        }
    }
}