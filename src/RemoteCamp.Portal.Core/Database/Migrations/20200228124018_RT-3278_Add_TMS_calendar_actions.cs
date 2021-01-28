using Microsoft.EntityFrameworkCore.Migrations;

namespace RemoteCamp.Portal.Core.Database.Migrations
{
    public partial class RT3278_Add_TMS_calendar_actions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 333,
                column: "Duration",
                value: 450);

            migrationBuilder.InsertData(
                table: "UserCalendarItemActions",
                columns: new[] { "Id", "AdditionalUrl", "Description", "Duration", "IsDeleted", "Position", "Url", "UserCalendarItemId" },
                values: new object[] { 392, null, "Record a TMS video while producing a unit", 0, false, 4, "", 39 });

            migrationBuilder.InsertData(
                table: "UserCalendarItemActions",
                columns: new[] { "Id", "AdditionalUrl", "Description", "Duration", "IsDeleted", "Position", "Url", "UserCalendarItemId" },
                values: new object[] { 393, null, "Analyze TMS and compare with the previous week to identify the improvement after tool investigation, automation idea implementation and fixing knowledge gap; document the change in Deck", 30, false, 5, "", 39 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 392);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 393);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 333,
                column: "Duration",
                value: 480);
        }
    }
}
