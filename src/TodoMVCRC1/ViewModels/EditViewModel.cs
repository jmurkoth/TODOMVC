using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoMVCRC1.Models
{
    public class EditViewModel
    {
        public ToDoViewModel Item { get; set; }
        public string Referrer { get; set; }
    }
}
