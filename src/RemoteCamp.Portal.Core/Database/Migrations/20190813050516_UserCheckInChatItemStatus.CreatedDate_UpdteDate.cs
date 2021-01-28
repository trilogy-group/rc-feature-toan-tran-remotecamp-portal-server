using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RemoteCamp.Portal.Core.Database.Migrations
{
    public partial class UserCheckInChatItemStatusCreatedDate_UpdteDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "UserCheckInChatItemStatus");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "UserCheckInChatItemStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "UserCheckInChatItemStatus",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "UserCheckInChatItemStatus");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "UserCheckInChatItemStatus");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "UserCheckInChatItemStatus",
                nullable: true);
        }
    }
}
