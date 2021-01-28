using Microsoft.EntityFrameworkCore.Migrations;

namespace RemoteCamp.Portal.Core.Database.Migrations
{
    public partial class AddFrontEndSoftwareArchitectPipeline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pipelines",
                columns: new[] { "Id", "Name" },
                values: new object[] { 18, "Front End Software Architect" });

            migrationBuilder.InsertData(
                table: "PipelinePrerequisites",
                columns: new[] { "Id", "Name", "PipelineId" },
                values: new object[] { 133, "Computer Skills", 18 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Pipelines",
                keyColumn: "Id",
                keyValue: 18);
        }
    }
}
