using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoMVCRC1.Models
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
