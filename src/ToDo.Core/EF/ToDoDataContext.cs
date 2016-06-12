using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ToDo.Core.EF
{
    public class ToDoDataContext: IdentityDbContext<ApplicationUser>
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }

        public ToDoDataContext(DbContextOptions<ToDoDataContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }
    }
}
