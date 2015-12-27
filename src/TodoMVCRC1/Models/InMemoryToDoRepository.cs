using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoMVCRC1.Models
{
    public class InMemoryToDoRepository : IToDoRepository
    {
        private ConcurrentDictionary<int, ToDoItem> _todoItems;
        public InMemoryToDoRepository()
        {
            _todoItems = new ConcurrentDictionary<int,ToDoItem>();
            _todoItems.TryAdd(1,new ToDoItem { ID = 1, Title="very long long title" ,Description = "Test", CreatedBy = "jeevan", CreatedDate = DateTime.Now , IsComplete=true});
            _todoItems.TryAdd(2,new ToDoItem { ID = 2, Description = "Test1", CreatedBy = "jeevan", CreatedDate = DateTime.Now, IsComplete = false });
            _todoItems.TryAdd(3,new ToDoItem { ID = 3, Description = "Test2", CreatedBy = "jeevan", CreatedDate = DateTime.Now, IsComplete = true });
            _todoItems.TryAdd(4,new ToDoItem { ID = 4, Title="title", Description = "Test3", CreatedBy = "jeevan", CreatedDate = DateTime.Now, IsComplete = false });
            _todoItems.TryAdd(5,new ToDoItem { ID = 5, Description = "Test4", CreatedBy = "jeevan", CreatedDate = DateTime.Now, IsComplete = true });
            _todoItems.TryAdd(6,new ToDoItem { ID =6,  Title ="Title" ,Description = "Test5", CreatedBy = "jeevan", CreatedDate = DateTime.Now, IsComplete = false });
            _todoItems.TryAdd(7,new ToDoItem { ID = 7, Description = "Test6", CreatedBy = "jeevan", CreatedDate = DateTime.Now, IsComplete = true });
        }

        
        public void Update(ToDoItem item)
        {
            ToDoItem match = null;
             _todoItems.TryGetValue(item.ID, out match);
            if (match != null)
            {
                match.Description = item.Description;
                match.Title = item.Title;
                match.IsComplete = item.IsComplete;
                _todoItems[item.ID] = match;
            }
        }
        public void Add(ToDoItem item)
        {
           if(item!=null)
            {
                var maxidItem = _todoItems.Values.OrderByDescending(c => c.ID).FirstOrDefault();
                item.ID = (maxidItem== null?0 :maxidItem.ID ) + 1;
                _todoItems.TryAdd(item.ID , item);
            }
        }

        public void DeleteById(int Id)
        {
            ToDoItem match = null;
            _todoItems.TryRemove(Id, out match);
                     
        }

        public IEnumerable<ToDoItem> GetAll()
        {
            return _todoItems.Values.ToList();
        }

        public ToDoItem GetById(int Id)
        {
            ToDoItem match = null;
            _todoItems.TryGetValue(Id, out match) ;
            return match;
        }

        public IEnumerable<ToDoItem> GetCompleted()
        {
            return _todoItems.Values.Where(c => c.IsComplete == true);
        }

        public IEnumerable<ToDoItem> GetActive()
        {
            return _todoItems.Values.Where(c => c.IsComplete == false).ToList();
        }
    }
}
