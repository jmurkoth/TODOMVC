using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
namespace TodoMVCRC1.Models
{
    public class ToDoItem
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(25, ErrorMessageResourceName = "Msg_Title_Len", ErrorMessageResourceType = typeof(TodoMVCRC1.Resources.TodoMVCRC1_Resources_todo))]
        public string Title { get; set; }
        [Required(AllowEmptyStrings =false,  ErrorMessageResourceName = "Msg_Desc_Req", ErrorMessageResourceType =typeof(TodoMVCRC1.Resources.TodoMVCRC1_Resources_todo))]
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
