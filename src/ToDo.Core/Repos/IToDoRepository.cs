using System.Collections.Generic;
using ToDo.Core.Models;

namespace ToDo.Core.Repos
{
    public interface IToDoRepository
    {
        void Update(ToDoItem item);
        IEnumerable<ToDoItem> GetAll();
        ToDoItem GetById(int Id);
        IEnumerable<ToDoItem> GetCompleted();
        IEnumerable<ToDoItem> GetActive();
        void DeleteById(int Id);
        void Add(ToDoItem item);


    }
}
