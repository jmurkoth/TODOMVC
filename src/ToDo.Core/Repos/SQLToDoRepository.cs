using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Core.EF;
using ToDo.Core.Models;
using ToDo.Core.Service;

namespace ToDo.Core.Repos
{
    public class SQLToDoRepository : IToDoRepository
    {
        private ToDoDataContext _context;
        private string _userName;
        public SQLToDoRepository(ToDoDataContext context, IUserService userService)
        {
            _context = context;
            _userName = userService?.UserName;
        }
        public void Add(ToDoItem item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void DeleteById(Guid Id)
        {
            var match = _context.ToDoItems.FirstOrDefault(c => c.Id == Id);
            if(match!=null && match.CreatedBy.Equals(this._userName, StringComparison.OrdinalIgnoreCase))
            {
                _context.Remove(match);
                _context.SaveChanges();
            }
        }

        public IEnumerable<ToDoItem> GetActive()
        {
            return _context.ToDoItems.Where(c => c.IsComplete != true && c.CreatedBy.Equals(this._userName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public IEnumerable<ToDoItem> GetAll()
        {
            return _context.ToDoItems.Where(c=> c.CreatedBy.Equals(this._userName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public ToDoItem GetById(Guid Id)
        {
            return _context.ToDoItems.FirstOrDefault(c => c.Id == Id &&   c.CreatedBy.Equals(this._userName, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<ToDoItem> GetCompleted()
        {
            return _context.ToDoItems.Where(c => c.IsComplete ==true && c.CreatedBy.Equals(this._userName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void Update(ToDoItem item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }
    }
}
