using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Core.EF;
using ToDo.Core.Models;

namespace ToDo.Core.Repos
{
    public class SQLToDoRepository : IToDoRepository
    {
        private ToDoDataContext _context;
        public SQLToDoRepository(ToDoDataContext context)
        {
            _context = context;
        }
        public void Add(ToDoItem item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void DeleteById(int Id)
        {
            var match = _context.ToDoItems.FirstOrDefault(c => c.ID == Id);
            if(match!=null)
            {
                _context.Remove(match);
                _context.SaveChanges();
            }
        }

        public IEnumerable<ToDoItem> GetActive()
        {
            return _context.ToDoItems.Where(c => c.IsComplete != true).ToList();
        }

        public IEnumerable<ToDoItem> GetAll()
        {
            return _context.ToDoItems.ToList();
        }

        public ToDoItem GetById(int Id)
        {
            return _context.ToDoItems.FirstOrDefault(c => c.ID == Id);
        }

        public IEnumerable<ToDoItem> GetCompleted()
        {
            return _context.ToDoItems.Where(c => c.IsComplete ==true).ToList();
        }

        public void Update(ToDoItem item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }
    }
}
