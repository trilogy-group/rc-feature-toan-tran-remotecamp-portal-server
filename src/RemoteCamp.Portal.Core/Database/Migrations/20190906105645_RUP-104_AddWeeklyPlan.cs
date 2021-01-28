using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RemoteCamp.Portal.Core.Database.Migrations
{
    public partial class RUP104_AddWeeklyPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeeklyPlanWeeks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WeekNumber = table.Column<int>(nullable: false),
                    Submitted = table.Column<bool>(nullable: false),
                    Approved = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyPlanWeeks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyPlanWeeks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyPlanDays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Day = table.Column<string>(maxLength: 10, nullable: true),
                    Summary = table.Column<string>(maxLength: 500, nullable: true),
                    ScoreTarget = table.Column<double>(nullable: true),
                    WeeklyPlanWeekId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyPlanDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyPlanDays_WeeklyPlanWeeks_WeeklyPlanWeekId",
                        column: x => x.WeeklyPlanWeekId,
                        principalTable: "WeeklyPlanWeeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyPlanDays_WeeklyPlanWeekId",
                table: "WeeklyPlanDays",
                column: "WeeklyPlanWeekId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyPlanWeeks_UserId",
                table: "WeeklyPlanWeeks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeeklyPlanDays");

            migrationBuilder.DropTable(
                name: "WeeklyPlanWeeks");
        }
    }
}
