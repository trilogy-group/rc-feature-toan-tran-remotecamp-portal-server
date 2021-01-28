using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RemoteCamp.Portal.Core.database.migrations
{
    public partial class RUP46_AddPipelineAndPipelinePrerequisite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pipelines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pipelines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PipelinePrerequisites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PipelineId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipelinePrerequisites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PipelinePrerequisites_Pipelines_PipelineId",
                        column: x => x.PipelineId,
                        principalTable: "Pipelines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pipelines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Java Software Engineer" },
                    { 15, "QA Software Architect" },
                    { 14, "Test Automation Chief Software Architect" },
                    { 13, "Senior Site Reliability Engineer" },
                    { 12, "Senior Cloud Operations Engineer" },
                    { 11, "Cloud Operations Engineer" },
                    { 10, "QA Automation Engineer" },
                    { 16, "C++ Chief Software Architect" },
                    { 9, "QA Manual Tester" },
                    { 7, "Java Chief Software Architect" },
                    { 6, "C# (.NET) Software Architect" },
                    { 5, "Java Software Architect" },
                    { 4, "Front End Software Engineer" },
                    { 3, "C++ Software Engineer" },
                    { 2, "C# (.NET) Software Engineer" },
                    { 8, "C# (.NET) Chief Software Architect" },
                    { 17, "Front End Chief Software Architect" }
                });

            migrationBuilder.InsertData(
                table: "PipelinePrerequisites",
                columns: new[] { "Id", "Name", "PipelineId" },
                values: new object[,]
                {
                    { 1, "Computer Skills", 1 },
                    { 97, "Docker", 12 },
                    { 96, "Cloud (AWS)", 12 },
                    { 95, "Virtualization", 12 },
                    { 94, "FTP/SFTP", 11 },
                    { 93, "VPN, routing", 11 },
                    { 92, "TCP/IP", 11 },
                    { 91, "Logging", 11 },
                    { 90, "Bash", 11 },
                    { 89, "Git / GitHub", 11 },
                    { 88, "Windows", 11 },
                    { 87, "Linux", 11 },
                    { 86, "Kubernetes", 11 },
                    { 85, "Docker", 11 },
                    { 84, "Cloud (AWS)", 11 },
                    { 83, "Virtualization", 11 },
                    { 82, "E2E Testing", 10 },
                    { 81, "Test Rail/ALM/ Test Management Tool.", 10 },
                    { 80, "Jira/Project Management", 10 },
                    { 79, "Protractor", 10 },
                    { 78, "Git / GitHub", 10 },
                    { 77, "TypeScript / JavaScript Knowledge", 10 },
                    { 76, "Computer Skills", 10 },
                    { 75, "SDLC Concepts", 9 },
                    { 74, "Knowledge of SQL", 9 },
                    { 73, "E2E Testing", 9 },
                    { 72, "System Integration Testing", 9 },
                    { 71, "Smoke Testing", 9 },
                    { 70, "Regression Testing", 9 },
                    { 69, "API Testing", 9 },
                    { 98, "Kubernetes", 12 },
                    { 68, "Functional & Non - Functional Testing", 9 },
                    { 99, "Linux", 12 },
                    { 101, "Git / GitHub", 12 },
                    { 130, "Computer Skills", 15 },
                    { 129, "Computer Skills", 14 },
                    { 128, "SQL (MySQL)", 13 },
                    { 127, "FTP/SFTP", 13 },
                    { 126, "VPN, routing", 13 },
                    { 125, "TCP/IP", 13 },
                    { 124, "Monitoring", 13 },
                    { 123, "Logging", 13 },
                    { 122, "Ansible", 13 },
                    { 121, "Terraform", 13 },
                    { 120, "Infra-as-code", 13 },
                    { 119, "Java (minimal)", 13 },
                    { 118, "Bash/Python", 13 },
                    { 117, "CI/CD (Jenkins)", 13 },
                    { 116, "Git / GitHub", 13 },
                    { 115, "Windows", 13 },
                    { 114, "Linux", 13 },
                    { 113, "Kubernetes", 13 },
                    { 112, "Docker", 13 },
                    { 111, "Cloud (AWS)", 13 },
                    { 110, "Virtualization", 13 },
                    { 109, "SQL (MySQL)", 12 },
                    { 108, "FTP/SFTP", 12 },
                    { 107, "VPN, routing", 12 },
                    { 106, "TCP/IP", 12 },
                    { 105, "Monitoring", 12 },
                    { 104, "Logging", 12 },
                    { 103, "Java (minimal)", 12 },
                    { 102, "Bash/Python", 12 },
                    { 100, "Windows", 12 },
                    { 67, "Test Rail/ALM/ Test Management Tool", 9 },
                    { 66, "Jira/Project Management Tool", 9 },
                    { 65, "Computer Skills", 9 },
                    { 30, "Refactoring technique", 5 },
                    { 29, "Git / GitHub", 5 },
                    { 28, "Java", 5 },
                    { 27, "Computer Skills", 5 },
                    { 26, "Git / GitHub", 4 },
                    { 25, "Computer Skills", 4 },
                    { 24, "Mutation Testing", 3 },
                    { 23, "C++/VC++", 3 },
                    { 22, "Git / GitHub", 3 },
                    { 21, "Open CPP", 3 },
                    { 20, "Visual Studio", 3 },
                    { 19, "Google Mock", 3 },
                    { 18, "Google Test", 3 },
                    { 17, "Computer Skills", 3 },
                    { 16, "Mutation Testing", 2 },
                    { 15, "Git / GitHub", 2 },
                    { 14, "Visual Studio", 2 },
                    { 13, "Shouldly", 2 },
                    { 12, "Mock, MsFake", 2 },
                    { 11, "Nunit, MsTest, Xunit", 2 },
                    { 10, "Computer Skills", 2 },
                    { 9, "C#/Dot Net", 2 },
                    { 8, "Mutation Testing", 1 },
                    { 7, "eclipse/IntelliJ", 1 },
                    { 6, "Git / GitHub", 1 },
                    { 5, "PowerMock", 1 },
                    { 4, "Mockito", 1 },
                    { 3, "Junit", 1 },
                    { 2, "Java", 1 },
                    { 31, "Design Patterns", 5 },
                    { 32, "Unit Testing", 5 },
                    { 33, "Computer Skills", 6 },
                    { 34, "Skils", 6 },
                    { 64, "C# Multi-threading", 8 },
                    { 63, "SQL Query Optimization", 8 },
                    { 62, "ASP.NET Web Forms", 8 },
                    { 61, "Entity Framework", 8 },
                    { 60, "SQL", 8 },
                    { 59, "C# (deep knowledge)", 8 },
                    { 58, "MS SQL", 8 },
                    { 57, "Internet Information Services (IIS)", 8 },
                    { 56, "MS Build", 8 },
                    { 55, "Windows", 8 },
                    { 54, "Git / GitHub", 8 },
                    { 53, "Computer Skills", 8 },
                    { 52, "Java Multi-threading", 7 },
                    { 51, "SQL Query Optimization", 7 },
                    { 131, "Computer Skills", 16 },
                    { 50, "Spring Framework", 7 },
                    { 48, "SQL", 7 },
                    { 47, "Javascript", 7 },
                    { 46, "Java (deep knowledge)", 7 },
                    { 45, "MySql", 7 },
                    { 44, "Apache Tomcat", 7 },
                    { 43, "Apache Maven", 7 },
                    { 42, "Windows", 7 },
                    { 41, "Git / GitHub", 7 },
                    { 40, "Computer Skills", 7 },
                    { 39, "Unit Testing", 6 },
                    { 38, "Design Patterns", 6 },
                    { 37, "Refactoring Technique", 6 },
                    { 36, "Git / GitHub", 6 },
                    { 35, "C#", 6 },
                    { 49, "Hibernate", 7 },
                    { 132, "Computer Skills", 17 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PipelinePrerequisites_PipelineId",
                table: "PipelinePrerequisites",
                column: "PipelineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PipelinePrerequisites");

            migrationBuilder.DropTable(
                name: "Pipelines");
        }
    }
}
