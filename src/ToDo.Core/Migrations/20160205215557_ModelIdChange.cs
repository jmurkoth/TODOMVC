using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

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
