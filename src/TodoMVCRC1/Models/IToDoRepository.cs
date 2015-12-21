using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoMVCRC1.Models
{
    public interface IToDoRepository
    {
        void Update(ToDoItem item);
        IList<ToDoItem> GetAll();
        ToDoItem GetById(int Id);
        IList<ToDoItem> GetCompleted();
        IList<ToDoItem> GetActive();
        void DeleteById(int Id);
        void Add(ToDoItem item);


    }
}
