using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ToDo.Core.Migrations
{
    public partial class ModelIdChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "ToDoItem",
                nullable: false);
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ToDoItem",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ToDoItem",
                nullable: false)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ToDoItem",
                newName: "ID");
        }
    }
}
