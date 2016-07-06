using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Core.Service;

namespace Todo.MVC.Services
{
    public class UserService : IUserService
    {
        private IHttpContextAccessor _context;
        public UserService(IHttpContextAccessor context)
        {
            _context = context;
        }
        public string UserName
        {
            get
            {
                return _context.HttpContext.User?.Identity?.Name;
            }

   
        }
    }
}
