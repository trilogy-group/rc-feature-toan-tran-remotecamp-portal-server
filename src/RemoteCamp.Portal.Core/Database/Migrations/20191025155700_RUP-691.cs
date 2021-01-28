using Microsoft.EntityFrameworkCore.Migrations;

namespace RemoteCamp.Portal.Core.Database.Migrations
{
    public partial class RUP691 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PipelinePrerequisites",
                columns: new[] { "Id", "Name", "PipelineId" },
                values: new object[,]
                {
                    { 148, "Git / GitHub", 17 },
                    { 145, "Jira/Project Management", 18 },
                    { 144, "Karma/Jasmine", 18 },
                    { 143, "AngularJS", 18 },
                    { 142, "JavaScript", 18 },
                    { 141, "Git / GitHub", 18 },
                    { 140, "Gulp", 4 },
                    { 139, "Unit Testing", 4 },
                    { 138, "Jira/Project Management", 4 },
                    { 137, "Karma/Jasmine", 4 },
                    { 136, "AngularJS", 4 },
                    { 135, "JavaScript", 4 },
                    { 154, "Gulp", 17 },
                    { 153, "Unit Testing", 17 },
                    { 152, "Jira/Project Management", 17 },
                    { 151, "Karma/Jasmine", 17 },
                    { 150, "AngularJS", 17 },
                    { 149, "JavaScript", 17 },
                    { 146, "Unit Testing", 18 },
                    { 147, "Gulp", 18 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 154);
        }
    }
}
