using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using ToDo.Core.Models;
namespace ToDo.Core.EF
{
    public class ToDoDataContext:DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public ToDoDataContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "";
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
