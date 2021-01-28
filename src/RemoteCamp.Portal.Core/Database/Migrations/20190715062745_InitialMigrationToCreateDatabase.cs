using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RemoteCamp.Portal.Core.Database.Migrations
{
    public partial class InitialMigrationToCreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserCalendarItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WeekNumber = table.Column<int>(nullable: false),
                    Day = table.Column<string>(maxLength: 10, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCalendarItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 320, nullable: true),
                    RcXoId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserCalendarItemActions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Url = table.Column<string>(maxLength: 2083, nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    UserCalendarItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCalendarItemActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCalendarItemActions_UserCalendarItems_UserCalendarItemId",
                        column: x => x.UserCalendarItemId,
                        principalTable: "UserCalendarItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCalendarItemStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserCalendarItemId = table.Column<int>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCalendarItemStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCalendarItemStatus_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserCalendarItems",
                columns: new[] { "Id", "Day", "Description", "WeekNumber" },
                values: new object[,]
                {
                    { 1, "Friday", "You are technically and mentally prepared to the adventure. All is set up. Your assignments will be available on Monday.", 0 },
                    { 19, "Wednesday", @"You completed 75% of your weekly target.
                                                 You filled the ""Results"" section of your deck(prev.3 weeks)", 4 },
                    { 18, "Tuesday", @"You discussed your hardest problem with your manager.
                                                You completed 50% of your weekly target.
                                                You compared your results with the previous week and documented the changes.", 4 },
                    { 17, "Monday", @"You know your plan for this week.
                                                You started to work on your assignments and completed 25% of the weekly target.
                                                You planned your improvements(by 25%) and documented it.
                                                You refined your idea to double the productivity.", 4 },
                    { 16, "Friday", @"You checked all failures and caught up with all the tasks undone for this week.
                                                You refined your idea to double the productivity based on the results of the previous week.
                                                Your WSPro deck is ready except the final results page.
                                                You provided the NPS to the RC management.", 3 },
                    { 15, "Thursday", @"You completed 100% of your weekly target.
                                                You reviewed WSPro section,
                                                Provide feedback,
                                                Negative feedback sections with your manager and addressed his feedback", 3 },
                    { 14, "Wednesday", @"You completed 75% of your weekly target.
                                                You completed the ""Provide feedback"" section in your deck", 3 },
                    { 13, "Tuesday", @"You discussed your hardest problem with your manager.
                                                You completed 50% of your weekly target.
                                                You compared your results with the previous week and documented the changes.
                                                You have 2 feedbacks to RC in your deck", 3 },
                    { 12, "Monday", @"You know your plan for this week.
                                                You started to work on your assignments and completed 25% of the weekly target.
                                                You planned your improvements(by 25%) and documented it.
                                                You refined your idea to double the productivity.
                                                You added 1 feedback about the RC to your deck", 3 },
                    { 20, "Thursday", @"You completed 100% of your weekly target.
                                                You addressed all the feedbacks and your WSPro deck is ready", 4 },
                    { 11, "Friday", @"You checked all failures and caught up with all the tasks undone for this week.
                                                You created the draft of your idea to double the productivity.
                                                You provided the NPS to the RC management.", 2 },
                    { 9, "Wednesday", @"You completed 75% of your weekly target.
                                                You completed the WSPro section in your deck
                                                You completed Negative feedback section of your deck", 2 },
                    { 8, "Tuesday", @"You discussed your hardest problem with your manager.
                                                You completed 50% of your weekly target.
                                                You compared your results with the previous week and documented the changes.
                                                You have 4 WSPro insights,
                                                1 negative feedback and 2 TMSs in your deck", 2 },
                    { 7, "Monday", @"You know your plan for this week.
                                                You started to work on your assignments and completed 25% of the weekly target.
                                                You planned your improvements(by 25%) and documented it.
                                                You found the tools to improve your productivity.
                                                You have 3 WSPro insights in your deck", 2 },
                    { 6, "Friday", @"You have 2 WSPro insights in your deck.
                                                You completed 100% of your weekly target.
                                                You provided the NPS to the RC management.", 1 },
                    { 5, "Thursday", @"You started to fill WSPro deck with your insights.
                                                You completed 90% of your weekly target.", 1 },
                    { 4, "Wednesday", @"You planned your improvements.
                                                You completed 70% of your weekly target.
                                                Your WSPro deck has TMS and improvement plan linked.", 1 },
                    { 3, "Tuesday", @"You know your failures.
                                                You are identified your hardest problem and started to think how to resolve it,
                                                and discussed it with your manager.
                                                You completed 40% of your weekly target.", 1 },
                    { 2, "Monday", @"You know your plan for this week.
                                                You know how the tracker works.
                                                You started your alignment with the Manager.
                                                You started to work on your assignments and completed 10% of the weekly target", 1 },
                    { 10, "Thursday", @"You completed 100% of your weekly target.
                                                You reviewed WSPro section with your manager and addressed his feedback", 2 },
                    { 21, "Friday", @"You checked all failures and caught up with all the tasks undone for this week.
                                                You have graduated from the RemoteCamp.
                                                You enjoy your party on this occasion.", 4 }
                });

            migrationBuilder.InsertData(
                table: "UserCalendarItemActions",
                columns: new[] { "Id", "Description", "Duration", "Url", "UserCalendarItemId" },
                values: new object[,]
                {
                    { 1, "Get and read the welcome email from RemoteCamp management", 10, "", 1 },
                    { 88, "Technical coaching session", 30, "", 14 },
                    { 87, "Development work", 380, "", 14 },
                    { 86, "Check the results of your submissions. Identify the hardest problem.", 30, "", 14 },
                    { 85, "Add 1 feedback about the RC to WSPro deck", 30, "", 13 },
                    { 84, "Technical coaching session", 30, "", 13 },
                    { 83, "Compare TMS for this week and the previous, document the changes", 30, "", 13 },
                    { 82, "Make TMS video of 1 unit produced", 0, "", 13 },
                    { 81, "Development work", 350, "", 13 },
                    { 80, "CiC with Manager, discuss your innovation idea", 10, "", 13 },
                    { 79, "Check the results of your submissions. Identify the hardest problem.", 30, "", 13 },
                    { 78, "Add 1 feedback about the RC to the WSPro deck", 20, "", 12 },
                    { 77, "Development work", 370, "", 12 },
                    { 89, "Finish RC feedback section in your deck", 40, "", 14 },
                    { 76, "Analyse your last week performance. Plan this week improvements, document this plan. Search the tools to improve your productivity.", 30, "", 12 },
                    { 74, "Make a weekly plan of deliveries. Recommended distribution of load is: 25/25/25/25/fix+catchup", 30, "", 12 },
                    { 73, "Fill the NPS RemoteCamp form to summarize your experience of the week", 10, "", 11 },
                    { 72, "Prepare your automation idea to double your productivity. Send to your manager for approval", 90, "", 11 },
                    { 71, "Development work", 350, "", 11 },
                    { 70, "Check the results of your submissions. Identify the hardest problem.", 30, "", 11 },
                    { 69, "Address manager\"''\"s feedback in your deck", 15, "", 10 },
                    { 68, "Add 1 negative feedback to your deck", 15, "", 10 },
                    { 67, "Technical coaching session", 30, "", 10 },
                    { 66, "Development work", 380, "", 10 },
                    { 65, "CiC with Manager, ask for negative feedback", 10, "", 10 },
                    { 64, "Check the results of your submissions. Identify the hardest problem.", 30, "", 10 },
                    { 63, "Finish WSPro page in deck", 40, "", 9 },
                    { 75, "Check the results of your submissions. Identify the hardest problem.", 30, "", 12 },
                    { 90, "Check the results of your submissions. Identify the hardest problem.", 30, "", 15 },
                    { 91, "CiC with Manager, review deck", 10, "", 15 },
                    { 92, "Development work", 380, "", 15 },
                    { 119, "Development work", 420, "", 21 },
                    { 118, "Check the results of your submissions. Identify the hardest problem.", 30, "", 21 },
                    { 117, "Address manager\"''\"s feedback in your deck", 30, "", 20 },
                    { 116, "Technical coaching session", 30, "", 20 },
                    { 115, "Development work", 380, "", 20 },
                    { 114, "CiC with Manager, final review deck, ask for the feedback", 10, "", 20 },
                    { 113, "Check the results of your submissions. Identify the hardest problem.", 30, "", 20 },
                    { 112, "Fill the \"Results\" section in the deck (previous 3 weeks)", 20, "", 19 },
                    { 111, "Technical coaching session", 30, "", 19 },
                    { 110, "Development work", 400, "", 19 },
                    { 109, "Check the results of your submissions. Identify the hardest problem.", 30, "", 19 },
                    { 108, "Technical coaching session", 30, "", 18 },
                    { 107, "Compare TMS for this week and the previous, document the changes", 30, "", 18 },
                    { 106, "Make TMS video of 1 unit produced", 0, "", 18 },
                    { 105, "Development work", 380, "", 18 },
                    { 104, "CiC with Manager, discuss your improvements during the previous weeks and the further directions to improve, ask for the feedback", 10, "", 18 },
                    { 103, "Check the results of your submissions. Identify the hardest problem.", 30, "", 18 },
                    { 102, "Development work", 390, "", 17 },
                    { 101, "Analyse your last week performance. Plan this week improvements, document this plan. Search the tools to improve your productivity.", 30, "", 17 },
                    { 100, "Check the results of your submissions. Identify the hardest problem.", 30, "", 17 },
                    { 99, "Make a weekly plan of deliveries. Recommended distribution of load is: 25/25/25/25/fix+catchup", 30, "", 17 },
                    { 98, "Fill the NPS RemoteCamp form to summarize your experience of the week", 10, "", 16 },
                    { 97, "Check the results of your automation idea, refine it.", 90, "", 16 },
                    { 96, "Development work", 350, "", 16 },
                    { 95, "Check the results of your submissions. Identify the hardest problem.", 30, "", 16 },
                    { 94, "Address manager\"''\"s feedback in your deck", 30, "", 15 },
                    { 93, "Technical coaching session", 30, "", 15 },
                    { 62, "Technical coaching session", 30, "", 9 },
                    { 120, "Fill the results for the last week to your deck", 10, "", 21 },
                    { 61, "Development work", 380, "", 9 },
                    { 59, "Add 1 Negative feedback to WSPro deck", 15, "", 8 },
                    { 27, "Read \"Find Tools That Improve Your Own Productivity\"", 5, "https://drive.google.com/open?id=1wKKuzWFiL6nDIrq9aNSss6EqKugZNgJku57gfdolcCM", 4 },
                    { 26, "Create your copy of WSPro deck, add your TMS.", 39, "https://docs.google.com/document/u/1/d/1oc5kgAfOZgvOhvwHjLjyZJmPKkxMmwtg7vt-rncW1ss/edit", 3 },
                    { 25, "Technical coaching session", 30, "", 3 },
                    { 24, "\"Be an expert / Tackle the hardest problem\"", 6, "https://drive.google.com/open?id=1IN3V4uEnjL2J5AnwdDmIABwCr3d6fzEJE_tDG7qXdqM", 3 },
                    { 23, "Make TMS video of 1 unit produced", 0, "https://drive.google.com/file/d/0BzSXGty9sV6KRGp1aHNPa2dkWTQ/view", 3 },
                    { 22, "Development work", 350, "", 3 },
                    { 21, "CiC with Manager", 15, "", 3 },
                    { 20, "Check the results of your submissions. Identify the hardest problem.", 30, "", 3 },
                    { 19, "Read \"Seek Continuous Improvement / Experiment\"", 10, "https://drive.google.com/open?id=1-4Zoh9MeXadFMxmF9sgsaP-4jK0VWCFBrr7urCaenDA", 3 },
                    { 18, "Read \"Welcome Negative feedback\"", 5, "https://drive.google.com/open?id=1QNGyddEVA6mO8sbi4CZ8M-XxaybskglUP38gSqEgtmo", 2 },
                    { 17, "Development work", 160, "", 2 },
                    { 16, "Ask technical questions, setup projects, understand the requirements to the job done (IQBs), watch and read technical documentation applicable to your track", 240, "", 2 },
                    { 28, "Check the results of your submissions. Identify the hardest problem.", 30, "", 4 },
                    { 15, "CiC with Manager", 15, "", 2 },
                    { 13, "Get the list of assignments (jira) and go through it", 30, "", 2 },
                    { 12, "Watch \"Tackling the Hardest Problem\"", 24, "https://drive.google.com/open?id=1WbcAloWNZjJrWsYrFItyFUAmehm64ZFd", 1 },
                    { 11, "Watch \"Anti-cheating policy\"", 28, "https://drive.google.com/open?id=1ToaleLywRtkhudjxBH9nCZAvdY1G27SH", 1 },
                    { 10, "Read \"CiC Framework\"", 15, "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit", 1 },
                    { 9, "Read \"Intensity and focus blocks\"", 8, "https://drive.google.com/open?id=1dJPwpR5BREoMZa8CV2sVkwUYuaAZDg0AokvkvHhIH-Q", 1 },
                    { 8, "Read \"Worksmart tool certified\"", 5, "https://drive.google.com/open?id=1yjIVcSKnAtgIgZ52W2jPDb9OC8K6RvOb5V2n1KOmCBs", 1 },
                    { 7, "Watch \"Quality-30/01/2019.mp4\"", 27, "https://drive.google.com/drive/u/0/folders/1eiGuCV72FUWezStfqNq_KCXXgIuratjm", 1 },
                    { 6, "Read \"How will you pass the RemoteCamp\"", 6, "https://drive.google.com/open?id=1TE952cAjQo_MTVxBNKB4F4GsrwmFNMEI3JXXilS_M0Y", 1 },
                    { 5, "Read \"Quality and common terms we use\"", 7, "https://drive.google.com/open?id=13x4k7OlM-qoZIfwnr3FqeQKpMBmOJ5VD0IEsGiSMOvM", 1 },
                    { 4, "Kick-off call", 60, "", 1 },
                    { 3, "Report non-working accesses to the RemoteCamp SEM", 20, "", 1 },
                    { 2, "Check all the accesses (todo: add which exactly)", 60, "", 1 },
                    { 14, "Make a weekly plan of deliveries. Recommended distribution of load is: 10/30/30/20/10+fix+catchup.", 30, "", 2 },
                    { 29, "CiC with Manager", 15, "", 4 },
                    { 30, "Development work", 350, "", 4 },
                    { 31, "Read \"Improving quality and productivity\"", 6, "https://drive.google.com/open?id=12M7I2E4T47bk0jKprtdlsd8gt9iN4NVP7P4KLq-uv38", 4 },
                    { 58, "Add 1 WSPro insight to WSPro deck", 15, "", 8 },
                    { 57, "Technical coaching session", 30, "", 8 },
                    { 56, "Compare TMS for this week and the previous, document the changes", 30, "", 8 },
                    { 55, "Make TMS video of 1 unit produced", 0, "", 8 },
                    { 54, "Development work", 350, "", 8 },
                    { 53, "CiC with Manager, ask for the negative feedback", 10, "", 8 },
                    { 52, "Check the results of your submissions. Identify the hardest problem.", 30, "", 8 },
                    { 51, "Add 1 WSPro insight to WSPro deck", 25, "", 7 },
                    { 50, "Development work", 360, "", 7 },
                    { 49, "Analyse your last week performance. Plan this week improvements, document this plan. Search the tools to improve your productivity.", 30, "", 7 },
                    { 48, "Check the results of your submissions. Identify the hardest problem.", 30, "", 7 },
                    { 47, "Read \"Make Automations Suggestions to Team Lead\"", 5, "https://drive.google.com/open?id=1WKGk2q2dfhP5_nB-HuQxzp04SIN4VL3gf2WlK7c5B9Q", 7 },
                    { 46, "Make a weekly plan of deliveries. Recommended distribution of load is: 25/25/25/25/fix+catchup", 30, "https://drive.google.com/open?id=1YMslqRjd3tedFUXgUjHKZqjegXpF9Swn", 7 },
                    { 45, "Fill the NPS RemoteCamp form to summarize your experience of the week", 7, "", 6 },
                    { 44, "Check your WSPro statistics. Check your results. Find 1 insight and put it to WSPro deck", 44, "", 6 },
                    { 43, "Read \"Give Improvement Feedback\"", 6, "https://drive.google.com/open?id=1Mt1HyCnSsU69yBmndtY0pYxtN787OD-gkjJpA3XLjeE", 6 },
                    { 42, "Development work", 380, "", 6 },
                    { 41, "CiC with Manager", 15, "", 6 },
                    { 40, "Check the results of your submissions. Identify the hardest problem.", 30, "", 6 },
                    { 39, "Check your WSPro statistics. Check your results. Find 1 insight and put it to WSPro deck", 44, "", 5 },
                    { 38, "Read \"Put yourself in Customer\"''\"s shoes\"", 6, "https://drive.google.com/open?id=1J9kRxC_8dW2--6Jn_FxaQ1pa8KgSE-eYHj4CkwIfoe4", 5 },
                    { 37, "Development work", 380, "", 5 },
                    { 36, "CiC with Manager", 15, "", 5 },
                    { 35, "Check the results of your submissions. Identify the hardest problem.", 30, "", 5 },
                    { 34, "Read \"Follow your calendar\"", 5, "https://drive.google.com/open?id=1u90OxXmLrfSsphaTJ81Gu-o5JU4aj5tqw36K_K6YoV4", 5 },
                    { 33, "Identify possible improvements, create plan how do you want to achieve your target", 44, "", 4 },
                    { 32, "Technical coaching session", 30, "", 4 },
                    { 60, "Check the results of your submissions. Identify the hardest problem.", 30, "", 9 },
                    { 121, "Graduation panel", 20, "", 21 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCalendarItemActions_UserCalendarItemId",
                table: "UserCalendarItemActions",
                column: "UserCalendarItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCalendarItemStatus_UserId",
                table: "UserCalendarItemStatus",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCalendarItemActions");

            migrationBuilder.DropTable(
                name: "UserCalendarItemStatus");

            migrationBuilder.DropTable(
                name: "UserCalendarItems");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
