using Microsoft.EntityFrameworkCore.Migrations;

namespace RemoteCamp.Portal.Core.Database.Migrations
{
    public partial class UserCalendarItemHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "UserCalendarItems",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Header",
                value: "Productivity vs.week1 increased + 25%");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "Header",
                value: "Productivity vs.week1 increased + 25%");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "Header",
                value: "Productivity vs.week1 increased + 25%");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "Header",
                value: "Productivity vs.week1 increased + 25%");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "Header",
                value: "Productivity vs.week1 increased + 25%");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "Header",
                value: "Productivity vs.week2 increased + 25%");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "Header",
                value: "Productivity vs.week2 increased + 25%");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "Header",
                value: "Productivity vs.week2 increased + 25%");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "Header",
                value: "Productivity vs.week2 increased + 25%");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "Header",
                value: "Productivity vs.week2 increased + 25%");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 17,
                column: "Header",
                value: "Productivity vs.week3 increased + 25%");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 18,
                column: "Header",
                value: "Productivity vs.week3 increased + 25%");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 19,
                column: "Header",
                value: "Productivity vs.week3 increased + 25%");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 20,
                column: "Header",
                value: "Productivity vs.week3 increased + 25%");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "Header",
                value: "Productivity vs.week3 increased + 25%");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Header",
                table: "UserCalendarItems");
        }
    }
}
