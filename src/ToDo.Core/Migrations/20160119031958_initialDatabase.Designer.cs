using System;
using ToDo.Core.EF;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ToDo.Core.Migrations
{
    [DbContext(typeof(ToDoDataContext))]
    [Migration("20160119031958_initialDatabase")]
    partial class initialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ToDo.Core.Models.ToDoItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<bool>("IsComplete");

                    b.Property<string>("Title")
                        .HasAnnotation("MaxLength", 25);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("ID");
                });
        }
    }
}
