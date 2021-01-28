using Microsoft.EntityFrameworkCore.Migrations;

namespace RemoteCamp.Portal.Core.Database.Migrations
{
    public partial class RT2900_Update_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 298,
                column: "Url",
                value: "https://docs.google.com/forms/d/e/1FAIpQLScAZm0PCkwy0OcxXxRLAery7D5DQSLqgVN-V2vIMWry_wa6oA/viewform");

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 305,
                column: "Description",
                value: "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 298,
                column: "Url",
                value: "");

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 305,
                column: "Description",
                value: "Prepare for CiC: Check the results of your submissions. Identify the hardest problem. Get review for automation idea slide.");
        }
    }
}
