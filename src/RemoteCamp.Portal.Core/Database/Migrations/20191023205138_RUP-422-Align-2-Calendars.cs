using Microsoft.EntityFrameworkCore.Migrations;

namespace RemoteCamp.Portal.Core.Database.Migrations
{
    public partial class RUP422Align2Calendars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CalendarType",
                table: "UserCalendarItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "UserCalendarItems",
                columns: new[] { "Id", "CalendarType", "Day", "Description", "Header", "WeekNumber" },
                values: new object[,]
                {
                    { 22, 1, "Friday", @"You are technically and mentally prepared to the adventure. 
                                                All is set up. Check if everything works fine and please don't start the tracker until Monday morning.", "Preparation for RemoteU", 0 },
                    { 40, 1, "Wednesday", "You completed 75% of your weekly target.You filled the \"Results\" section of your deck(prev.3 weeks).", "Challenge the top performer", 4 },
                    { 39, 1, "Tuesday", @"You discussed your hardest problem with your manager.
                                                You completed 50% of your weekly target.
                                                You compared your results with the previous week and documented the changes.", "Challenge the top performer", 4 },
                    { 38, 1, "Monday", @"You know your plan for this week.
                                                You started to work on your assignments and completed 25% of the weekly target.
                                                You planned your improvements(by 25%) and documented it.
                                                You refined your idea to double the productivity.", "Challenge the top performer", 4 },
                    { 37, 1, "Friday", @"You checked all failures and caught up with all the tasks undone for this week.
                                                You refined your idea to double the productivity based on the results of the previous week.
                                                Your WSPro deck is ready except the final results page.You provided the NPS to the RC management.", "Meet the team average and learn how to scale your productivity", 3 },
                    { 36, 1, "Thursday", @"You completed 95% of your weekly target.
                                                You reviewed WSPro section,Provide feedback,Negative feedback sections with your manager and addressed his feedback", "Meet the team average and learn how to scale your productivity", 3 },
                    { 35, 1, "Wednesday", "You completed 70% of your weekly target.You completed the \"Provide feedback\" section in your deck", "Meet the team average and learn how to scale your productivity", 3 },
                    { 34, 1, "Tuesday", @"You discussed your hardest problem with your manager.You completed 45% of your weekly target.
                                                You compared your results with the previous week and documented the changes.
                                                You have 2 feedbacks to RC in your deck", "Meet the team average and learn how to scale your productivity", 3 },
                    { 33, 1, "Monday", @"You know your plan for this week.You started to work on your assignments and completed 20% of the weekly target.
                                                You planned your improvements(by 25%) and documented it.
                                                You refined your idea to double the productivity.
                                                You added 1 feedback about the RC to your deck", "Meet the team average and learn how to scale your productivity", 3 },
                    { 41, 1, "Thursday", @"You completed 100% of your weekly target.
                                                You addressed all the feedbacks and your WSPro deck is ready", "Challenge the top performer", 4 },
                    { 32, 1, "Friday", @"You checked all failures and caught up with all the tasks undone for this week.
                                                You created the draft of your idea to double the productivity.
                                                You provided the NPS to the RC management.", "Be a quality expert", 2 },
                    { 30, 1, "Wednesday", @"You completed 70% of your weekly target.
                                                You completed the WSPro section in your deck.
                                                You completed Negative feedback section of your deck", "Be a quality expert", 2 },
                    { 29, 1, "Tuesday", @"You discussed your hardest problem with your manager.
                                                You completed 45% of your weekly target.You compared your results with the previous week and documented the changes.
                                                You have 4 WSPro insights,1 negative feedback and 2 TMSs in your deck", "Be a quality expert", 2 },
                    { 28, 1, "Monday", @"You know your plan for this week.
                                                You started to work on your assignments and completed 20% of the weekly target.
                                                You planned your improvements(by 25%) and documented it.
                                                You found the tools to improve your productivity.You have 3 WSPro insights in your deck", "Be a quality expert", 2 },
                    { 27, 1, "Friday", "This week is reserved for IC RemoteU", "IC RemoteU", 1 },
                    { 26, 1, "Thursday", "This week is reserved for IC RemoteU", "IC RemoteU", 1 },
                    { 25, 1, "Wednesday", "This week is reserved for IC RemoteU", "IC RemoteU", 1 },
                    { 24, 1, "Tuesday", "This week is reserved for IC RemoteU", "IC RemoteU", 1 },
                    { 23, 1, "Monday", "This week is reserved for IC RemoteU", "IC RemoteU", 1 },
                    { 31, 1, "Thursday", @"You completed 95% of your weekly target.
                                                You reviewed WSPro section with your manager and addressed his feedback", "Be a quality expert", 2 },
                    { 42, 1, "Friday", @"You checked all failures and caught up with all the tasks undone for this week.
                                                You have graduated from the RemoteCamp.
                                                You enjoy your party on this occasion.", "Challenge the top performer", 4 }
                });

            migrationBuilder.InsertData(
                table: "UserCalendarItemActions",
                columns: new[] { "Id", "AdditionalUrl", "Description", "Duration", "IsDeleted", "Url", "UserCalendarItemId" },
                values: new object[,]
                {
                    { 245, null, "Get and read the Welcome email from RemoteU management and do the prerequisites in One-Pager", 10, false, "", 22 },
                    { 317, null, "Technical coaching session", 30, false, "", 35 },
                    { 316, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 35 },
                    { 315, null, "Add 1 feedback about the RC to WSPro deck", 30, false, "", 34 },
                    { 314, null, "Finish WSPro page in deck", 25, false, "", 34 },
                    { 313, null, "Compare TMS for this week and the previous, document the changes", 30, false, "", 34 },
                    { 312, null, "Record a TMS video while producing a unit", 0, false, "", 34 },
                    { 311, null, "Development work", 365, false, "", 34 },
                    { 310, null, "CiC with Manager, discuss your innovation idea", 10, false, "", 34 },
                    { 309, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 34 },
                    { 308, null, "Add 1 feedback about the RC to the WSPro deck", 20, false, "", 33 },
                    { 307, null, "Development work", 300, false, "", 33 },
                    { 306, null, "Analyse your last week performance. Plan this week improvements, document this plan. Search the tools to improve your productivity.", 30, false, "", 33 },
                    { 305, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 33 },
                    { 304, null, "Make a weekly plan of deliveries. Recommended distribution of load is: 20/25/25/25/5+fix+catchup", 30, false, "https://remoteu.trilogy.com/plan", 33 },
                    { 303, null, "Read \"Seek Continuous Improvement and Experiment\"", 10, false, "https://drive.google.com/open?id=1-4Zoh9MeXadFMxmF9sgsaP-4jK0VWCFBrr7urCaenDA", 33 },
                    { 302, null, "Read \"Make Automation Suggestions to Team Lead\"", 5, false, "https://drive.google.com/open?id=1WKGk2q2dfhP5_nB-HuQxzp04SIN4VL3gf2WlK7c5B9Q", 33 },
                    { 301, null, "Watch \"How to Make a Plan\"", 38, false, "https://drive.google.com/open?id=1YMslqRjd3tedFUXgUjHKZqjegXpF9Swn", 33 },
                    { 300, null, "Read \"Find Tools to Improve Your Productivity\"", 7, false, "https://drive.google.com/open?id=19dMKiWi6HUtC7eFK8hk0YUG6456wwn2VHlsrej8HW_Q", 33 },
                    { 299, null, "Read \"Enforcing Input Quality Bar\"", 10, false, "https://crossover.atlassian.net/browse/TFR-318", 33 },
                    { 298, null, "Fill the NPS RemoteCamp form to summarize your experience of the week", 10, false, "", 32 },
                    { 297, null, "Check your WSPro statistics. Check your results. Find 1 insight and put it to WSPro deck", 40, false, "https://app.crossover.com/x/dashboard/contractor/my-dashboard", 32 },
                    { 318, null, "Finish RC feedback section in your deck", 40, false, "", 35 },
                    { 319, null, "Development work", 380, false, "", 35 },
                    { 320, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 36 },
                    { 321, null, "CiC with Manager", 10, false, "", 36 },
                    { 343, null, "Development work", 395, false, "", 42 },
                    { 342, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 42 },
                    { 341, null, "Address manager's feedback in your deck", 30, false, "", 41 },
                    { 340, null, "Development work", 410, false, "", 41 },
                    { 339, null, "CiC with Manager, final review deck, ask for the feedback", 10, false, "", 41 },
                    { 338, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 41 },
                    { 337, null, "Development work", 450, false, "", 40 },
                    { 336, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 40 },
                    { 335, null, "Compare TMS for this week and the previous, document the changes", 30, false, "", 39 },
                    { 334, null, "Record a TMS video while producing a unit", 0, false, "", 39 },
                    { 296, null, "Prepare your automation idea to double your productivity. Send to your manager for approval", 90, false, "", 32 },
                    { 333, null, "Development work", 420, false, "", 39 },
                    { 331, null, "Development work", 390, false, "", 38 },
                    { 330, null, "Analyse your last week performance. Plan this week improvements, document this plan. Search the tools to improve your productivity.", 30, false, "", 38 },
                    { 329, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 38 },
                    { 328, null, "Make a weekly plan of deliveries. Recommended distribution of load is: 25/25/25/25/fix+catchup", 30, false, "https://remoteu.trilogy.com/plan", 38 },
                    { 327, null, "Fill the NPS RemoteCamp form to summarize your experience of the week", 10, false, "", 37 },
                    { 326, null, "Check the results of your automation idea, refine it.", 90, false, "", 37 },
                    { 325, null, "Development work", 350, false, "", 37 },
                    { 324, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 37 },
                    { 323, null, "Address manager's feedback in your deck", 30, false, "", 36 },
                    { 322, null, "Development work", 410, false, "", 36 },
                    { 332, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 39 },
                    { 344, null, "Fill the \"My progress\" and highlights sections in the deck", 40, false, "", 42 },
                    { 295, null, "Technical coaching session", 15, false, "", 32 },
                    { 293, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 32 },
                    { 266, null, "Read \"How to deliver 100% quality?\"", 9, false, "https://drive.google.com/open?id=1goA6vWrBJmmtJnmv-UOg5uXwcO6iHw9S1eKBNfRYFqM", 28 },
                    { 265, null, "Read \"Improving quality and productivity\"", 8, false, "https://drive.google.com/open?id=12M7I2E4T47bk0jKprtdlsd8gt9iN4NVP7P4KLq-uv38", 28 },
                    { 264, null, "\"Be an expert / Tackle the hardest problem\"", 10, false, "https://drive.google.com/open?id=1IN3V4uEnjL2J5AnwdDmIABwCr3d6fzEJE_tDG7qXdqM", 28 },
                    { 263, null, @"Get the list of assignments (jira) and do a preliminary analysis. 
                                                        Form your Input Quality Bar and use QnA sheet to ask questions for the assignments which are not clear.", 30, false, "https://docs.google.com/spreadsheets/d/1-zKfuHjZKe-696mcumjdiCNR9jDJTeLtNZL-9eGgy3w/edit#gid=784927824", 28 },
                    { 262, null, "This week is reserved for IC RemoteU", 480, false, "", 27 },
                    { 261, null, "This week is reserved for IC RemoteU", 480, false, "", 26 },
                    { 260, null, "This week is reserved for IC RemoteU", 480, false, "", 25 },
                    { 259, null, "This week is reserved for IC RemoteU", 480, false, "", 24 },
                    { 258, null, "This week is reserved for IC RemoteU", 480, false, "", 23 },
                    { 257, null, "\"Be an expert / Computer\"", 2, false, "https://docs.google.com/document/d/1-_KSD-EB28bay9qQYpz_Go1h7LJ23fi9eY7qGN2rYs0/edit?usp=sharing", 22 },
                    { 256, null, "\"Be an expert / Microphone quality and call etiquette\"", 2, false, "https://docs.google.com/document/d/1KOFh2cG8V8OeVZOX8PmICN0ocdRumU6ZDma9_LZampI/edit?usp=sharing", 22 },
                    { 255, null, "\"Be an expert / Background noise\"", 2, false, "https://docs.google.com/document/d/12HkOnCRiW3VD8Vw7z4mV3fQPZJ9pMA-TNK8Eu181txs/edit?usp=sharing", 22 },
                    { 254, null, "\"Be an expert / Personal appearance\"", 3, false, "https://docs.google.com/document/d/1IHdwqRndBQR4lHC2CYdcUD_BZUh2jskIvHiMtrDRDVQ/edit?usp=sharing", 22 },
                    { 253, null, "\"Be an expert / Physical background\"", 3, false, "https://docs.google.com/document/d/1Nw4HU18zvY0f4F6MuYpbXUnMYBp7u4nT_j9JZe-8UxY/edit?usp=sharing", 22 },
                    { 252, null, "\"Be an expert / Internet Strength\"", 2, false, "https://docs.google.com/document/d/173RAU6zyRF0msWmBRUuNl6aCD8uai0yTi3FDo3YJZW4/edit?usp=sharing", 22 },
                    { 251, null, "Watch \"Anti-cheating policy\"", 28, false, "https://drive.google.com/open?id=1ToaleLywRtkhudjxBH9nCZAvdY1G27SH", 22 },
                    { 250, null, "Read \"How you can fail in RemoteU\"", 9, false, "https://drive.google.com/open?id=1TE952cAjQo_MTVxBNKB4F4GsrwmFNMEI3JXXilS_M0Y", 22 },
                    { 249, null, "Read \"The Factory Model for Elite ICs\"", 6, false, "https://drive.google.com/open?id=1LrrjfOJTXYckH70G5ohcSndp56cu9ALy6BvS7n_j40I", 22 },
                    { 248, null, "Read \"ESW Capital Factory Fundamentals\"", 3, false, "https://docs.google.com/document/d/18BmZPmGPRCdbsqqEzvha7JVd61x_Dt-P-1WLZeipdB4/edit?usp=sharing", 22 },
                    { 247, null, "Watch kickoff call and raise questions to remotecamp-sem@trilogy.com", 30, false, "https://crossover.zoom.us/recording/play/kn9N20u326Ny-sdu4pVBkea0m2zIHtcwHDp_DQ9hYqXgi1Nmy33W9dLj1zrXgz1U?continueMode=true", 22 },
                    { 246, null, "Login RemoteU Portal with your company email and check if all accesses are green. Report failing accesses to remotecamp-sem@trilogy.com", 5, false, "https://remoteu.trilogy.com", 22 },
                    { 267, null, "Read \"Root Cause Analysis\"", 12, false, "https://drive.google.com/open?id=13iWjYSNF_00RNsevjWMyzX3DNQofLbsxpJF0vAXGiFE", 28 },
                    { 268, null, "Read \"Put yourself in customer shoes\"", 5, false, "https://drive.google.com/open?id=1J9kRxC_8dW2--6Jn_FxaQ1pa8KgSE-eYHj4CkwIfoe4", 28 },
                    { 269, null, @"Make a weekly plan of deliveries. 
                                                        Recommended distribution of load is: 20/25/25/25/5+fix+catchup.", 20, false, "https://remoteu.trilogy.com/plan", 28 },
                    { 270, null, @"Prepare for CiC: Check the results of your submissions. 
                                                        Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 28 },
                    { 292, null, "Address manager's feedback in your deck", 10, false, "", 31 },
                    { 291, null, "Check your WSPro statistics. Check your results. Find 1 insight and put it to WSPro deck", 40, false, "https://app.crossover.com/x/dashboard/contractor/my-dashboard", 31 },
                    { 290, null, "Add 1 negative feedback to your deck", 10, false, "", 31 },
                    { 289, null, "Technical coaching session", 15, false, "", 31 },
                    { 288, null, "Development work", 385, false, "", 31 },
                    { 287, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 20, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 31 },
                    { 286, null, "Check your WSPro statistics. Check your results. Find 1 insight and put it to WSPro deck", 40, false, "https://app.crossover.com/x/dashboard/contractor/my-dashboard", 30 },
                    { 285, null, "Technical coaching session", 15, false, "", 30 },
                    { 284, null, "Development work", 395, false, "", 30 },
                    { 283, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 30 },
                    { 294, null, "Development work", 295, false, "", 32 },
                    { 282, null, "Add 1 Negative feedback to WSPro deck", 9, false, "", 29 },
                    { 280, null, "Technical coaching session", 15, false, "", 29 },
                    { 279, null, "Compare TMS for this week and the previous, document the changes", 16, false, "", 29 },
                    { 278, null, "Record a TMS video while producing a unit", 0, false, "", 29 },
                    { 277, null, "Development work", 400, false, "", 29 },
                    { 276, null, "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.", 30, false, "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)", 29 },
                    { 275, null, "Give Improvement Feedback", 6, false, "https://drive.google.com/open?id=1Mt1HyCnSsU69yBmndtY0pYxtN787OD-gkjJpA3XLjeE", 28 },
                    { 274, null, "Add 1 WSPro insight to WSPro deck", 25, false, "", 28 },
                    { 273, null, @"Ask technical questions to mentors, setup projects, watch and read technical documentation applicable to your track. 
                                                        Align with your mentor on Internal Quality Bars, have no different opinion. 
                                                        Create a physical sheet of quality bars and assignment matrix.", 240, false, "https://docs.google.com/spreadsheets/d/1KjbpWYvB6dGFcowWlN2gAtNSsKsUDbgyixE-GSgdQBc/edit#gid=0", 28 },
                    { 272, null, "Development work.", 55, false, "", 28 },
                    { 271, null, @"Analyse your last week performance. Plan this week improvements, document this plan. 
                                                        Search the tools to improve your productivity.", 30, false, "", 28 },
                    { 281, null, "Add 1 WSPro insight to WSPro deck", 10, false, "", 29 },
                    { 345, null, "Graduation Panel", 15, false, "", 42 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 342);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 343);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 344);

            migrationBuilder.DeleteData(
                table: "UserCalendarItemActions",
                keyColumn: "Id",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "UserCalendarItems",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DropColumn(
                name: "CalendarType",
                table: "UserCalendarItems");
        }
    }
}
