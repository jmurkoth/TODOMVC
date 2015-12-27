using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoMVCRC1.Models
{
    public class HomeViewModel
    {
        public ToDoItem NewToDoITem { get; set; }
        public IEnumerable<ToDoItem> ToDoItems { get; set; }
    }
}
