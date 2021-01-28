using Microsoft.EntityFrameworkCore.Migrations;

namespace RemoteCamp.Portal.Core.Database.Migrations
{
    public partial class RUP116_CSoftwareArchitect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pipelines",
                columns: new[] { "Id", "Name" },
                values: new object[] { 19, "C++ Software Architect" });

            migrationBuilder.InsertData(
                table: "PipelinePrerequisites",
                columns: new[] { "Id", "Name", "PipelineId" },
                values: new object[] { 134, "Computer Skills", 19 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PipelinePrerequisites",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Pipelines",
                keyColumn: "Id",
                keyValue: 19);
        }
    }
}
