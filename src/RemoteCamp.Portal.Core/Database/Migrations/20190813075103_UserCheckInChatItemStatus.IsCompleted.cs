using Microsoft.EntityFrameworkCore.Migrations;

namespace RemoteCamp.Portal.Core.Database.Migrations
{
    public partial class UserCheckInChatItemStatusIsCompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "UserCheckInChatItemStatus",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "UserCheckInChatItemStatus");
        }
    }
}
