using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RemoteCamp.Portal.Core.Database.Migrations
{
    public partial class RT2940_Remove_RcXoId_From_Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RcXoId",
                table: "Users",
                nullable: true);
            
            migrationBuilder.RenameColumn(
                name: "RcXoId",
                table: "Users",
                newName: "_Old_RcXoId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            throw new NotSupportedException();
        }
    }
}
