using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.MVC.ViewModels
{
    public class EditViewModel
    {
        public ToDoViewModel Item { get; set; }
        public string Referrer { get; set; }
    }
}
