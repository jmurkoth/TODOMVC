using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoMVCRC1.Models
{
    public class ToDoViewModel
    {
        public int? ID { get; set; }
        [MaxLength(25, ErrorMessage = "cannot be more than 25 char")]
        public string Title { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public bool IsComplete { get; set; }
    }
}
