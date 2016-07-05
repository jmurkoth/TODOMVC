using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Core.Models;
using ToDo.Core.Repos;

namespace ToDo.Core.Repos
{
    public class InMemoryToDoRepository : IToDoRepository
    {
        private ConcurrentDictionary<Guid, ToDoItem> _todoItems;
        public InMemoryToDoRepository()
        {
            _todoItems = new ConcurrentDictionary<Guid,ToDoItem>();
            Guid tmpId = Guid.NewGuid();
            _todoItems.TryAdd(tmpId,new ToDoItem { Id = tmpId, Title="very long long title" ,Description = "Test", CreatedBy = "jeevan", CreatedDate = DateTime.Now , IsComplete=true});
            tmpId = Guid.NewGuid();
            _todoItems.TryAdd(tmpId,new ToDoItem { Id = tmpId, Description = "Test1", CreatedBy = "jeevan", CreatedDate = DateTime.Now, IsComplete = false });
            tmpId = Guid.NewGuid();
            _todoItems.TryAdd(tmpId, new ToDoItem { Id = tmpId, Description = "Test2", CreatedBy = "jeevan", CreatedDate = DateTime.Now, IsComplete = true });
            tmpId = Guid.NewGuid();
            _todoItems.TryAdd(tmpId,new ToDoItem { Id = tmpId, Title="title", Description = "Test3", CreatedBy = "jeevan", CreatedDate = DateTime.Now, IsComplete = false });
            tmpId = Guid.NewGuid();
            _todoItems.TryAdd(tmpId, new ToDoItem { Id = tmpId, Description = "Test4", CreatedBy = "jeevan", CreatedDate = DateTime.Now, IsComplete = true });
            tmpId = Guid.NewGuid();
            _todoItems.TryAdd(tmpId, new ToDoItem { Id = tmpId,  Title ="Title" ,Description = "Test5", CreatedBy = "jeevan", CreatedDate = DateTime.Now, IsComplete = false });
            tmpId = Guid.NewGuid();
            _todoItems.TryAdd(tmpId, new ToDoItem { Id = tmpId, Description = "Test6", CreatedBy = "jeevan", CreatedDate = DateTime.Now, IsComplete = true });
        }

        
        public void Update(ToDoItem item)
        {
            ToDoItem match = null;
            _todoItems.TryGetValue(item.Id, out match);
            if (match != null)
            {
                match.Description = item.Description;
                match.Title = item.Title;
                match.IsComplete = item.IsComplete;
                _todoItems[item.Id] = match;
            }
        }
        public void Add(ToDoItem item)
        {
            if (item != null)
            {
                var guid= Guid.NewGuid();
                item.Id = guid;
                _todoItems.TryAdd(guid, item);
            }
        }

        public void DeleteById(Guid Id)
        {
            ToDoItem match = null;
            var success = _todoItems.TryRemove(Id, out match);
        }

        public IEnumerable<ToDoItem> GetAll(string userName)
        {
            return _todoItems.Values.ToList();
        }

        public ToDoItem GetById(Guid Id)
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
