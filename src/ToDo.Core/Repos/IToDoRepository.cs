using System.Collections.Generic;
using System;
using ToDo.Core.Models;

namespace ToDo.Core.Repos
{
    public interface IToDoRepository
    {
        void Update(ToDoItem item);
        IEnumerable<ToDoItem> GetAll();
        ToDoItem GetById(Guid Id);
        IEnumerable<ToDoItem> GetCompleted();
        IEnumerable<ToDoItem> GetActive();
        void DeleteById(Guid Id);
        void Add(ToDoItem item);


    }
}
