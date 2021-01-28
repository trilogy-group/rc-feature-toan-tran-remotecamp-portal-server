using Microsoft.EntityFrameworkCore.Migrations;

namespace RemoteCamp.Portal.Core.Database.Migrations
{
    public partial class RT2900_Update_IC_Calendar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "UserCalendarItemActions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 160,
                column: "Description",
                value: @"Analyse your last week performance. Plan this week improvements, document this plan. 
Search the tools to improve your productivity.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 245,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 246,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 247,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 248,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 249,
                columns: new[] { "Description", "Duration", "Position", "UserCalendarItemId" },
                values: new object[] { "Read \"The Factory Model for Elite ICs\" and understand the benefits of \"Factory Model\" in IC's perspective", 10, 2, 27 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 250,
                columns: new[] { "Description", "Duration", "Position", "UserCalendarItemId" },
                values: new object[] { "Read \"How you can fail in Eng.RemoteU\" and avoid common mistakes", 15, 3, 27 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 251,
                columns: new[] { "Description", "Duration", "Position", "UserCalendarItemId" },
                values: new object[] { "Watch \"Anti Cheating Policy\" and understand the boundaries of helping each other", 30, 4, 27 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 252,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 253,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 254,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 255,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 256,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 257,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 263,
                columns: new[] { "Description", "IsDeleted", "Position" },
                values: new object[] { "Get the list of assignments (jira) and do a preliminary analysis. Form your Input Quality Bar and use QnA sheet to ask questions for the assignments which are not clear.", true, 2 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 264,
                columns: new[] { "Description", "Duration", "Position" },
                values: new object[] { "Read \"Be An Expert/Tackle the hardest problem\" Learn how to identify and tackle your hardest problem systematically.", 15, 3 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 265,
                columns: new[] { "Description", "Duration", "Position" },
                values: new object[] { "Read \"Improving quality and productivity\" and understand how quality and productivity is measured and improved", 15, 4 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 266,
                columns: new[] { "Description", "Duration", "Position" },
                values: new object[] { "Read \"How to deliver 100% quality\" and shift your mindset to quality-focus. This week is about making mistakes and learning from it. Starting from the next week, you are asked to produce 100% quality.", 15, 5 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 267,
                columns: new[] { "Description", "Duration", "Position" },
                values: new object[] { "Read \"Root Cause Analysis\" and learn to make a great RCA and a corrective action", 15, 10 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 268,
                columns: new[] { "Description", "Duration", "Position" },
                values: new object[] { "Read \"Put yourself in customer shoes\" and understand the business value of your output", 7, 11 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 269,
                columns: new[] { "Description", "IsDeleted", "Position" },
                values: new object[] { "Make a weekly plan of deliveries. Recommended distribution of load is: 20/25/25/25/5+fix+catchup.", true, 14 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 270,
                columns: new[] { "Description", "Position", "Url" },
                values: new object[] { "Prepare for CiC. Ask all RemoteU related questions to your manager. Learn how to conduct a CiC.", 15, "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 271,
                columns: new[] { "Description", "IsDeleted", "Position" },
                values: new object[] { "Analyse your last week performance. Plan this week improvements, document this plan. Search the tools to improve your productivity.", true, 16 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 272,
                columns: new[] { "Description", "Duration", "Position", "Url" },
                values: new object[] { "Development work", 60, 17, "https://crossover.atlassian.net/issues/?filter=-1" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 273,
                columns: new[] { "Description", "Duration", "Position", "Url" },
                values: new object[] { "Ask technical questions to mentors, set up projects, watch and read technical documentation applicable to your module. Align with your mentor on Quality Bars, have no different opinions.", 215, 9, "https://docs.google.com/spreadsheets/d/1-zKfuHjZKe-696mcumjdiCNR9jDJTeLtNZL-9eGgy3w/edit#gid=784927824" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 274,
                columns: new[] { "IsDeleted", "Position" },
                values: new object[] { true, 18 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 275,
                columns: new[] { "Description", "Duration", "Position" },
                values: new object[] { "Read \"Give Improvement Feedback\" and be ready to provide your feedback to RemoteU on Friday with NPS form", 7, 12 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 276,
                columns: new[] { "Description", "Duration", "Position", "Url" },
                values: new object[] { "It is the day you will start presenting in CiCs so learn CiC Framework and prepare for the meeting. Identify your hardest problem and discuss it with your manager.", 40, 4, "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 277,
                columns: new[] { "Duration", "Position", "Url" },
                values: new object[] { 330, 1, "https://crossover.atlassian.net/issues/?filter=-1" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 278,
                column: "Position",
                value: 2);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 279,
                columns: new[] { "Description", "Duration", "Position", "Url" },
                values: new object[] { "Watch your TMS, document activities in the TMS spreadsheet in your deliverables folder. Be granular while classifying activities.", 30, 3, "{{IcTmsDocumentUrl}}" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 280,
                columns: new[] { "Description", "Position", "Url" },
                values: new object[] { "Attend technical coaching session.", 6, "https://docs.google.com/spreadsheets/d/1-zKfuHjZKe-696mcumjdiCNR9jDJTeLtNZL-9eGgy3w/edit#gid=784927824" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 281,
                columns: new[] { "Description", "Duration", "Position", "Url" },
                values: new object[] { "Start learning XO Dashboard application. Go through the timecards and add 1 WSPro insight to Deck.", 15, 7, "https://app.crossover.com/x/dashboard/contractor/my-dashboard" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 282,
                columns: new[] { "Description", "Duration", "Position", "Url" },
                values: new object[] { "We love to provide feedback. Take all the negative feedback from your manager or mentor and add one of them to WSPro Deck.", 15, 8, "{{IcDeckUrl}}" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 283,
                column: "Url",
                value: "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit");

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 284,
                columns: new[] { "Duration", "Position" },
                values: new object[] { 335, 1 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 285,
                columns: new[] { "Description", "Position" },
                values: new object[] { "Attend technical coaching session", 3 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 286,
                columns: new[] { "Description", "Position" },
                values: new object[] { "Check your WSPro statistics. Check your results. Find 2 insights and put it to WSPro Deck", 4 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 287,
                columns: new[] { "Description", "Url" },
                values: new object[] { "Prepare for CiC: Check the results of your submissions. Identify the hardest problem. Get review for WSPro insights and negative feedback slides.", "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 288,
                columns: new[] { "Duration", "Position" },
                values: new object[] { 395, 1 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 289,
                columns: new[] { "Description", "Position" },
                values: new object[] { "Attend technical coaching session", 2 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 290,
                columns: new[] { "Description", "Position" },
                values: new object[] { "Add 1 negative feedback to your Deck", 3 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 291,
                columns: new[] { "Description", "Duration", "Position" },
                values: new object[] { "Check your WSPro statistics. Check your results. Find 1 insight and put it to WSPro Deck", 30, 4 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 292,
                columns: new[] { "Description", "Position" },
                values: new object[] { "Address manager's feedback in your Deck", 5 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 293,
                column: "Url",
                value: "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit");

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 294,
                columns: new[] { "Duration", "Position" },
                values: new object[] { 425, 1 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 295,
                columns: new[] { "Description", "Position" },
                values: new object[] { "Attend technical coaching session", 2 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 296,
                columns: new[] { "IsDeleted", "Position" },
                values: new object[] { true, 3 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 297,
                columns: new[] { "IsDeleted", "Position" },
                values: new object[] { true, 4 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 298,
                columns: new[] { "Description", "Position" },
                values: new object[] { "Fill the NPS form to summarize your experience of the week; add the same feedback to your Deck", 5 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 299,
                columns: new[] { "Description", "Duration", "Position" },
                values: new object[] { "Read \"Enforcing Input Quality Bar\" and refine your backlog", 30, 1 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 300,
                columns: new[] { "Description", "Duration", "Position" },
                values: new object[] { "Read \"Find Tools to Improve Your Productivity\" and search for tools that will help to speed up", 30, 2 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 301,
                columns: new[] { "Description", "Duration", "Position" },
                values: new object[] { "Watch \"How to Make a Plan\" and create your plan of the week targeting a minimum of 3,75", 45, 3 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 302,
                columns: new[] { "IsDeleted", "Position" },
                values: new object[] { true, 5 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 303,
                columns: new[] { "Description", "Duration" },
                values: new object[] { "Read \"Seek Continuous Improvement and Experiment\" and learn how to scale your productivity systematically", 15 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 304,
                columns: new[] { "IsDeleted", "Position" },
                values: new object[] { true, 6 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 305,
                columns: new[] { "Description", "Position", "Url" },
                values: new object[] { "Prepare for CiC: Check the results of your submissions. Identify the hardest problem. Get review for automation idea slide.", 7, "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 306,
                columns: new[] { "IsDeleted", "Position" },
                values: new object[] { true, 8 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 307,
                columns: new[] { "Duration", "Position" },
                values: new object[] { 285, 9 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 308,
                columns: new[] { "IsDeleted", "Position" },
                values: new object[] { true, 10 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 309,
                columns: new[] { "Description", "Url" },
                values: new object[] { "Prepare for CiC: Check the results of your submissions. Identify the hardest problem. Get review for automation idea slide.", "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 310,
                columns: new[] { "IsDeleted", "Position" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 311,
                columns: new[] { "Duration", "Position" },
                values: new object[] { 420, 2 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 312,
                column: "Position",
                value: 3);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 313,
                columns: new[] { "Description", "Position" },
                values: new object[] { "Analyze TMS and compare with the previous week to identify the improvement after tool investigation, automation idea implementation and fixing knowledge gap; document the change in Deck", 4 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 314,
                columns: new[] { "IsDeleted", "Position" },
                values: new object[] { true, 5 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 315,
                columns: new[] { "IsDeleted", "Position" },
                values: new object[] { true, 6 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 316,
                columns: new[] { "Duration", "Url" },
                values: new object[] { 20, "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 317,
                columns: new[] { "Duration", "Position" },
                values: new object[] { 15, 1 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 318,
                columns: new[] { "IsDeleted", "Position" },
                values: new object[] { true, 2 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 319,
                columns: new[] { "Duration", "Position" },
                values: new object[] { 445, 3 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 320,
                columns: new[] { "Duration", "Url" },
                values: new object[] { 20, "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 321,
                columns: new[] { "IsDeleted", "Position" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 322,
                columns: new[] { "Duration", "Position" },
                values: new object[] { 460, 2 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 323,
                columns: new[] { "IsDeleted", "Position" },
                values: new object[] { true, 3 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 324,
                columns: new[] { "Duration", "Url" },
                values: new object[] { 20, "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 325,
                columns: new[] { "Duration", "Position" },
                values: new object[] { 450, 1 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 326,
                columns: new[] { "IsDeleted", "Position" },
                values: new object[] { true, 2 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 327,
                columns: new[] { "Description", "Position", "Url" },
                values: new object[] { "Fill the NPS form to summarize your experience of the week; add the same feedback to your Deck", 3, "https://docs.google.com/forms/d/e/1FAIpQLScAZm0PCkwy0OcxXxRLAery7D5DQSLqgVN-V2vIMWry_wa6oA/viewform" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 328,
                columns: new[] { "Description", "Duration" },
                values: new object[] { "Make a plan of deliverables", 5 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 329,
                columns: new[] { "Description", "Duration", "Position", "Url" },
                values: new object[] { "Identify your hardest problem and implement the fix", 60, 1, "" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 330,
                columns: new[] { "Description", "Position" },
                values: new object[] { "Analyze TMS and compare with the previous week to identify the improvement after tool investigation, automation idea implementation and fixing knowledge gap; document the change in Deck", 2 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 331,
                columns: new[] { "Duration", "Position" },
                values: new object[] { 385, 3 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 332,
                columns: new[] { "IsDeleted", "Url" },
                values: new object[] { true, "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 333,
                columns: new[] { "Duration", "Position" },
                values: new object[] { 480, 1 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 334,
                columns: new[] { "IsDeleted", "Position" },
                values: new object[] { true, 2 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 335,
                columns: new[] { "IsDeleted", "Position" },
                values: new object[] { true, 3 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 336,
                columns: new[] { "IsDeleted", "Url" },
                values: new object[] { true, "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 337,
                columns: new[] { "Duration", "Position" },
                values: new object[] { 480, 1 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 338,
                columns: new[] { "IsDeleted", "Url" },
                values: new object[] { true, "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 339,
                columns: new[] { "IsDeleted", "Position" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 340,
                columns: new[] { "Duration", "Position" },
                values: new object[] { 480, 2 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 341,
                columns: new[] { "IsDeleted", "Position" },
                values: new object[] { true, 3 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 342,
                columns: new[] { "IsDeleted", "Position", "Url" },
                values: new object[] { true, 1, "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 343,
                columns: new[] { "Duration", "Position" },
                values: new object[] { 435, 2 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 344,
                columns: new[] { "Description", "Position" },
                values: new object[] { "Fill \"My progress\", \"Highlights\" and the last improvement feedback in your Deck, and get the final review from your manager.", 3 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 345,
                columns: new[] { "IsDeleted", "Position" },
                values: new object[] { true, 4 });

            migrationBuilder.InsertData(
                table: "UserCalendarItemActions",
                columns: new[] { "Id", "AdditionalUrl", "Description", "Duration", "IsDeleted", "Position", "Url", "UserCalendarItemId" },
                values: new object[,]
                {
                    { 391, null, "Use ChatBot effectively to unblock yourself. Ask technical questions on the channel of your module. Use thumbs up for correct answers, thumbs down for wrong ones.", 5, false, 5, "", 29 },
                    { 387, null, "Review yesterday's submissions, take corrective actions on failures not to repeat them. Print a hard copy of a matrix with QBs and assignments. Check each submission against QBs before delivering.", 30, false, 0, "", 29 },
                    { 386, null, "Make a weekly plan for deliveries. Target a minimum of 2.5 for this week.", 10, false, 13, "https://remoteu.trilogy.com/plan", 28 },
                    { 385, null, "A ChatBot is available 24/7 to unblock you on Mattermost. Open Mattermost with the link and ask your first question: \"What is FTAR?\"", 2, false, 8, "https://xo.chat.crossover.com/core/channels/remoteu-general", 28 },
                    { 384, null, "Learn where to check when you are blocked due to a technical knowledge gap.", 4, false, 7, "https://docs.google.com/spreadsheets/d/1KjbpWYvB6dGFcowWlN2gAtNSsKsUDbgyixE-GSgdQBc/edit#gid=1053071476", 28 },
                    { 383, null, "Learn Input and Internal QBs of your module. Internalize them by watching the explanation videos. Print a physical copy of the quality bars and write down your understanding, assumptions and questions.", 60, false, 6, "https://docs.google.com/spreadsheets/d/1KjbpWYvB6dGFcowWlN2gAtNSsKsUDbgyixE-GSgdQBc/edit#gid=107425607", 28 },
                    { 382, null, "Get the list of assignments in Jira and do a preliminary analysis. Learn how the ticket details are set.", 20, false, 1, "https://crossover.atlassian.net/issues/?filter=-1", 28 },
                    { 381, null, "If you haven't confirmed before RemoteU, check if you have access to training materials, VPN and assignments. You should be a member of remotecamp-public Github group unless you are a QA Manual Tester.", 5, false, 0, "https://github.com/orgs/trilogy-group/teams/remotecamp-public/members", 28 },
                    { 380, null, "Read EngRemoteU Welcome email, watch kickoff calls and complete prerequisites", 50, false, 1, "", 27 },
                    { 389, null, "Read \"Make Automation Suggestions to Team Lead\" and come up with the idea that will boost your productivity. Identify your hardest problem and think about how you can eliminate it by using automation. Fill \"My automation suggestion to the Team Lead\" slide with the implementation plan", 45, false, 4, "https://drive.google.com/open?id=1WKGk2q2dfhP5_nB-HuQxzp04SIN4VL3gf2WlK7c5B9Q", 33 },
                    { 390, null, "Fill the NPS form to summarize your experience of the week; add the same feedback to your Deck", 5, false, 0, "https://docs.google.com/forms/d/e/1FAIpQLScAZm0PCkwy0OcxXxRLAery7D5DQSLqgVN-V2vIMWry_wa6oA/viewform", 42 },
                    { 388, null, "Study your TMS for this week and identify your hardest problem. Implement the fix.", 60, false, 2, "", 30 }
                });

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: @"You are technically and mentally prepared to the adventure. All is set up. 
Check if everything works fine and please don't start the tracker until Monday morning.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: @"You know your plan for this week.
You know how the tracker works.
You started your alignment with the Manager.
You started to work on your assignments and completed 5% of the weekly target");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: @"You know your failures.
You are identified your hardest problem and started to think how to resolve it,and discussed it with your manager.
You completed 40% of your weekly target.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: @"You planned your improvements.
You completed 65% of your weekly target.
Your WSPro deck has TMS and improvement plan linked.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: @"You started to fill WSPro deck with your insights.
You completed 95% of your weekly target.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: @"You have 2 WSPro insights in your deck.
You completed 100% of your weekly target.
You provided the NPS to the RC management.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: @"You know your plan for this week.
You started to work on your assignments and completed 20% of the weekly target.
You planned your improvements(by 25%) and documented it.
You found the tools to improve your productivity.You have 3 WSPro insights in your deck");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: @"You discussed your hardest problem with your manager.
You completed 45% of your weekly target.
You compared your results with the previous week and documented the changes.
You have 4 WSPro insights,1 negative feedback and 2 TMSs in your deck.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "Description",
                value: @"You completed 70% of your weekly target.
You completed the WSPro section in your deck.
You completed Negative feedback section of your deck");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: @"You completed 95% of your weekly target.
You reviewed WSPro section with your manager and addressed his feedback");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: @"You checked all failures and caught up with all the tasks undone for this week.
You created the draft of your idea to double the productivity.
You provided the NPS to the RC management.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: @"You know your plan for this week.
You started to work on your assignments and completed 20% of the weekly target.
You planned your improvements(by 25%) and documented it.
You refined your idea to double the productivity.
You added 1 feedback about the RC to your deck");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "Description",
                value: @"You discussed your hardest problem with your manager.
You completed 45% of your weekly target.
You compared your results with the previous week and documented the changes.
You have 2 feedbacks to RC in your deck");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "Description",
                value: @"You completed 70% of your weekly target.
You completed the ""Provide feedback"" section in your deck");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "Description",
                value: @"You completed 95% of your weekly target.
You reviewed WSPro section,Provide feedback,Negative feedback sections with your manager and addressed his feedback");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "Description",
                value: @"You checked all failures and caught up with all the tasks undone for this week.
You refined your idea to double the productivity based on the results of the previous week.
Your WSPro deck is ready except the final results page.
You provided the NPS to the RC management.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 17,
                column: "Description",
                value: @"You know your plan for this week.
You started to work on your assignments and completed 25% of the weekly target.
You planned your improvements(by 25%) and documented it.
You refined your idea to double the productivity.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 18,
                column: "Description",
                value: @"You discussed your hardest problem with your manager.
You completed 50% of your weekly target.
You compared your results with the previous week and documented the changes.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 19,
                column: "Description",
                value: @"You completed 75% of your weekly target.
You filled the ""Results"" section of your deck(prev.3 weeks)");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 20,
                column: "Description",
                value: @"You completed 100% of your weekly target.
You addressed all the feedbacks and your WSPro deck is ready");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "Description",
                value: @"You checked all failures and caught up with all the tasks undone for this week.
You have graduated from the RemoteCamp.
You enjoy your party on this occasion.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "Description",
                value: @"You are technically and mentally prepared to the adventure. 
All is set up. Check if everything works fine and please don't start the tracker until Monday morning.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "Description",
                value: "You will work in IC RemoteU during the first week; our advice is to start preparations for EngRemoteU only after delivering all IC RemoteU related materials.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 24,
                column: "Description",
                value: "You will work in IC RemoteU during the first week; our advice is to start preparations for EngRemoteU only after delivering all IC RemoteU related materials.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 25,
                column: "Description",
                value: "You will work in IC RemoteU during the first week; our advice is to start preparations for EngRemoteU only after delivering all IC RemoteU related materials.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 26,
                column: "Description",
                value: "You will work in IC RemoteU during the first week; our advice is to start preparations for EngRemoteU only after delivering all IC RemoteU related materials.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 27,
                column: "Description",
                value: "You will work in IC RemoteU during the first week; our advice is to start preparations for EngRemoteU only after delivering all IC RemoteU related materials.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 28,
                column: "Description",
                value: @"You;
* know your plan for this week and have resolved all your issues regarding accesses, backlog and technical assignments.
* know the list of quality bars and have printed a hard copy for yourself
* have completed all the training materials of the week.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 29,
                column: "Description",
                value: @"You;
* have your local setup ready.
* have delivered units and received feedback from the reviewers.
* have identified your failures and taken actions to resolve them.
* have identified your hardest problem and discussed it with your manager.
* have your first WSPro insight and negative feedback on your Deck.
The quality of your work is improving as you have a quality bar - assignments matrix and checking submissions against QBs one by one. ");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 30,
                column: "Description",
                value: @"You;
* have completed 60% of the weekly target. 
* have 3 WSPro insights on your Deck. 
* know how to be prepared for the meetings.
* have resolved any technical gaps.
* have an improving FTAR.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 31,
                column: "Description",
                value: @"You;
* have completed 80% of your weekly target. 
* have completed WSPro insights and negative feedback sections of Deck and addressed review feedbacks of your manager. 
* have TMS study added for the current week and fixed your hardest problem of the week.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 32,
                column: "Description",
                value: @"You;
* have completed 100% of your weekly target.
* are an expert of quality who knows how to produce 100% FTAR and make great RCAs.
* have provided NPS feedback to RU and added the same feedback to your Deck.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 33,
                column: "Description",
                value: @"You;
* target at least 3,75 points for this week in your plan.
* have completed 20% of the weekly goal.
* have gone through all productivity-related training materials.
* have your automation idea ready in your Deck.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 34,
                column: "Description",
                value: @"You;
* have completed 40% of the weekly target. 
* have analyzed TMS of the second week and validated your productivity increase after the implementation of the automation idea.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 35,
                column: "Description",
                value: "You have completed 60% of your weekly target.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 36,
                column: "Description",
                value: "You have completed 60% of your weekly target.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 37,
                column: "Description",
                value: @"You;
* have completed 100% of your weekly target by delivering 100% quality. 
* have provided the NPS feedback of the week and added the same feedback to your Deck.
Congratulations! You are as productive as the team average and ready for the big challenge of the final week.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 38,
                column: "Description",
                value: @"You;
* are targeting to hit the performance of a top performer this week, so the target is a minimum of 5 points and 100% quality.
* have delivered 1 point today.
* have analyzed your TMS and have implemented the improvements.
Remember that this is the hands-off week, so there is no CiC with the manager.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 39,
                column: "Description",
                value: "You have delivered 1 point today with 100% quality.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 40,
                column: "Description",
                value: "You have delivered 1 point today with 100% quality.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 41,
                column: "Description",
                value: "You have delivered 1 point today with 100% quality.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 42,
                column: "Description",
                value: @"You;
* have delivered 5 points this week with 100% quality.
* have provided the feedback of the last week.
* have finalized your Deck and had the final review with your manager.
* You are ready for the graduation panel.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 380);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 381);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 382);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 383);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 385);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 386);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 387);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 389);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 390);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 391);

            migrationBuilder.DropColumn(
                name: "Position",
                table: "UserCalendarItemActions");

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 160,
                column: "Description",
                value: @"Analyse your last week performance. Plan this week improvements, document this plan. 
                                        Search the tools to improve your productivity.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 245,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 246,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 247,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 248,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 249,
                columns: new[] { "Description", "Duration", "UserCalendarItemId" },
                values: new object[] { "Read \"The Factory Model for Elite ICs\"", 6, 22 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 250,
                columns: new[] { "Description", "Duration", "UserCalendarItemId" },
                values: new object[] { "Read \"How you can fail in RemoteU\"", 9, 22 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 251,
                columns: new[] { "Description", "Duration", "UserCalendarItemId" },
                values: new object[] { "Watch \"Anti-cheating policy\"", 28, 22 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 252,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 253,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 254,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 255,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 256,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 257,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 263,
                columns: new[] { "Description", "IsDeleted" },
                values: new object[] { @"Get the list of assignments (jira) and do a preliminary analysis. 
                                        Form your Input Quality Bar and use QnA sheet to ask questions for the assignments which are not clear.", false });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 264,
                columns: new[] { "Description", "Duration" },
                values: new object[] { "\"Be an expert / Tackle the hardest problem\"", 10 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 265,
                columns: new[] { "Description", "Duration" },
                values: new object[] { "Read \"Improving quality and productivity\"", 8 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 266,
                columns: new[] { "Description", "Duration" },
                values: new object[] { "Read \"How to deliver 100% quality?\"", 9 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 267,
                columns: new[] { "Description", "Duration" },
                values: new object[] { "Read \"Root Cause Analysis\"", 12 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 268,
                columns: new[] { "Description", "Duration" },
                values: new object[] { "Read \"Put yourself in customer shoes\"", 5 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 269,
                columns: new[] { "Description", "IsDeleted" },
                values: new object[] { @"Make a weekly plan of deliveries. 
                                        Recommended distribution of load is: 20/25/25/25/5+fix+catchup.", false });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 270,
                columns: new[] { "Description", "Url" },
                values: new object[] { @"Prepare for CiC: Check the results of your submissions. 
                                        Identify the hardest problem.", "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 271,
                columns: new[] { "Description", "IsDeleted" },
                values: new object[] { @"Analyse your last week performance. Plan this week improvements, document this plan. 
                                        Search the tools to improve your productivity.", false });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 272,
                columns: new[] { "Description", "Duration", "Url" },
                values: new object[] { "Development work.", 55, "" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 273,
                columns: new[] { "Description", "Duration", "Url" },
                values: new object[] { @"Ask technical questions to mentors, setup projects, watch and read technical documentation applicable to your track. 
                                        Align with your mentor on Internal Quality Bars, have no different opinion. 
                                        Create a physical sheet of quality bars and assignment matrix.", 240, "https://docs.google.com/spreadsheets/d/1KjbpWYvB6dGFcowWlN2gAtNSsKsUDbgyixE-GSgdQBc/edit#gid=0" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 274,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 275,
                columns: new[] { "Description", "Duration" },
                values: new object[] { "Give Improvement Feedback", 6 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 276,
                columns: new[] { "Description", "Duration", "Url" },
                values: new object[] { "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 277,
                columns: new[] { "Duration", "Url" },
                values: new object[] { 400, "" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 279,
                columns: new[] { "Description", "Duration", "Url" },
                values: new object[] { "Compare TMS for this week and the previous, document the changes", 16, "" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 280,
                columns: new[] { "Description", "Url" },
                values: new object[] { "Technical coaching session", "" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 281,
                columns: new[] { "Description", "Duration", "Url" },
                values: new object[] { "Add 1 WSPro insight to WSPro deck", 10, "" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 282,
                columns: new[] { "Description", "Duration", "Url" },
                values: new object[] { "Add 1 Negative feedback to WSPro deck", 9, "" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 283,
                column: "Url",
                value: "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)");

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 284,
                column: "Duration",
                value: 395);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 285,
                column: "Description",
                value: "Technical coaching session");

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 286,
                column: "Description",
                value: "Check your WSPro statistics. Check your results. Find 1 insight and put it to WSPro deck");

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 287,
                columns: new[] { "Description", "Url" },
                values: new object[] { "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 288,
                column: "Duration",
                value: 385);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 289,
                column: "Description",
                value: "Technical coaching session");

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 290,
                column: "Description",
                value: "Add 1 negative feedback to your deck");

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 291,
                columns: new[] { "Description", "Duration" },
                values: new object[] { "Check your WSPro statistics. Check your results. Find 1 insight and put it to WSPro deck", 40 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 292,
                column: "Description",
                value: "Address manager's feedback in your deck");

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 293,
                column: "Url",
                value: "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)");

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 294,
                column: "Duration",
                value: 295);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 295,
                column: "Description",
                value: "Technical coaching session");

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 296,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 297,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 298,
                column: "Description",
                value: "Fill the NPS RemoteCamp form to summarize your experience of the week");

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 299,
                columns: new[] { "Description", "Duration" },
                values: new object[] { "Read \"Enforcing Input Quality Bar\"", 10 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 300,
                columns: new[] { "Description", "Duration" },
                values: new object[] { "Read \"Find Tools to Improve Your Productivity\"", 7 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 301,
                columns: new[] { "Description", "Duration" },
                values: new object[] { "Watch \"How to Make a Plan\"", 38 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 302,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 303,
                columns: new[] { "Description", "Duration" },
                values: new object[] { "Read \"Seek Continuous Improvement and Experiment\"", 10 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 304,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 305,
                columns: new[] { "Description", "Url" },
                values: new object[] { "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 306,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 307,
                column: "Duration",
                value: 300);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 308,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 309,
                columns: new[] { "Description", "Url" },
                values: new object[] { "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 310,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 311,
                column: "Duration",
                value: 365);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 313,
                column: "Description",
                value: "Compare TMS for this week and the previous, document the changes");

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 314,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 315,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 316,
                columns: new[] { "Duration", "Url" },
                values: new object[] { 30, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 317,
                column: "Duration",
                value: 30);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 318,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 319,
                column: "Duration",
                value: 380);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 320,
                columns: new[] { "Duration", "Url" },
                values: new object[] { 30, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 321,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 322,
                column: "Duration",
                value: 410);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 323,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 324,
                columns: new[] { "Duration", "Url" },
                values: new object[] { 30, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 325,
                column: "Duration",
                value: 350);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 326,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 327,
                columns: new[] { "Description", "Url" },
                values: new object[] { "Fill the NPS RemoteCamp form to summarize your experience of the week", "" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 328,
                columns: new[] { "Description", "Duration" },
                values: new object[] { "Make a weekly plan of deliveries. Recommended distribution of load is: 25/25/25/25/fix+catchup", 30 });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 329,
                columns: new[] { "Description", "Duration", "Url" },
                values: new object[] { "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 330,
                column: "Description",
                value: "Analyse your last week performance. Plan this week improvements, document this plan. Search the tools to improve your productivity.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 331,
                column: "Duration",
                value: 390);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 332,
                columns: new[] { "IsDeleted", "Url" },
                values: new object[] { false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 333,
                column: "Duration",
                value: 420);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 334,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 335,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 336,
                columns: new[] { "IsDeleted", "Url" },
                values: new object[] { false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 337,
                column: "Duration",
                value: 450);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 338,
                columns: new[] { "IsDeleted", "Url" },
                values: new object[] { false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 339,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 340,
                column: "Duration",
                value: 410);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 341,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 342,
                columns: new[] { "IsDeleted", "Url" },
                values: new object[] { false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)" });

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 343,
                column: "Duration",
                value: 395);

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 344,
                column: "Description",
                value: "Fill the \"My progress\" and highlights sections in the deck");

            migrationBuilder.UpdateData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 345,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: @"You are technically and mentally prepared to the adventure. All is set up. 
                                Check if everything works fine and please don't start the tracker until Monday morning.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: @"You know your plan for this week.
                                You know how the tracker works.
                                You started your alignment with the Manager.
                                You started to work on your assignments and completed 5% of the weekly target");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: @"You know your failures.
                                You are identified your hardest problem and started to think how to resolve it,and discussed it with your manager.
                                You completed 40% of your weekly target.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: @"You planned your improvements.
                                You completed 65% of your weekly target.
                                Your WSPro deck has TMS and improvement plan linked.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: @"You started to fill WSPro deck with your insights.
                                You completed 95% of your weekly target.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: @"You have 2 WSPro insights in your deck.
                                You completed 100% of your weekly target.
                                You provided the NPS to the RC management.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: @"You know your plan for this week.
                                You started to work on your assignments and completed 20% of the weekly target.
                                You planned your improvements(by 25%) and documented it.
                                You found the tools to improve your productivity.You have 3 WSPro insights in your deck");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: @"You discussed your hardest problem with your manager.
                                You completed 45% of your weekly target.
                                You compared your results with the previous week and documented the changes.
                                You have 4 WSPro insights,1 negative feedback and 2 TMSs in your deck.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "Description",
                value: @"You completed 70% of your weekly target.
                                You completed the WSPro section in your deck.
                                You completed Negative feedback section of your deck");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: @"You completed 95% of your weekly target.
                                You reviewed WSPro section with your manager and addressed his feedback");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: @"You checked all failures and caught up with all the tasks undone for this week.
                                You created the draft of your idea to double the productivity.
                                You provided the NPS to the RC management.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: @"You know your plan for this week.
                                You started to work on your assignments and completed 20% of the weekly target.
                                You planned your improvements(by 25%) and documented it.
                                You refined your idea to double the productivity.
                                You added 1 feedback about the RC to your deck");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "Description",
                value: @"You discussed your hardest problem with your manager.
                                You completed 45% of your weekly target.
                                You compared your results with the previous week and documented the changes.
                                You have 2 feedbacks to RC in your deck");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "Description",
                value: @"You completed 70% of your weekly target.
                                You completed the ""Provide feedback"" section in your deck");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "Description",
                value: @"You completed 95% of your weekly target.
                                You reviewed WSPro section,Provide feedback,Negative feedback sections with your manager and addressed his feedback");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "Description",
                value: @"You checked all failures and caught up with all the tasks undone for this week.
                                You refined your idea to double the productivity based on the results of the previous week.
                                Your WSPro deck is ready except the final results page.
                                You provided the NPS to the RC management.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 17,
                column: "Description",
                value: @"You know your plan for this week.
                                You started to work on your assignments and completed 25% of the weekly target.
                                You planned your improvements(by 25%) and documented it.
                                You refined your idea to double the productivity.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 18,
                column: "Description",
                value: @"You discussed your hardest problem with your manager.
                                You completed 50% of your weekly target.
                                You compared your results with the previous week and documented the changes.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 19,
                column: "Description",
                value: @"You completed 75% of your weekly target.
                                You filled the ""Results"" section of your deck(prev.3 weeks)");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 20,
                column: "Description",
                value: @"You completed 100% of your weekly target.
                                You addressed all the feedbacks and your WSPro deck is ready");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "Description",
                value: @"You checked all failures and caught up with all the tasks undone for this week.
                                You have graduated from the RemoteCamp.
                                You enjoy your party on this occasion.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "Description",
                value: @"You are technically and mentally prepared to the adventure. 
                                All is set up. Check if everything works fine and please don't start the tracker until Monday morning.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "Description",
                value: "This week is reserved for IC RemoteU");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 24,
                column: "Description",
                value: "This week is reserved for IC RemoteU");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 25,
                column: "Description",
                value: "This week is reserved for IC RemoteU");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 26,
                column: "Description",
                value: "This week is reserved for IC RemoteU");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 27,
                column: "Description",
                value: "This week is reserved for IC RemoteU");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 28,
                column: "Description",
                value: @"You know your plan for this week.
                                You started to work on your assignments and completed 20% of the weekly target.
                                You planned your improvements(by 25%) and documented it.
                                You found the tools to improve your productivity.You have 3 WSPro insights in your deck");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 29,
                column: "Description",
                value: @"You discussed your hardest problem with your manager.
                                You completed 45% of your weekly target.You compared your results with the previous week and documented the changes.
                                You have 4 WSPro insights,1 negative feedback and 2 TMSs in your deck");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 30,
                column: "Description",
                value: @"You completed 70% of your weekly target.
                                You completed the WSPro section in your deck.
                                You completed Negative feedback section of your deck");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 31,
                column: "Description",
                value: @"You completed 95% of your weekly target.
                                You reviewed WSPro section with your manager and addressed his feedback");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 32,
                column: "Description",
                value: @"You checked all failures and caught up with all the tasks undone for this week.
                                You created the draft of your idea to double the productivity.
                                You provided the NPS to the RC management.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 33,
                column: "Description",
                value: @"You know your plan for this week.You started to work on your assignments and completed 20% of the weekly target.
                                You planned your improvements(by 25%) and documented it.
                                You refined your idea to double the productivity.
                                You added 1 feedback about the RC to your deck");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 34,
                column: "Description",
                value: @"You discussed your hardest problem with your manager.You completed 45% of your weekly target.
                                You compared your results with the previous week and documented the changes.
                                You have 2 feedbacks to RC in your deck");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 35,
                column: "Description",
                value: "You completed 70% of your weekly target.You completed the \"Provide feedback\" section in your deck");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 36,
                column: "Description",
                value: @"You completed 95% of your weekly target.
                                You reviewed WSPro section,Provide feedback,Negative feedback sections with your manager and addressed his feedback");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 37,
                column: "Description",
                value: @"You checked all failures and caught up with all the tasks undone for this week.
                                You refined your idea to double the productivity based on the results of the previous week.
                                Your WSPro deck is ready except the final results page.You provided the NPS to the RC management.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 38,
                column: "Description",
                value: @"You know your plan for this week.
                                You started to work on your assignments and completed 25% of the weekly target.
                                You planned your improvements(by 25%) and documented it.
                                You refined your idea to double the productivity.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 39,
                column: "Description",
                value: @"You discussed your hardest problem with your manager.
                                You completed 50% of your weekly target.
                                You compared your results with the previous week and documented the changes.");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 40,
                column: "Description",
                value: "You completed 75% of your weekly target.You filled the \"Results\" section of your deck(prev.3 weeks).");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 41,
                column: "Description",
                value: @"You completed 100% of your weekly target.
                                You addressed all the feedbacks and your WSPro deck is ready");

            migrationBuilder.UpdateData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 42,
                column: "Description",
                value: @"You checked all failures and caught up with all the tasks undone for this week.
                                You have graduated from the RemoteCamp.
                                You enjoy your party on this occasion.");
        }
    }
}
