using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace ToDo.Core.Migrations
{
    public partial class UpdTracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ToDoItem",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "UpdatedBy", table: "ToDoItem");
        }
    }
}
