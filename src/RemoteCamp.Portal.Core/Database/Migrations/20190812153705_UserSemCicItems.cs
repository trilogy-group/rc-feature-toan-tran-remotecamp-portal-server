using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RemoteCamp.Portal.Core.Database.Migrations
{
    public partial class UserSemCicItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserCheckInChatItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WeekNumber = table.Column<int>(nullable: false),
                    Day = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCheckInChatItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserCheckInChatItemsStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Productivity = table.Column<bool>(nullable: true),
                    Quality = table.Column<bool>(nullable: true),
                    Comment = table.Column<string>(maxLength: 1000, nullable: true),
                    IsCompleted = table.Column<bool>(nullable: true),
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

            migrationBuilder.InsertData(
                table: "UserCheckInChatItem",
                columns: new[] { "Id", "Day", "WeekNumber" },
                values: new object[,]
                {
                    { 1, "Mon", 1 },
                    { 18, "Wed", 4 },
                    { 17, "Tue", 4 },
                    { 16, "Mon", 4 },
                    { 15, "Fri", 3 },
                    { 14, "Thurs", 3 },
                    { 13, "Wed", 3 },
                    { 12, "Tue", 3 },
                    { 11, "Mon", 3 },
                    { 10, "Fri", 2 },
                    { 9, "Thurs", 2 },
                    { 8, "Wed", 2 },
                    { 7, "Tue", 2 },
                    { 6, "Mon", 2 },
                    { 5, "Fri", 1 },
                    { 4, "Thurs", 1 },
                    { 3, "Wed", 1 },
                    { 2, "Tue", 1 },
                    { 19, "Thurs", 4 },
                    { 20, "Fri", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCheckInChatItemsStatus_UserCheckInChatItemId",
                table: "UserCheckInChatItemsStatus",
                column: "UserCheckInChatItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCheckInChatItemsStatus");

            migrationBuilder.DropTable(
                name: "UserCheckInChatItem");
        }
    }
}
