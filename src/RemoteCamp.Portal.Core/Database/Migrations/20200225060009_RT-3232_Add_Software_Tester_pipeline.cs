using Microsoft.EntityFrameworkCore.Migrations;

namespace RemoteCamp.Portal.Core.Database.Migrations
{
    public partial class RT3232_Add_Software_Tester_pipeline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pipelines",
                columns: new[] { "Id", "Name" },
                values: new object[] { 20, "Software Tester" });

            migrationBuilder.InsertData(
                table: "PipelinePrerequisites",
                columns: new[] { "Id", "Name", "PipelineId" },
                values: new object[,]
                {
                    { 155, "Computer Skills", 20 },
                    { 156, "Jira/Project Management Tool", 20 },
                    { 157, "Test Rail/ALM/ Test Management Tool", 20 },
                    { 158, "Functional & Non - Functional Testing", 20 },
                    { 159, "API Testing", 20 },
                    { 160, "Regression Testing", 20 },
                    { 161, "Smoke Testing", 20 },
                    { 162, "System Integration Testing", 20 },
                    { 163, "E2E Testing", 20 },
                    { 164, "Knowledge of SQL", 20 },
                    { 165, "SDLC Concepts", 20 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Pipelines",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
