using Microsoft.EntityFrameworkCore.Migrations;

namespace RemoteCamp.Portal.Core.Database.Migrations
{
    public partial class RUP325_UpdateIC_Calendar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                table: "WeeklyPlanDays",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Day",
                table: "WeeklyPlanDays",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalUrl",
                table: "UserCalendarItemActions",
                maxLength: 2083,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserCalendarItemActions",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 9,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 10,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 11,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 12,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 13,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 14,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 15,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 16,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 17,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 18,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 19,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 20,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 21,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 22,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 23,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 24,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 25,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 26,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 27,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 28,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 29,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 30,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 31,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 32,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 33,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 34,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 35,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 36,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 37,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 38,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 39,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 40,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 41,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 42,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 43,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 44,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 45,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 46,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 47,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 48,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 49,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 50,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 51,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 52,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 53,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 54,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 55,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 56,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 57,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 58,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 59,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 60,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 61,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 62,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 63,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 64,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 65,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 66,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 67,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 68,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 69,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 70,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 71,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 72,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 73,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 74,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 75,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 76,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 77,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 78,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 79,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 80,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 81,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 82,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 83,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 84,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 85,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 86,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 87,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 88,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 89,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 90,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 91,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 92,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 93,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 94,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 95,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 96,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 97,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 98,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 99,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 100,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 101,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 102,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 103,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 104,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 105,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 106,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 107,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 108,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 109,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 110,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 111,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 112,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 113,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 114,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 115,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 116,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 117,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 118,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 119,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 120,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 121,
                column: "IsDeleted",
                value: true);

            migrationBuilder.InsertData(
                table: "UserCalendarItemActions",
                columns: new[] { "Id", "AdditionalUrl", "Description", "Duration", "IsDeleted", "Url", "UserCalendarItemId" },
                values: new object[,]
                {
                    { 195, null, "Development work", 350, false, "", 13 },
                    { 185, null, "Development work", 350, false, "", 11 },
                    { 186, null, "Prepare your automation idea to double your productivity. Send to your manager for approval", 90, false, "", 11 },
                    { 188, null, "Make a weekly plan of deliveries. Recommended distribution of load is: 25/25/25/25/fix+catchup", 30, false, "https://remoteu.trilogy.com/plan", 12 },
                    { 189, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 12 },
                    { 190, null, "Analyse your last week performance. Plan this week improvements, document this plan. Search the tools to improve your productivity.", 30, false, "", 12 },
                    { 191, null, "Development work", 370, false, "", 12 },
                    { 192, null, "Add 1 feedback about the RC to the WSPro deck", 20, false, "", 12 },
                    { 193, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 13 },
                    { 194, null, "CiC with Manager, discuss your innovation idea", 10, false, "", 13 },
                    { 196, null, "Record a TMS video while producing a unit", 0, false, "", 13 },
                    { 187, null, "Fill the NPS RemoteCamp form to summarize your experience of the week", 10, false, "", 11 },
                    { 215, null, "Analyse your last week performance. Plan this week improvements, document this plan. Search the tools to improve your productivity.", 30, false, "", 17 },
                    { 184, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 11 },
                    { 166, null, "Development work", 340, false, "", 8 },
                    { 167, null, "Record a TMS video while producing a unit", 0, false, "", 8 },
                    { 168, null, "Compare TMS for this week and the previous, document the changes", 16, false, "", 8 },
                    { 169, null, "Technical coaching session", 30, false, "", 8 },
                    { 170, null, "Add 1 WSPro insight to WSPro deck", 10, false, "", 8 },
                    { 171, null, "Add 1 Negative feedback to WSPro deck", 6, false, "", 8 },
                    { 172, "https://drive.google.com/open?id=13QUNlMcVMN6yGIP7ym9ijAC3mTpFLkWs", "Read or watch \"Make Automation Suggestions to Team Lead\"", 15, false, "https://drive.google.com/open?id=1WKGk2q2dfhP5_nB-HuQxzp04SIN4VL3gf2WlK7c5B9Q", 9 },
                    { 173, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 9 },
                    { 197, null, "Compare TMS for this week and the previous, document the changes", 30, false, "", 13 },
                    { 174, null, "Development work", 380, false, "", 9 },
                    { 176, null, "Finish WSPro page in deck", 25, false, "", 9 },
                    { 177, "https://drive.google.com/open?id=1gwq1h8hc-ucVLgk1aq1--D3ji_k4R8O_", "Read or watch \"Seek Continuous Improvement and Experiment\"", 15, false, "https://drive.google.com/open?id=1-4Zoh9MeXadFMxmF9sgsaP-4jK0VWCFBrr7urCaenDA", 10 },
                    { 178, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 20, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 10 },
                    { 179, null, "CiC with Manager, ask for negative feedback", 15, false, "", 10 },
                    { 180, null, "Development work", 380, false, "", 10 },
                    { 181, null, "Technical coaching session", 30, false, "", 10 },
                    { 182, null, "Add 1 negative feedback to your deck", 10, false, "", 10 },
                    { 183, null, "Address manager's feedback in your deck", 10, false, "", 10 },
                    { 175, null, "Technical coaching session", 30, false, "", 9 },
                    { 198, null, "Technical coaching session", 30, false, "", 13 },
                    { 203, null, "Finish RC feedback section in your deck", 40, false, "", 14 },
                    { 200, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 14 },
                    { 229, null, "Development work", 380, false, "", 20 },
                    { 228, null, "CiC with Manager, final review deck, ask for the feedback", 10, false, "", 20 },
                    { 227, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 20 },
                    { 226, null, "Fill the \"Results\" section in the deck (previous 3 weeks)", 20, false, "", 19 },
                    { 225, null, "Technical coaching session", 30, false, "", 19 },
                    { 224, null, "Development work", 400, false, "", 19 },
                    { 230, null, "Technical coaching session", 30, false, "", 20 },
                    { 223, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 19 },
                    { 221, null, "Compare TMS for this week and the previous, document the changes", 30, false, "", 18 },
                    { 220, null, "Record a TMS video while producing a unit", 0, false, "", 18 },
                    { 219, null, "Development work", 380, false, "", 18 },
                    { 218, null, "CiC with Manager, discuss your improvements during the previous weeks and the further directions to improve, ask for the feedback", 10, false, "", 18 },
                    { 217, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 18 },
                    { 216, null, "Development work", 390, false, "", 17 },
                    { 222, null, "Technical coaching session", 30, false, "", 18 },
                    { 199, null, "Add 1 feedback about the RC to WSPro deck", 30, false, "", 13 },
                    { 231, null, "Address manager\"''\"s feedback in your deck", 30, false, "", 20 },
                    { 233, null, "Development work", 425, false, "", 21 },
                    { 201, null, "Development work", 380, false, "", 14 },
                    { 202, null, "Technical coaching session", 30, false, "", 14 },
                    { 165, null, "CiC with Manager, ask for the negative feedback", 10, false, "", 8 },
                    { 204, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 15 },
                    { 205, null, "CiC with Manager, review deck", 10, false, "", 15 },
                    { 206, null, "Development work", 380, false, "", 15 },
                    { 232, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 21 },
                    { 207, null, "Technical coaching session", 30, false, "", 15 },
                    { 209, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 16 },
                    { 210, null, "Development work", 350, false, "", 16 },
                    { 211, null, "Check the results of your automation idea, refine it.", 90, false, "", 16 },
                    { 212, null, "Fill the NPS RemoteCamp form to summarize your experience of the week", 10, false, "", 16 },
                    { 213, null, "Make a weekly plan of deliveries. Recommended distribution of load is: 25/25/25/25/fix+catchup", 30, false, "https://remoteu.trilogy.com/plan", 17 },
                    { 214, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 17 },
                    { 208, null, "Address manager\"''\"s feedback in your deck", 30, false, "", 15 },
                    { 164, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 8 },
                    { 235, null, "Graduation panel", 15, false, "", 21 },
                    { 162, null, "Add 1 WSPro insight to WSPro deck", 25, false, "", 7 },
                    { 134, null, "Development work", 350, false, "https://drive.google.com/open?id=1IN3V4uEnjL2J5AnwdDmIABwCr3d6fzEJE_tDG7qXdqM", 3 },
                    { 133, null, "CiC with Manager", 15, false, "", 3 },
                    { 132, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 3 },
                    { 131, null, "Read \"Importance of Intensity and focus blocks\"", 6, false, "https://drive.google.com/open?id=1CMlnXFNBOOid6e5wsTgQeriapXMDfy3hi4qtH99nH5Q", 3 },
                    { 130, null, "Read \"Improving quality and productivity\"", 6, false, "https://drive.google.com/open?id=12M7I2E4T47bk0jKprtdlsd8gt9iN4NVP7P4KLq-uv38", 3 },
                    { 129, "https://drive.google.com/open?id=1WbcAloWNZjJrWsYrFItyFUAmehm64ZFd", "Read or watch \"Be an Expert/Tackle the hardest problem\"", 23, false, "https://drive.google.com/open?id=1IN3V4uEnjL2J5AnwdDmIABwCr3d6fzEJE_tDG7qXdqM", 3 },
                    { 128, null, "Development work", 160, false, "", 2 },
                    { 163, null, "Watch \"How to Make a Plan\"", 38, false, "https://drive.google.com/open?id=1YMslqRjd3tedFUXgUjHKZqjegXpF9Swn", 8 },
                    { 126, null, "CiC with Manager", 15, false, "", 2 },
                    { 125, null, "Make a weekly plan of deliveries. Recommended distribution of load is: 10/30/30/20/10+fix+catchup. Use the daily plan sheet in your assignment folder.", 20, false, "https://remoteu.trilogy.com/plan", 2 },
                    { 124, null, "Get the list of assignments (jira) and do a preliminary analysis. Form your Input Quality Bar and use QnA sheet to ask questions for the assignments which are not clear.", 30, false, "https://docs.google.com/spreadsheets/d/1-zKfuHjZKe-696mcumjdiCNR9jDJTeLtNZL-9eGgy3w/edit#gid=784927824", 2 },
                    { 123, null, "Read \"Welcome Negative feedback\"", 7, false, "https://drive.google.com/open?id=1RF6wgfeobYV4c6b3TyAA7EjJiOViJtfxD2em7H_vfRU", 2 },
                    { 122, null, "Read \"Follow Your Calendar\"", 8, false, "https://drive.google.com/open?id=1u90OxXmLrfSsphaTJ81Gu-o5JU4aj5tqw36K_K6YoV4", 2 },
                    { 244, "https://drive.google.com/open?id=1yu4cGUuHiuUh-oTldBZdxZ1WQwt12HDV", "Read or watch \"Worksmart tool certified\"", 15, false, "https://drive.google.com/open?id=1yjIVcSKnAtgIgZ52W2jPDb9OC8K6RvOb5V2n1KOmCBs", 1 },
                    { 243, "https://drive.google.com/open?id=1zBYHenIc87Cmh9gDDZelL-hbUEWscJd0", "Read or watch \"Be successful in a remote environment\"", 15, false, "https://drive.google.com/open?id=1Z1ZaQpf4aa291O_dkbrPhaY0s0CEKr2RNOPltfRTFsc", 1 },
                    { 242, "https://drive.google.com/open?id=1_Er9y8bxMfpRmqyEAfQo2Hs9vxsarCtn", "Read or watch \"Quality and common terms we use\"", 15, false, "https://drive.google.com/open?id=13x4k7OlM-qoZIfwnr3FqeQKpMBmOJ5VD0IEsGiSMOvM", 1 },
                    { 241, null, "Watch \"Anti-cheating policy\"", 28, false, "https://drive.google.com/open?id=1ToaleLywRtkhudjxBH9nCZAvdY1G27SH", 1 },
                    { 240, "https://drive.google.com/open?id=1gI1PtVN_F-DLZo5-xIKUuFg2hkhq2Ppn", "Read or watch \"How you can fail in RemoteU\"", 15, false, "https://drive.google.com/open?id=1TE952cAjQo_MTVxBNKB4F4GsrwmFNMEI3JXXilS_M0Y", 1 },
                    { 239, null, "Read \"The Factory Model for Elite ICs\"", 6, false, "https://drive.google.com/open?id=1LrrjfOJTXYckH70G5ohcSndp56cu9ALy6BvS7n_j40I", 1 },
                    { 238, null, "Watch kickoff call and raise questions to remotecamp-sem@trilogy.com", 30, false, "https://crossover.zoom.us/recording/play/kn9N20u326Ny-sdu4pVBkea0m2zIHtcwHDp_DQ9hYqXgi1Nmy33W9dLj1zrXgz1U?continueMode=true", 1 },
                    { 237, null, "Login RemoteU Portal with your company email and check if all accesses are green. Report failing accesses to remotecamp-sem@trilogy.com", 5, false, "https://remoteu.trilogy.com", 1 },
                    { 236, null, "Get and read the Welcome email from RemoteU management and do the prerequisites in One-Pager", 10, false, "", 1 },
                    { 234, null, "Fill the results for the last week to your deck", 10, false, "", 21 },
                    { 135, null, "Record a TMS video while producing a units", 0, false, "", 3 },
                    { 136, null, "Technical coaching session", 30, false, "https://docs.google.com/document/u/1/d/1oc5kgAfOZgvOhvwHjLjyZJmPKkxMmwtg7vt-rncW1ss/edit", 3 },
                    { 127, null, "Ask technical questions to mentors, setup projects, watch and read technical documentation applicable to your track. Align with your mentor on Internal Quality Bars, have no different opinion. Create a physical sheet of quality bars and assignment matrix.", 240, false, "https://drive.google.com/open?id=1QNGyddEVA6mO8sbi4CZ8M-XxaybskglUP38gSqEgtmo", 2 },
                    { 138, null, "Read \"How to deliver 100% quality?\"", 6, false, "https://drive.google.com/open?id=1goA6vWrBJmmtJnmv-UOg5uXwcO6iHw9S1eKBNfRYFqM", 4 },
                    { 161, null, "Development work", 360, false, "", 7 },
                    { 137, null, "Add your TMS to the Deck in your assignment folder", 20, false, "https://docs.google.com/document/d/1oc5kgAfOZgvOhvwHjLjyZJmPKkxMmwtg7vt-rncW1ss/edit", 3 },
                    { 159, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 7 },
                    { 158, "https://drive.google.com/open?id=1YMslqRjd3tedFUXgUjHKZqjegXpF9Swn", "Make a weekly plan of deliveries. Recommended distribution of load is: 25/25/25/25/fix+catchup", 20, false, "https://remoteu.trilogy.com/plan", 7 },
                    { 157, "https://drive.google.com/open?id=1RUG_Ed2YCLeC52uRzQEZitcZfAe4IS6D", "Read or watch \"Find tools to improve your productivity\"", 15, false, "https://drive.google.com/open?id=1J9kRxC_8dW2--6Jn_FxaQ1pa8KgSE-eYHj4CkwIfoe4", 7 },
                    { 156, null, "Fill the NPS form that you will receive within the day with an email to summarize your experience of the week", 7, false, "", 6 },
                    { 155, null, "Check your WSPro statistics. Check your results. Find 1 insight and put it to WSPro deck", 40, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 6 },
                    { 154, null, "Development work", 380, false, "", 6 },
                    { 153, null, "CiC with Manager", 15, false, "", 6 },
                    { 152, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 6 },
                    { 151, null, "Read \"Give Improvement Feedback\"", 8, false, "https://drive.google.com/open?id=1Mt1HyCnSsU69yBmndtY0pYxtN787OD-gkjJpA3XLjeE", 6 },
                    { 160, null, "Analyse your last week performance. Plan this week improvements, document this plan. Search the tools to improve your productivity.", 30, false, "", 7 },
                    { 149, null, "Check your WSPro statistics. Check your results. Find 1 insight and put it to WSPro deck", 40, false, "https://app.crossover.com/x/dashboard/contractor/my-dashboard", 5 },
                    { 148, null, "Development work", 380, false, "", 5 },
                    { 147, null, "CiC with Manager", 15, false, "", 5 },
                    { 146, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 5 },
                    { 145, "https://drive.google.com/open?id=1RUG_Ed2YCLeC52uRzQEZitcZfAe4IS6D", "Read or Watch \"Put yourself in Customer's shoes\"", 15, false, "https://drive.google.com/open?id=1J9kRxC_8dW2--6Jn_FxaQ1pa8KgSE-eYHj4CkwIfoe4", 5 },
                    { 144, null, "Identify possible improvements, create plan how do you want to achieve your target", 43, false, "", 4 },
                    { 143, null, "Technical coaching session", 30, false, "", 4 },
                    { 142, null, "Development work", 350, false, "", 4 },
                    { 141, null, "CiC with Manager", 15, false, "", 4 },
                    { 140, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 4 },
                    { 139, null, "Read \"Root Cause Analysis\"", 6, false, "https://drive.google.com/open?id=13iWjYSNF_00RNsevjWMyzX3DNQofLbsxpJF0vAXGiFE", 4 },
                    { 150, null, "Fill the NPS form that you will receive within the day with an email to summarize your experience of the week", 7, true, "", 5 }
                });

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "You are technically and mentally prepared to the adventure. All is set up. Check if everything works fine and please don't start the tracker until Monday morning.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Header",
                value: "Onboarding to remote work");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Header" },
                values: new object[] { @"You know your failures.
                                You are identified your hardest problem and started to think how to resolve it,and discussed it with your manager.
                                You completed 40% of your weekly target.", "Onboarding to remote work" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Header",
                value: "Be a quality expert");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Header",
                value: "Be a quality expert");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Header",
                value: "Be a quality expert");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Header",
                value: "Own your productivity and learn how to scale");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Header" },
                values: new object[] { @"You discussed your hardest problem with your manager.
                                You completed 50% of your weekly target.
                                You compared your results with the previous week and documented the changes.
                                You have 4 WSPro insights,1 negative feedback and 2 TMSs in your deck", "Own your productivity and learn how to scale" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Header" },
                values: new object[] { @"You completed 75% of your weekly target.
                                You completed the WSPro section in your deckYou completed Negative feedback section of your deck", "Own your productivity and learn how to scale" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "Header",
                value: "Own your productivity and learn how to scale");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "Header",
                value: "Own your productivity and learn how to scale");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "Header",
                value: "Meet the team average");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "Header" },
                values: new object[] { @"You completed 75% of your weekly target.
                                You completed the 'Provide feedback' section in your deck", "Meet the team average" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "Header" },
                values: new object[] { @"You completed 100% of your weekly target.
                                You reviewed WSPro section,Provide feedback,Negative feedback sections with your manager and addressed his feedback", "Meet the team average" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "Header",
                value: "Meet the team average");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 17,
                column: "Header",
                value: "Challenge the top performer");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 18,
                column: "Header",
                value: "Challenge the top performer");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Description", "Header" },
                values: new object[] { @"You completed 75% of your weekly target.
                                You filled the ""Results"" section of your deck(prev.3 weeks)", "Challenge the top performer" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 20,
                column: "Header",
                value: "Challenge the top performer");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "Header",
                value: "Challenge the top performer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DropColumn(
                name: "AdditionalUrl",
                table: "UserCalendarItemActions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserCalendarItemActions");

            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                table: "WeeklyPlanDays",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Day",
                table: "WeeklyPlanDays",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "You are technically and mentally prepared to the adventure. All is set up. Your assignments will be available on Monday.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Header",
                value: null);

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Header" },
                values: new object[] { @"You know your failures.
                                You are identified your hardest problem and started to think how to resolve it,
                                and discussed it with your manager.
                                You completed 40% of your weekly target.", null });

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Header",
                value: null);

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Header",
                value: null);

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Header",
                value: null);

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Header",
                value: "Productivity vs. week1 increased + 25%");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Header" },
                values: new object[] { @"You discussed your hardest problem with your manager.
                                You completed 50% of your weekly target.
                                You compared your results with the previous week and documented the changes.
                                You have 4 WSPro insights,
                                1 negative feedback and 2 TMSs in your deck", "Productivity vs. week1 increased + 25%" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Header" },
                values: new object[] { @"You completed 75% of your weekly target.
                                You completed the WSPro section in your deck
                                You completed Negative feedback section of your deck", "Productivity vs. week1 increased + 25%" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "Header",
                value: "Productivity vs. week1 increased + 25%");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "Header",
                value: "Productivity vs. week1 increased + 25%");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "Header",
                value: "Productivity vs. week2 increased + 25%");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "Header" },
                values: new object[] { @"You completed 75% of your weekly target.
                                You completed the ""Provide feedback"" section in your deck", "Productivity vs. week2 increased + 25%" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "Header" },
                values: new object[] { @"You completed 100% of your weekly target.
                                You reviewed WSPro section,
                                Provide feedback,
                                Negative feedback sections with your manager and addressed his feedback", "Productivity vs. week2 increased + 25%" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "Header",
                value: "Productivity vs. week2 increased + 25%");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 17,
                column: "Header",
                value: "Productivity vs. week3 increased + 25%");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 18,
                column: "Header",
                value: "Productivity vs. week3 increased + 25%");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Description", "Header" },
                values: new object[] { @"You completed 75% of your weekly target.
                                 You filled the ""Results"" section of your deck(prev.3 weeks)", "Productivity vs. week3 increased + 25%" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 20,
                column: "Header",
                value: "Productivity vs. week3 increased + 25%");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "Header",
                value: "Productivity vs. week3 increased + 25%");
        }
    }
}
