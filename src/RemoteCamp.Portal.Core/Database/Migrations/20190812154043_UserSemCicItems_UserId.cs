using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RemoteCamp.Portal.Core.Database.Migrations
{
    public partial class UserSemCicItems_UserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCheckInChatItemsStatus");

            migrationBuilder.CreateTable(
                name: "UserCheckInChatItemStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Productivity = table.Column<bool>(nullable: true),
                    Quality = table.Column<bool>(nullable: true),
                    Comment = table.Column<string>(maxLength: 1000, nullable: true),
                    IsCompleted = table.Column<bool>(nullable: true),
                    UserCheckInChatItemId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCheckInChatItemStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCheckInChatItemStatus_UserCheckInChatItem_UserCheckInChatItemId",
                        column: x => x.UserCheckInChatItemId,
                        principalTable: "UserCheckInChatItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCheckInChatItemStatus_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCheckInChatItemStatus_UserCheckInChatItemId",
                table: "UserCheckInChatItemStatus",
                column: "UserCheckInChatItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCheckInChatItemStatus_UserId",
                table: "UserCheckInChatItemStatus",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCheckInChatItemStatus");

            migrationBuilder.CreateTable(
                name: "UserCheckInChatItemsStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(maxLength: 1000, nullable: true),
                    IsCompleted = table.Column<bool>(nullable: true),
                    Productivity = table.Column<bool>(nullable: true),
                    Quality = table.Column<bool>(nullable: true),
                    UserCheckInChatItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCheckInChatItemsStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCheckInChatItemsStatus_UserCheckInChatItem_UserCheckInChatItemId",
                        column: x => x.UserCheckInChatItemId,
                        principalTable: "UserCheckInChatItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCheckInChatItemsStatus_UserCheckInChatItemId",
                table: "UserCheckInChatItemsStatus",
                column: "UserCheckInChatItemId");
        }
    }
}
