using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoMVCRC1.Models
{
    public class InMemoryToDoRepository : IToDoRepository
    {
        private List<ToDoItem> _todoItems;
        public InMemoryToDoRepository()
        {
            _todoItems = new List<ToDoItem>();
            _todoItems.Add(new ToDoItem { ID = 1, Title="very long long title" ,Description = "Test", CreatedBy = "jeevan", CreatedDate = DateTime.Now , IsComplete=true});
            _todoItems.Add(new ToDoItem { ID = 2, Description = "Test1", CreatedBy = "jeevan", CreatedDate = DateTime.Now, IsComplete = false });
            _todoItems.Add(new ToDoItem { ID = 3, Description = "Test2", CreatedBy = "jeevan", CreatedDate = DateTime.Now, IsComplete = true });
            _todoItems.Add(new ToDoItem { ID = 4, Title="title", Description = "Test3", CreatedBy = "jeevan", CreatedDate = DateTime.Now, IsComplete = false });
            _todoItems.Add(new ToDoItem { ID = 5, Description = "Test4", CreatedBy = "jeevan", CreatedDate = DateTime.Now, IsComplete = true });
            _todoItems.Add(new ToDoItem { ID =6,  Title ="Title" ,Description = "Test5", CreatedBy = "jeevan", CreatedDate = DateTime.Now, IsComplete = false });
            _todoItems.Add(new ToDoItem { ID = 7, Description = "Test6", CreatedBy = "jeevan", CreatedDate = DateTime.Now, IsComplete = true });
        }

        
        public void Update(ToDoItem item)
        {
            var match = _todoItems.FirstOrDefault(c => c.ID == item.ID);
            if (item != null)
            {
               match.Description = item.Description;
               match.Title = item.Title;
                match.IsComplete = item.IsComplete;
            }
        }
        public void Add(ToDoItem item)
        {
           if(item!=null)
            {
                var maxidItem = _todoItems.OrderByDescending(c => c.ID).FirstOrDefault();
                item.ID = (maxidItem== null?0 :maxidItem.ID ) + 1;
                _todoItems.Add(item);
            }
        }

        public void DeleteById(int Id)
        {
            var item = _todoItems.FirstOrDefault(c => c.ID == Id);
            if(item!=null)
            {
                _todoItems.Remove(item);
            }
          
        }

        public IList<ToDoItem> GetAll()
        {
            return _todoItems;
        }

        public ToDoItem GetById(int Id)
        {
          return _todoItems.FirstOrDefault(c => c.ID == Id);
        }

        public IList<ToDoItem> GetCompleted()
        {
            return _todoItems.Where(c => c.IsComplete == true).ToList();
        }

        public IList<ToDoItem> GetActive()
        {
            return _todoItems.Where(c => c.IsComplete == false).ToList();
        }
    }
}
