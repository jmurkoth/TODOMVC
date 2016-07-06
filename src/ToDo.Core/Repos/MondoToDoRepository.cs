using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Core.Models;
using ToDo.Core.MondoDB;
using ToDo.Core.Service;

namespace ToDo.Core.Repos
{
    public class MongoToDoRepository : IToDoRepository
    {
        private MongoContext _context;
        private string _userName;
        public MongoToDoRepository(MongoContext context, IUserService userService)
        {
            _context = context;
            _userName = userService?.UserName;
        }
        public void Add(ToDoItem item)
        {
            _context.Add(item);
        }

        public void DeleteById(Guid Id)
        {
            ToDoItem match = _context.FindById(Id);
            if(match!=null && match.CreatedBy.Equals(this._userName, StringComparison.OrdinalIgnoreCase))
            {
                _context.Remove(match);
            }
        }

        public IEnumerable<ToDoItem> GetActive()
        {
            return _context.GetActive();
        }

        public IEnumerable<ToDoItem> GetAll( )
        {
            return _context.GetAll();
        }

        public ToDoItem GetById(Guid Id)
        {
            return _context.FindById(Id);
        }

        public IEnumerable<ToDoItem> GetCompleted()
        {
            return _context.GetCompleted();
        }

        public void Update(ToDoItem item)
        {
            _context.Update(item);
        }
    }
}
