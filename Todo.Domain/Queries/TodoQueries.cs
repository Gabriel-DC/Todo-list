using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Domain.Queries
{
    public static class TodoQueries
    {
        public static Expression<Func<TodoItem, bool>> GetAll(string user)
        {
            return x => x.User == user;
        }

        public static Expression<Func<TodoItem, bool>> GetAllDone(string user)
        {
            return x => x.User == user && x.Done;
        }

        public static Expression<Func<TodoItem, bool>> GetAllUndone(string user)
        {
            return x => x.User == user && !x.Done;
        }

        public static Expression<Func<TodoItem, bool>> GetByDate(string user, DateTime date, bool? done = null)
        {
            return x => x.User == user
                && (!done.HasValue || x.Done == done)
                && x.Date.Date == date.Date;
        }

        public static Expression<Func<TodoItem, bool>> GetByPeriod(string user, DateTime initDate, DateTime finalDate, bool? done = null)
        {
            return x => x.User == user
                && (!done.HasValue || x.Done == done)
                && x.Date.Date >= initDate.Date
                && x.Date.Date <= finalDate.Date;
        }

        public static Expression<Func<TodoItem, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
