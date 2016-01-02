using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Core.Models;

namespace TodoMVCRC1.ViewModels
{
    public class HomeViewModel
    {
        public ToDoItem NewToDoITem { get; set; }
        public IEnumerable<ToDoItem> ToDoItems { get; set; }
    }
}
