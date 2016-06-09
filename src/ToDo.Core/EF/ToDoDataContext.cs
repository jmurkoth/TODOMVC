using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ToDo.Core.EF
{
    public class ToDoDataContext:DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public ToDoDataContext(DbContextOptions<ToDoDataContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connectionString = "";
        //    optionsBuilder.UseSqlServer(connectionString);
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
