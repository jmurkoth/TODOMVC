using System;

using System.ComponentModel.DataAnnotations;
namespace ToDo.Core.Models
{
    public class ToDoItem
    {
        [Key]
        public Guid  Id { get; set; }
        [MaxLength(25,ErrorMessage ="cannot be more than 25 char")]
        public string Title { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage ="Description is required")]
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
