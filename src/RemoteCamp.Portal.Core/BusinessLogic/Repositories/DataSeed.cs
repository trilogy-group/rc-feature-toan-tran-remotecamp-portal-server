using System;
using System.Collections.Generic;
using System.Linq;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.Database.Model;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    public class DataSeed : IDataSeed
    {
        public User[] GetUsers()
        {
            var user = new User
            {
                Id = 1,
                CreatedAt = DateTime.UtcNow,
                Email = "gaurav.thakur@aurea.com"
            };

            var listUser = new List<User>();
            listUser.Add(user);
            return listUser.ToArray();
        }

        public UserCalendarItem[] GetUserCalendarItems()
        {
            return new UserCalendarItem[] {
                UserCalendarItemForWeek0FridayNew(),
                UserCalendarItemForWeek1MondayNew(),
                UserCalendarItemForWeek1TuesdayNew(),
                UserCalendarItemForWeek1WednesdayNew(),
                UserCalendarItemForWeek1ThursdayNew(),
                UserCalendarItemForWeek1FridayNew(),
                UserCalendarItemForWeek2MondayNew(),
                UserCalendarItemForWeek2TuesdayNew(),
                UserCalendarItemForWeek2WednesdayNew(),
                UserCalendarItemForWeek2ThursdayNew(),
                UserCalendarItemForWeek2FridayNew(),
                UserCalendarItemForWeek3MondayNew(),
                UserCalendarItemForWeek3TuesdayNew(),
                UserCalendarItemForWeek3WednesdayNew(),
                UserCalendarItemForWeek3ThursdayNew(),
                UserCalendarItemForWeek3FridayNew(),
                UserCalendarItemForWeek4MondayNew(),
                UserCalendarItemForWeek4TuesdayNew(),
                UserCalendarItemForWeek4WednesdayNew(),
                UserCalendarItemForWeek4ThursdayNew(),
                UserCalendarItemForWeek4FridayNew(),

                UserCalendarItemForWeek0FridayIcRemoteU(),
                UserCalendarItemForWeek1MondayIcRemoteU(),
                UserCalendarItemForWeek1TuesdayIcRemoteU(),
                UserCalendarItemForWeek1WednesdayIcRemoteU(),
                UserCalendarItemForWeek1ThursdayIcRemoteU(),
                UserCalendarItemForWeek1FridayIcRemoteU(),
                UserCalendarItemForWeek2MondayIcRemoteU(),
                UserCalendarItemForWeek2TuesdayIcRemoteU(),
                UserCalendarItemForWeek2WednesdayIcRemoteU(),
                UserCalendarItemForWeek2ThursdayIcRemoteU(),
                UserCalendarItemForWeek2FridayIcRemoteU(),
                UserCalendarItemForWeek3MondayIcRemoteU(),
                UserCalendarItemForWeek3TuesdayIcRemoteU(),
                UserCalendarItemForWeek3WednesdayIcRemoteU(),
                UserCalendarItemForWeek3ThursdayIcRemoteU(),
                UserCalendarItemForWeek3FridayIcRemoteU(),
                UserCalendarItemForWeek4MondayIcRemoteU(),
                UserCalendarItemForWeek4TuesdayIcRemoteU(),
                UserCalendarItemForWeek4WednesdayIcRemoteU(),
                UserCalendarItemForWeek4ThursdayIcRemoteU(),
                UserCalendarItemForWeek4FridayIcRemoteU(),
            };
        }

        public UserCheckInChatItem[] GetUserCheckInChatItem()
        {
            var listUserCheckInChatItem = new List<UserCheckInChatItem>
            {
                new UserCheckInChatItem
                {
                    Id = 1,
                    Day = "Mon",
                    WeekNumber = 1
                },
                new UserCheckInChatItem
                {
                    Id = 2,
                    Day = "Tue",
                    WeekNumber = 1
                },
                new UserCheckInChatItem
                {
                    Id = 3,
                    Day = "Wed",
                    WeekNumber = 1
                },
                new UserCheckInChatItem
                {
                    Id = 4,
                    Day = "Thurs",
                    WeekNumber = 1
                },
                new UserCheckInChatItem
                {
                    Id = 5,
                    Day = "Fri",
                    WeekNumber = 1
                },
                new UserCheckInChatItem
                {
                    Id = 6,
                    Day = "Mon",
                    WeekNumber = 2
                },
                new UserCheckInChatItem
                {
                    Id = 7,
                    Day = "Tue",
                    WeekNumber = 2
                },
                new UserCheckInChatItem
                {
                    Id = 8,
                    Day = "Wed",
                    WeekNumber = 2
                },
                new UserCheckInChatItem
                {
                    Id = 9,
                    Day = "Thurs",
                    WeekNumber = 2
                },
                new UserCheckInChatItem
                {
                    Id = 10,
                    Day = "Fri",
                    WeekNumber = 2
                },
                new UserCheckInChatItem
                {
                    Id = 11,
                    Day = "Mon",
                    WeekNumber = 3
                },
                new UserCheckInChatItem
                {
                    Id = 12,
                    Day = "Tue",
                    WeekNumber = 3
                },
                new UserCheckInChatItem
                {
                    Id = 13,
                    Day = "Wed",
                    WeekNumber = 3
                },
                new UserCheckInChatItem
                {
                    Id = 14,
                    Day = "Thurs",
                    WeekNumber = 3
                },
                new UserCheckInChatItem
                {
                    Id = 15,
                    Day = "Fri",
                    WeekNumber = 3
                },
                new UserCheckInChatItem
                {
                    Id = 16,
                    Day = "Mon",
                    WeekNumber = 4
                },
                new UserCheckInChatItem
                {
                    Id = 17,
                    Day = "Tue",
                    WeekNumber = 4
                },
                new UserCheckInChatItem
                {
                    Id = 18,
                    Day = "Wed",
                    WeekNumber = 4
                },
                new UserCheckInChatItem
                {
                    Id = 19,
                    Day = "Thurs",
                    WeekNumber = 4
                },
                new UserCheckInChatItem
                {
                    Id = 20,
                    Day = "Fri",
                    WeekNumber = 4
                }
            };

            return listUserCheckInChatItem.ToArray();
        }

        private static List<UserCalendarItem> CreateUserCalendarItems()
        {
            var userCalendarItem = new List<UserCalendarItem>
            {
                UserCalendarItemForWeek0Friday(),
                UserCalendarItemForWeek1Monday(),
                UserCalendarItemForWeek1Tuesday(),
                UserCalendarItemForWeek1WedNesday(),
                UserCalendarItemForWeek1Thursday(),
                UserCalendarItemForWeek1Friday(),
                UserCalendarItemForWeek2Monday(),
                UserCalendarItemForWeek2Tuesday(),
                UserCalendarItemForWeek2WedNesday(),
                UserCalendarItemForWeek2Thursday(),
                UserCalendarItemForWeek2Friday(),
                UserCalendarItemForWeek3Monday(),
                UserCalendarItemForWeek3Tuesday(),
                UserCalendarItemForWeek3WedNesday(),
                UserCalendarItemForWeek3Thursday(),
                UserCalendarItemForWeek3Friday(),
                UserCalendarItemForWeek4Monday(),
                UserCalendarItemForWeek4Tuesday(),
                UserCalendarItemForWeek4WedNesday(),
                UserCalendarItemForWeek4Thursday(),
                UserCalendarItemForWeek4Friday(),

                UserCalendarItemForWeek0FridayNew(),
                UserCalendarItemForWeek1MondayNew(),
                UserCalendarItemForWeek1TuesdayNew(),
                UserCalendarItemForWeek1WednesdayNew(),
                UserCalendarItemForWeek1ThursdayNew(),
                UserCalendarItemForWeek1FridayNew(),
                UserCalendarItemForWeek2MondayNew(),
                UserCalendarItemForWeek2TuesdayNew(),
                UserCalendarItemForWeek2WednesdayNew(),
                UserCalendarItemForWeek2ThursdayNew(),
                UserCalendarItemForWeek2FridayNew(),
                UserCalendarItemForWeek3MondayNew(),
                UserCalendarItemForWeek3TuesdayNew(),
                UserCalendarItemForWeek3WednesdayNew(),
                UserCalendarItemForWeek3ThursdayNew(),
                UserCalendarItemForWeek3FridayNew(),
                UserCalendarItemForWeek4MondayNew(),
                UserCalendarItemForWeek4TuesdayNew(),
                UserCalendarItemForWeek4WednesdayNew(),
                UserCalendarItemForWeek4ThursdayNew(),
                UserCalendarItemForWeek4FridayNew(),

                UserCalendarItemForWeek0FridayIcRemoteU(),
                UserCalendarItemForWeek1MondayIcRemoteU(),
                UserCalendarItemForWeek1TuesdayIcRemoteU(),
                UserCalendarItemForWeek1WednesdayIcRemoteU(),
                UserCalendarItemForWeek1ThursdayIcRemoteU(),
                UserCalendarItemForWeek1FridayIcRemoteU(),
                UserCalendarItemForWeek2MondayIcRemoteU(),
                UserCalendarItemForWeek2TuesdayIcRemoteU(),
                UserCalendarItemForWeek2WednesdayIcRemoteU(),
                UserCalendarItemForWeek2ThursdayIcRemoteU(),
                UserCalendarItemForWeek2FridayIcRemoteU(),
                UserCalendarItemForWeek3MondayIcRemoteU(),
                UserCalendarItemForWeek3TuesdayIcRemoteU(),
                UserCalendarItemForWeek3WednesdayIcRemoteU(),
                UserCalendarItemForWeek3ThursdayIcRemoteU(),
                UserCalendarItemForWeek3FridayIcRemoteU(),
                UserCalendarItemForWeek4MondayIcRemoteU(),
                UserCalendarItemForWeek4TuesdayIcRemoteU(),
                UserCalendarItemForWeek4WednesdayIcRemoteU(),
                UserCalendarItemForWeek4ThursdayIcRemoteU(),
                UserCalendarItemForWeek4FridayIcRemoteU(),
            };

            return userCalendarItem;
        }

        public UserCalendarItemAction[] GetUserCalendarItemActions()
        {
            var lstUserCalendarItemActions = new List<UserCalendarItemAction>();
            var listUserCalendarItems = CreateUserCalendarItems();
            if (listUserCalendarItems.Any())
            {
                listUserCalendarItems.ForEach(x =>
                {
                    x.UserCalendarItemActions.ToList().ForEach(j =>
                    {
                        lstUserCalendarItemActions.Add(new UserCalendarItemAction
                        {
                            Id = j.Id,
                            Description = j.Description,
                            Duration = j.Duration,
                            Url = j.Url,
                            UserCalendarItemId = x.Id,
                            IsDeleted = j.IsDeleted,
                            AdditionalUrl = j.AdditionalUrl,
                            Position = j.Position
                        });
                    });
                });
            }

            return lstUserCalendarItemActions.ToArray();
        }

        private static UserCalendarItem UserCalendarItemForWeek0Friday()
        {
            return new UserCalendarItem
            {
                Id = 1,
                Day = DayOfWeek.Friday.ToString(),
                Description = "You are technically and mentally prepared to the adventure. All is set up. Your assignments will be available on Monday.",
                WeekNumber = 0,
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 1,
                        Description = "Get and read the welcome email from RemoteCamp management",
                        Url = string.Empty,
                        Duration = 10,
                        UserCalendarItemId = 1,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 2,
                        Description = "Check all the accesses (todo: add which exactly)",
                        Url = string.Empty,
                        Duration = 60,
                        UserCalendarItemId = 1,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 3,
                        Description = "Report non-working accesses to the RemoteCamp SEM",
                        Url = string.Empty,
                        Duration = 20,
                        UserCalendarItemId = 1,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 4,
                        Description = "Kick-off call",
                        Url = string.Empty,
                        Duration = 60,
                        UserCalendarItemId = 1,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 5,
                        Description = "Read \"Quality and common terms we use\"",
                        Url = "https://drive.google.com/open?id=13x4k7OlM-qoZIfwnr3FqeQKpMBmOJ5VD0IEsGiSMOvM",
                        Duration = 7,
                        UserCalendarItemId = 1,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 6,
                        Description = "Read \"How will you pass the RemoteCamp\"",
                        Url = "https://drive.google.com/open?id=1TE952cAjQo_MTVxBNKB4F4GsrwmFNMEI3JXXilS_M0Y",
                        Duration = 6,
                        UserCalendarItemId = 1,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 7,
                        Description = "Watch \"Quality-30/01/2019.mp4\"",
                        Url = "https://drive.google.com/drive/u/0/folders/1eiGuCV72FUWezStfqNq_KCXXgIuratjm",
                        Duration = 27,
                        UserCalendarItemId = 1,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 8,
                        Description = "Read \"Worksmart tool certified\"",
                        Url = "https://drive.google.com/open?id=1yjIVcSKnAtgIgZ52W2jPDb9OC8K6RvOb5V2n1KOmCBs",
                        Duration = 5,
                        UserCalendarItemId = 1,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 9,
                        Description = "Read \"Intensity and focus blocks\"",
                        Url = "https://drive.google.com/open?id=1dJPwpR5BREoMZa8CV2sVkwUYuaAZDg0AokvkvHhIH-Q",
                        Duration = 8,
                        UserCalendarItemId = 1,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 10,
                        Description = "Read \"CiC Framework\"",
                        Url = "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit",
                        Duration = 15,
                        UserCalendarItemId = 1,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 11,
                        Description = "Watch \"Anti-cheating policy\"",
                        Url = "https://drive.google.com/open?id=1ToaleLywRtkhudjxBH9nCZAvdY1G27SH",
                        Duration = 28,
                        UserCalendarItemId = 1,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 12,
                        Description = "Watch \"Tackling the Hardest Problem\"",
                        Url = "https://drive.google.com/open?id=1WbcAloWNZjJrWsYrFItyFUAmehm64ZFd",
                        Duration = 24,
                        UserCalendarItemId = 1,
                        IsDeleted = true
                    },
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek0FridayNew()
        {
            return new UserCalendarItem
            {
                Id = 1,
                Day = DayOfWeek.Friday.ToString(),
                Description = @"You are technically and mentally prepared to the adventure. All is set up. 
Check if everything works fine and please don't start the tracker until Monday morning.",
                WeekNumber = 0,
                Header = "Preparation for RemoteU",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 236,
                        Description = "Get and read the Welcome email from RemoteU management and do the prerequisites in One-Pager",
                        Url = string.Empty,
                        Duration = 10,
                        UserCalendarItemId = 1,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 237,
                        Description = "Login RemoteU Portal with your company email and check if all accesses are green. Report failing accesses to remotecamp-sem@trilogy.com",
                        Url = "https://remoteu.trilogy.com",
                        Duration = 5,
                        UserCalendarItemId = 1,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 238,
                        Description = "Watch kickoff call and raise questions to remotecamp-sem@trilogy.com",
                        Url = "https://crossover.zoom.us/recording/play/kn9N20u326Ny-sdu4pVBkea0m2zIHtcwHDp_DQ9hYqXgi1Nmy33W9dLj1zrXgz1U?continueMode=true",
                        Duration = 30,
                        UserCalendarItemId = 1,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=239,
                        Description = "Read \"The Factory Model for Elite ICs\"",
                        Url = "https://drive.google.com/open?id=1LrrjfOJTXYckH70G5ohcSndp56cu9ALy6BvS7n_j40I",
                        Duration = 6,
                        UserCalendarItemId = 1,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id= 346,
                        Description = "Read \"ESW Capital Factory Fundamentals\"",
                        Url = "https://docs.google.com/document/d/18BmZPmGPRCdbsqqEzvha7JVd61x_Dt-P-1WLZeipdB4/edit?usp=sharing",
                        Duration = 3,
                        UserCalendarItemId = 1,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 347,
                        Description = "Read \"The Factory Model for Elite ICs\"",
                        Url = "https://drive.google.com/open?id=1LrrjfOJTXYckH70G5ohcSndp56cu9ALy6BvS7n_j40I",
                        Duration = 6,
                        UserCalendarItemId = 1,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 240,
                        Description = "Read \"How you can fail in RemoteU\"",
                        Url = "https://drive.google.com/open?id=1TE952cAjQo_MTVxBNKB4F4GsrwmFNMEI3JXXilS_M0Y",
                        AdditionalUrl = string.Empty,
                        Duration = 9,
                        UserCalendarItemId = 1,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 241,
                        Description = "Watch \"Anti-cheating policy\"",
                        Url = "https://drive.google.com/open?id=1ToaleLywRtkhudjxBH9nCZAvdY1G27SH",
                        Duration = 28,
                        UserCalendarItemId = 1,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 348,
                        Description = "Read \"Be an Expert (Internet Strength)\"",
                        Url = "https://docs.google.com/document/d/173RAU6zyRF0msWmBRUuNl6aCD8uai0yTi3FDo3YJZW4/edit?usp=sharing",
                        Duration = 2,
                        UserCalendarItemId = 1,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 349,
                        Description = "Read \"Be an Expert (Physical background)\"",
                        Url = "https://docs.google.com/document/d/1Nw4HU18zvY0f4F6MuYpbXUnMYBp7u4nT_j9JZe-8UxY/edit?usp=sharing",
                        Duration = 3,
                        UserCalendarItemId = 1,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 350,
                        Description = "Read \"Be an Expert (Personal appearance)\"",
                        Url = "https://docs.google.com/document/d/1IHdwqRndBQR4lHC2CYdcUD_BZUh2jskIvHiMtrDRDVQ/edit?usp=sharing",
                        Duration = 3,
                        UserCalendarItemId = 1,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 351,
                        Description = "Read \"Be an Expert (Background noise)\"",
                        Url = "https://docs.google.com/document/d/12HkOnCRiW3VD8Vw7z4mV3fQPZJ9pMA-TNK8Eu181txs/edit?usp=sharing",
                        Duration = 2,
                        UserCalendarItemId = 1,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 352,
                        Description = "Read \"Be an Expert (Microphone quality and call etiquette)\"",
                        Url = "https://docs.google.com/document/d/1KOFh2cG8V8OeVZOX8PmICN0ocdRumU6ZDma9_LZampI/edit?usp=sharing",
                        Duration = 2,
                        UserCalendarItemId = 1,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 353,
                        Description = "Read \"Be an Expert (Computer)\"",
                        Url = "https://docs.google.com/document/d/1-_KSD-EB28bay9qQYpz_Go1h7LJ23fi9eY7qGN2rYs0/edit?usp=sharing",
                        Duration = 2,
                        UserCalendarItemId = 1,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=242,
                        Description = "Read or watch \"Quality and common terms we use\"",
                        Url = "https://drive.google.com/open?id=13x4k7OlM-qoZIfwnr3FqeQKpMBmOJ5VD0IEsGiSMOvM",
                        AdditionalUrl = "https://drive.google.com/open?id=1_Er9y8bxMfpRmqyEAfQo2Hs9vxsarCtn",
                        Duration = 15,
                        UserCalendarItemId = 1,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id=243,
                        Description = "Read or watch \"Be successful in a remote environment\"",
                        Url = "https://drive.google.com/open?id=1Z1ZaQpf4aa291O_dkbrPhaY0s0CEKr2RNOPltfRTFsc",
                        AdditionalUrl = "https://drive.google.com/open?id=1zBYHenIc87Cmh9gDDZelL-hbUEWscJd0",
                        Duration = 15,
                        UserCalendarItemId = 1,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id=244,
                        Description = "Read or watch \"Worksmart tool certified\"",
                        Url = "https://drive.google.com/open?id=1yjIVcSKnAtgIgZ52W2jPDb9OC8K6RvOb5V2n1KOmCBs",
                        AdditionalUrl = "https://drive.google.com/open?id=1yu4cGUuHiuUh-oTldBZdxZ1WQwt12HDV",
                        Duration = 15,
                        UserCalendarItemId = 1,
                        IsDeleted = true
                    }
                }
            };
        }

        #region week 1 Section

        private static UserCalendarItem UserCalendarItemForWeek1Monday()
        {
            return new UserCalendarItem
            {
                Id = 2,
                Day = DayOfWeek.Monday.ToString(),
                Description = @"You know your plan for this week.
You know how the tracker works.
You started your alignment with the Manager.
You started to work on your assignments and completed 10% of the weekly target",
                WeekNumber = 1,
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 13,
                        Description = "Get the list of assignments (jira) and go through it",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 2,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 14,
                        Description = "Make a weekly plan of deliveries. Recommended distribution of load is: 10/30/30/20/10+fix+catchup.",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 2,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 15,
                        Description = "CiC with Manager",
                        Url = string.Empty,
                        Duration = 15,
                        UserCalendarItemId = 2,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 16,
                        Description = "Ask technical questions, setup projects, understand the requirements to the job done (IQBs), watch and read technical documentation applicable to your track",
                        Url = string.Empty,
                        Duration = 240,
                        UserCalendarItemId = 2,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 17,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 160,
                        UserCalendarItemId = 2,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 18,
                        Description = "Read \"Welcome Negative feedback\"",
                        Url = "https://drive.google.com/open?id=1QNGyddEVA6mO8sbi4CZ8M-XxaybskglUP38gSqEgtmo",
                        Duration = 5,
                        UserCalendarItemId = 2,
                        IsDeleted = true
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek1Tuesday()
        {
            return new UserCalendarItem
            {
                Id = 3,
                Day = DayOfWeek.Tuesday.ToString(),
                Description = @"You know your failures.
You are identified your hardest problem and started to think how to resolve it,
and discussed it with your manager.
You completed 40% of your weekly target.",
                WeekNumber = 1,
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                   new UserCalendarItemAction
                   {
                         Id = 19,
                         Description = "Read \"Seek Continuous Improvement / Experiment\"",
                         Url = "https://drive.google.com/open?id=1-4Zoh9MeXadFMxmF9sgsaP-4jK0VWCFBrr7urCaenDA",
                         Duration = 10,
                         UserCalendarItemId = 3,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 20,
                         Description = "Check the results of your submissions. Identify the hardest problem.",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 3,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 21,
                         Description = "CiC with Manager",
                         Url = string.Empty,
                         Duration = 15,
                         UserCalendarItemId = 3,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 22,
                         Description = "Development work",
                         Url = string.Empty,
                         Duration = 350,
                         UserCalendarItemId = 3,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 23,
                         Description = "Make TMS video of 1 unit produced",
                         Url = "https://drive.google.com/file/d/0BzSXGty9sV6KRGp1aHNPa2dkWTQ/view",
                         Duration = 0,
                         UserCalendarItemId = 3,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 24,
                         Description = "\"Be an expert / Tackle the hardest problem\"",
                         Url = "https://drive.google.com/open?id=1IN3V4uEnjL2J5AnwdDmIABwCr3d6fzEJE_tDG7qXdqM",
                         Duration = 6,
                         UserCalendarItemId = 3,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 25,
                         Description = "Technical coaching session",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 3,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 26,
                         Description = "Create your copy of WSPro deck, add your TMS.",
                         Url = "https://docs.google.com/document/u/1/d/1oc5kgAfOZgvOhvwHjLjyZJmPKkxMmwtg7vt-rncW1ss/edit",
                         Duration = 39,
                         UserCalendarItemId = 3,
                         IsDeleted = true
                   },
                }
            };
        }
        private static UserCalendarItem UserCalendarItemForWeek1WedNesday()
        {
            return new UserCalendarItem
            {
                Id = 4,
                Day = DayOfWeek.Wednesday.ToString(),
                Description = @"You planned your improvements.
You completed 70% of your weekly target.
Your WSPro deck has TMS and improvement plan linked.",
                WeekNumber = 1,
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                   new UserCalendarItemAction
                   {
                         Id = 27,
                         Description = "Read \"Find Tools That Improve Your Own Productivity\"",
                         Url = "https://drive.google.com/open?id=1wKKuzWFiL6nDIrq9aNSss6EqKugZNgJku57gfdolcCM",
                         Duration = 5,
                         UserCalendarItemId = 4,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 28,
                         Description = "Check the results of your submissions. Identify the hardest problem.",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 4,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 29,
                         Description = "CiC with Manager",
                         Url = string.Empty,
                         Duration = 15,
                         UserCalendarItemId = 4,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 30,
                         Description = "Development work",
                         Url = string.Empty,
                         Duration = 350,
                         UserCalendarItemId = 4,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 31,
                         Description = "Read \"Improving quality and productivity\"",
                         Url = "https://drive.google.com/open?id=12M7I2E4T47bk0jKprtdlsd8gt9iN4NVP7P4KLq-uv38",
                         Duration = 6,
                         UserCalendarItemId = 4,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 32,
                         Description = "Technical coaching session",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 4,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 33,
                         Description = "Identify possible improvements, create plan how do you want to achieve your target",
                         Url = string.Empty,
                         Duration = 44,
                         UserCalendarItemId = 3,
                         IsDeleted = true
                   }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek1Thursday()
        {
            return new UserCalendarItem
            {
                Id = 5,
                Day = DayOfWeek.Thursday.ToString(),
                Description = @"You started to fill WSPro deck with your insights.
You completed 90% of your weekly target.",
                WeekNumber = 1,
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                   new UserCalendarItemAction
                   {
                         Id = 34,
                         Description = "Read \"Follow your calendar\"",
                         Url = "https://drive.google.com/open?id=1u90OxXmLrfSsphaTJ81Gu-o5JU4aj5tqw36K_K6YoV4",
                         Duration = 5,
                         UserCalendarItemId = 5,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 35,
                         Description = "Check the results of your submissions. Identify the hardest problem.",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 5,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 36,
                         Description = "CiC with Manager",
                         Url = string.Empty,
                         Duration = 15,
                         UserCalendarItemId = 5,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 37,
                         Description = "Development work",
                         Url = string.Empty,
                         Duration = 380,
                         UserCalendarItemId = 5,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 38,
                         Description = "Read \"Put yourself in Customer\"''\"s shoes\"",
                         Url = "https://drive.google.com/open?id=1J9kRxC_8dW2--6Jn_FxaQ1pa8KgSE-eYHj4CkwIfoe4",
                         Duration = 6,
                         UserCalendarItemId = 5,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 39,
                         Description = "Check your WSPro statistics. Check your results. Find 1 insight and put it to WSPro deck",
                         Url = string.Empty,
                         Duration = 44,
                         UserCalendarItemId = 5,
                         IsDeleted = true
                   }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek1Friday()
        {
            return new UserCalendarItem
            {
                Id = 6,
                Day = DayOfWeek.Friday.ToString(),
                Description = @"You have 2 WSPro insights in your deck.
You completed 100% of your weekly target.
You provided the NPS to the RC management.",
                WeekNumber = 1,
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                   new UserCalendarItemAction
                   {
                         Id = 40,
                         Description = "Check the results of your submissions. Identify the hardest problem.",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 6,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 41,
                         Description = "CiC with Manager",
                         Url = string.Empty,
                         Duration = 15,
                         UserCalendarItemId = 6,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 42,
                         Description = "Development work",
                         Url = string.Empty,
                         Duration = 380,
                         UserCalendarItemId = 6,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 43,
                         Description = "Read \"Give Improvement Feedback\"",
                         Url = "https://drive.google.com/open?id=1Mt1HyCnSsU69yBmndtY0pYxtN787OD-gkjJpA3XLjeE",
                         Duration = 6,
                         UserCalendarItemId = 6,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 44,
                         Description = "Check your WSPro statistics. Check your results. Find 1 insight and put it to WSPro deck",
                         Url = string.Empty,
                         Duration = 44,
                         UserCalendarItemId = 6,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 45,
                         Description = "Fill the NPS RemoteCamp form to summarize your experience of the week",
                         Url = string.Empty,
                         Duration = 7,
                         UserCalendarItemId = 6,
                         IsDeleted = true
                   }
                }
            };
        }
        #endregion

        #region week 2 Section
        private static UserCalendarItem UserCalendarItemForWeek2Monday()
        {
            return new UserCalendarItem
            {
                Id = 7,
                Day = DayOfWeek.Monday.ToString(),
                Description = @"You know your plan for this week.
You started to work on your assignments and completed 25% of the weekly target.
You planned your improvements(by 25%) and documented it.
You found the tools to improve your productivity.
You have 3 WSPro insights in your deck",
                Header = "Productivity vs. week1 increased + 25%",
                WeekNumber = 2,
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                   new UserCalendarItemAction
                   {
                         Id = 46,
                         Description = "Make a weekly plan of deliveries. Recommended distribution of load is: 25/25/25/25/fix+catchup",
                         Url = "https://drive.google.com/open?id=1YMslqRjd3tedFUXgUjHKZqjegXpF9Swn",
                         Duration = 30,
                         UserCalendarItemId = 7,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 47,
                         Description = "Read \"Make Automations Suggestions to Team Lead\"",
                         Url = "https://drive.google.com/open?id=1WKGk2q2dfhP5_nB-HuQxzp04SIN4VL3gf2WlK7c5B9Q",
                         Duration = 5,
                         UserCalendarItemId = 7,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 48,
                         Description = "Check the results of your submissions. Identify the hardest problem.",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 7,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 49,
                         Description = "Analyse your last week performance. Plan this week improvements, document this plan. Search the tools to improve your productivity.",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 7,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 50,
                         Description = "Development work",
                        Url = string.Empty,
                         Duration = 360,
                         UserCalendarItemId = 7,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 51,
                         Description = "Add 1 WSPro insight to WSPro deck",
                        Url = string.Empty,
                         Duration = 25,
                         UserCalendarItemId = 7,
                         IsDeleted = true
                   }
                }
            };
        }
        private static UserCalendarItem UserCalendarItemForWeek2Tuesday()
        {
            return new UserCalendarItem
            {
                Id = 8,
                Day = DayOfWeek.Tuesday.ToString(),
                Description = @"You discussed your hardest problem with your manager.
You completed 50% of your weekly target.
You compared your results with the previous week and documented the changes.
You have 4 WSPro insights,
1 negative feedback and 2 TMSs in your deck",
                WeekNumber = 2,
                Header = "Productivity vs. week1 increased + 25%",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                   new UserCalendarItemAction
                   {
                         Id = 52,
                         Description = "Check the results of your submissions. Identify the hardest problem.",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 8,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 53,
                         Description = "CiC with Manager, ask for the negative feedback",
                         Url = string.Empty,
                         Duration = 10,
                         UserCalendarItemId = 8,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 54,
                         Description = "Development work",
                         Url = string.Empty,
                         Duration = 350,
                         UserCalendarItemId = 8,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 55,
                         Description = "Make TMS video of 1 unit produced",
                         Url = string.Empty,
                         Duration = 0,
                         UserCalendarItemId = 8,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 56,
                         Description = "Compare TMS for this week and the previous, document the changes",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 8,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 57,
                         Description = "Technical coaching session",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 8,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 58,
                         Description = "Add 1 WSPro insight to WSPro deck",
                         Url = string.Empty,
                         Duration = 15,
                         UserCalendarItemId = 8,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id = 59,
                         Description = "Add 1 Negative feedback to WSPro deck",
                         Url = string.Empty,
                         Duration = 15,
                         UserCalendarItemId = 8,
                         IsDeleted = true
                   }
                }
            };
        }
        private static UserCalendarItem UserCalendarItemForWeek2WedNesday()
        {
            return new UserCalendarItem
            {
                Id = 9,
                Day = DayOfWeek.Wednesday.ToString(),
                Description = @"You completed 75% of your weekly target.
You completed the WSPro section in your deck
You completed Negative feedback section of your deck",
                WeekNumber = 2,
                Header = "Productivity vs. week1 increased + 25%",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                   new UserCalendarItemAction
                   {
                         Id=60,
                         Description = "Check the results of your submissions. Identify the hardest problem.",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 9,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id=61,
                         Description = "Development work",
                         Url = string.Empty,
                         Duration = 380,
                         UserCalendarItemId = 9,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=62,
                         Description = "Technical coaching session",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 9,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id=63,
                         Description = "Finish WSPro page in deck",
                         Url = string.Empty,
                         Duration = 40,
                         UserCalendarItemId = 9,
                         IsDeleted = true
                   }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek2Thursday()
        {
            return new UserCalendarItem
            {
                Id = 10,
                Day = DayOfWeek.Thursday.ToString(),
                Description = @"You completed 100% of your weekly target.
You reviewed WSPro section with your manager and addressed his feedback",
                WeekNumber = 2,
                Header = "Productivity vs. week1 increased + 25%",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                   new UserCalendarItemAction
                   {
                         Id=64,
                         Description = "Check the results of your submissions. Identify the hardest problem.",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 10,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id=65,
                         Description = "CiC with Manager, ask for negative feedback",
                         Url = string.Empty,
                         Duration = 10,
                         UserCalendarItemId = 10,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id=66,
                         Description = "Development work",
                         Url = string.Empty,
                         Duration = 380,
                         UserCalendarItemId = 10,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id=67,
                         Description = "Technical coaching session",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 10,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id=68,
                         Description = "Add 1 negative feedback to your deck",
                         Url = string.Empty,
                         Duration = 15,
                         UserCalendarItemId = 10,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id=69,
                         Description = "Address manager\"''\"s feedback in your deck",
                         Url = string.Empty,
                         Duration = 15,
                         UserCalendarItemId = 10,
                         IsDeleted = true
                   }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek2Friday()
        {
            return new UserCalendarItem
            {
                Id = 11,
                Day = DayOfWeek.Friday.ToString(),
                Description = @"You checked all failures and caught up with all the tasks undone for this week.
You created the draft of your idea to double the productivity.
You provided the NPS to the RC management.",
                WeekNumber = 2,
                Header = "Productivity vs. week1 increased + 25%",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                   new UserCalendarItemAction
                   {
                         Id=70,
                         Description = "Check the results of your submissions. Identify the hardest problem.",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 11,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id=71,
                         Description = "Development work",
                         Url = string.Empty,
                         Duration = 350,
                         UserCalendarItemId = 11,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id=72,
                         Description = "Prepare your automation idea to double your productivity. Send to your manager for approval",
                         Url = string.Empty,
                         Duration = 90,
                         UserCalendarItemId = 11,
                         IsDeleted = true
                   },
                    new UserCalendarItemAction
                   {
                         Id=73,
                         Description = "Fill the NPS RemoteCamp form to summarize your experience of the week",
                         Url = string.Empty,
                         Duration = 10,
                         UserCalendarItemId = 11,
                         IsDeleted = true
                   }
                }
            };
        }
        #endregion

        #region week 3 Section
        private static UserCalendarItem UserCalendarItemForWeek3Monday()
        {
            return new UserCalendarItem
            {
                Id = 12,
                Day = DayOfWeek.Monday.ToString(),
                Description = @"You know your plan for this week.
You started to work on your assignments and completed 25% of the weekly target.
You planned your improvements(by 25%) and documented it.
You refined your idea to double the productivity.
You added 1 feedback about the RC to your deck",
                WeekNumber = 3,
                Header = "Productivity vs. week2 increased + 25%",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                   new UserCalendarItemAction
                   {
                        Id=74,
                         Description = "Make a weekly plan of deliveries. Recommended distribution of load is: 25/25/25/25/fix+catchup",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 12,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=75,
                         Description = "Check the results of your submissions. Identify the hardest problem.",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 12,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id=76,
                         Description = "Analyse your last week performance. Plan this week improvements, document this plan. Search the tools to improve your productivity.",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 12,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=77,
                         Description = "Development work",
                         Url = string.Empty,
                         Duration = 370,
                         UserCalendarItemId = 12,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=78,
                        Description = "Add 1 feedback about the RC to the WSPro deck",
                        Url = string.Empty,
                        Duration = 20,
                        UserCalendarItemId = 12,
                        IsDeleted = true
                   }
                }
            };
        }
        private static UserCalendarItem UserCalendarItemForWeek3Tuesday()
        {
            return new UserCalendarItem
            {
                Id = 13,
                Day = DayOfWeek.Tuesday.ToString(),
                Description = @"You discussed your hardest problem with your manager.
You completed 50% of your weekly target.
You compared your results with the previous week and documented the changes.
You have 2 feedbacks to RC in your deck",
                WeekNumber = 3,
                Header = "Productivity vs. week2 increased + 25%",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                   new UserCalendarItemAction
                   {
                        Id=79,
                         Description = "Check the results of your submissions. Identify the hardest problem.",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 13,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id=80,
                         Description = "CiC with Manager, discuss your innovation idea",
                         Url = string.Empty,
                         Duration = 10,
                         UserCalendarItemId = 13,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=81,
                         Description = "Development work",
                         Url = string.Empty,
                         Duration = 350,
                         UserCalendarItemId = 8,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=82,
                         Description = "Make TMS video of 1 unit produced",
                         Url = string.Empty,
                         Duration = 0,
                         UserCalendarItemId = 13,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id=83,
                         Description = "Compare TMS for this week and the previous, document the changes",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 13,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id=84,
                         Description = "Technical coaching session",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 13,
                         IsDeleted = true
                   },
                    new UserCalendarItemAction
                   {
                        Id=85,
                         Description = "Add 1 feedback about the RC to WSPro deck",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 13,
                         IsDeleted = true
                   }
                }
            };
        }
        private static UserCalendarItem UserCalendarItemForWeek3WedNesday()
        {
            return new UserCalendarItem
            {
                Id = 14,
                Day = DayOfWeek.Wednesday.ToString(),
                Description = @"You completed 75% of your weekly target.
You completed the ""Provide feedback"" section in your deck",
                WeekNumber = 3,
                Header = "Productivity vs. week2 increased + 25%",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                   new UserCalendarItemAction
                   {
                        Id=86,
                         Description = "Check the results of your submissions. Identify the hardest problem.",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 14,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=87,
                         Description = "Development work",
                         Url = string.Empty,
                         Duration = 380,
                         UserCalendarItemId = 14,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=88,
                         Description = "Technical coaching session",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 14,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=89,
                         Description = "Finish RC feedback section in your deck",
                         Url = string.Empty,
                         Duration = 40,
                         UserCalendarItemId = 14,
                         IsDeleted = true
                   }
                }
            };
        }
        private static UserCalendarItem UserCalendarItemForWeek3Thursday()
        {
            return new UserCalendarItem
            {
                Id = 15,
                Day = DayOfWeek.Thursday.ToString(),
                Description = @"You completed 100% of your weekly target.
You reviewed WSPro section,
Provide feedback,
Negative feedback sections with your manager and addressed his feedback",
                WeekNumber = 3,
                Header = "Productivity vs. week2 increased + 25%",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                   new UserCalendarItemAction
                   {
                        Id=90,
                         Description = "Check the results of your submissions. Identify the hardest problem.",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 15,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=91,
                         Description = "CiC with Manager, review deck",
                         Url = string.Empty,
                         Duration = 10,
                         UserCalendarItemId = 15,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                         Id=92,
                         Description = "Development work",
                         Url = string.Empty,
                         Duration = 380,
                         UserCalendarItemId = 15,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=93,
                         Description = "Technical coaching session",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 15,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=94,
                         Description = "Address manager\"''\"s feedback in your deck",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 15,
                         IsDeleted = true
                   }
                }
            };
        }
        private static UserCalendarItem UserCalendarItemForWeek3Friday()
        {
            return new UserCalendarItem
            {
                Id = 16,
                Day = DayOfWeek.Friday.ToString(),
                Description = @"You checked all failures and caught up with all the tasks undone for this week.
You refined your idea to double the productivity based on the results of the previous week.
Your WSPro deck is ready except the final results page.
You provided the NPS to the RC management.",
                WeekNumber = 3,
                Header = "Productivity vs. week2 increased + 25%",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                   new UserCalendarItemAction
                   {
                         Id=95,
                         Description = "Check the results of your submissions. Identify the hardest problem.",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 16,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=96,
                         Description = "Development work",
                         Url = string.Empty,
                         Duration = 350,
                         UserCalendarItemId = 16,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=97,
                         Description = "Check the results of your automation idea, refine it.",
                         Url = string.Empty,
                         Duration = 90,
                         UserCalendarItemId = 16,
                         IsDeleted = true
                   },
                    new UserCalendarItemAction
                   {
                        Id=98,
                         Description = "Fill the NPS RemoteCamp form to summarize your experience of the week",
                         Url = string.Empty,
                         Duration = 10,
                         UserCalendarItemId = 16,
                         IsDeleted = true
                   }
                }
            };
        }
        #endregion

        #region week 4 Section
        private static UserCalendarItem UserCalendarItemForWeek4Monday()
        {
            return new UserCalendarItem
            {
                Id = 17,
                Day = DayOfWeek.Monday.ToString(),
                Description = @"You know your plan for this week.
You started to work on your assignments and completed 25% of the weekly target.
You planned your improvements(by 25%) and documented it.
You refined your idea to double the productivity.",
                WeekNumber = 4,
                Header = "Productivity vs. week3 increased + 25%",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                   new UserCalendarItemAction
                   {
                         Id=99,
                         Description = "Make a weekly plan of deliveries. Recommended distribution of load is: 25/25/25/25/fix+catchup",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 17,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=100,
                         Description = "Check the results of your submissions. Identify the hardest problem.",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 17,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=101,
                         Description = "Analyse your last week performance. Plan this week improvements, document this plan. Search the tools to improve your productivity.",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 17,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=102,
                         Description = "Development work",
                         Url = string.Empty,
                         Duration = 390,
                         UserCalendarItemId = 17,
                         IsDeleted = true
                   }
                }
            };
        }
        private static UserCalendarItem UserCalendarItemForWeek4Tuesday()
        {
            return new UserCalendarItem
            {
                Id = 18,
                Day = DayOfWeek.Tuesday.ToString(),
                Description = @"You discussed your hardest problem with your manager.
You completed 50% of your weekly target.
You compared your results with the previous week and documented the changes.",
                WeekNumber = 4,
                Header = "Productivity vs. week3 increased + 25%",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                   new UserCalendarItemAction
                   {
                        Id=103,
                         Description = "Check the results of your submissions. Identify the hardest problem.",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 18,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=104,
                         Description = "CiC with Manager, discuss your improvements during the previous weeks and the further directions to improve, ask for the feedback",
                         Url = string.Empty,
                         Duration = 10,
                         UserCalendarItemId = 18,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=105,
                         Description = "Development work",
                         Url = string.Empty,
                         Duration = 380,
                         UserCalendarItemId = 18,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=106,
                         Description = "Make TMS video of 1 unit produced",
                         Url = string.Empty,
                         Duration = 0,
                         UserCalendarItemId = 18,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=107,
                         Description = "Compare TMS for this week and the previous, document the changes",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 18,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=108,
                         Description = "Technical coaching session",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 18,
                         IsDeleted = true
                   }
                }
            };
        }
        private static UserCalendarItem UserCalendarItemForWeek4WedNesday()
        {
            return new UserCalendarItem
            {
                Id = 19,
                Day = DayOfWeek.Wednesday.ToString(),
                Description = @"You completed 75% of your weekly target.
You filled the ""Results"" section of your deck(prev.3 weeks)",
                WeekNumber = 4,
                Header = "Productivity vs. week3 increased + 25%",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                   new UserCalendarItemAction
                   {
                        Id=109,
                         Description = "Check the results of your submissions. Identify the hardest problem.",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 19,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=110,
                         Description = "Development work",
                         Url = string.Empty,
                         Duration = 400,
                         UserCalendarItemId = 19,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=111,
                         Description = "Technical coaching session",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 19,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=112,
                         Description = "Fill the \"Results\" section in the deck (previous 3 weeks)",
                         Url = string.Empty,
                         Duration = 20,
                         UserCalendarItemId = 19,
                         IsDeleted = true
                   }
                }
            };
        }
        private static UserCalendarItem UserCalendarItemForWeek4Thursday()
        {
            return new UserCalendarItem
            {
                Id = 20,
                Day = DayOfWeek.Thursday.ToString(),
                Description = @"You completed 100% of your weekly target.
You addressed all the feedbacks and your WSPro deck is ready",
                WeekNumber = 4,
                Header = "Productivity vs. week3 increased + 25%",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                   new UserCalendarItemAction
                   {
                        Id=113,
                         Description = "Check the results of your submissions. Identify the hardest problem.",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 20,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=114,
                         Description = "CiC with Manager, final review deck, ask for the feedback",
                         Url = string.Empty,
                         Duration = 10,
                         UserCalendarItemId = 20,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=115,
                         Description = "Development work",
                         Url = string.Empty,
                         Duration = 380,
                         UserCalendarItemId = 20,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=116,
                         Description = "Technical coaching session",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 20,
                         IsDeleted = true
                   },
                   new UserCalendarItemAction
                   {
                        Id=117,
                         Description = "Address manager\"''\"s feedback in your deck",
                         Url = string.Empty,
                         Duration = 30,
                         UserCalendarItemId = 20,
                         IsDeleted = true
                   }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek4Friday()
        {
            return new UserCalendarItem
            {
                Id = 21,
                Day = DayOfWeek.Friday.ToString(),
                Description = @"You checked all failures and caught up with all the tasks undone for this week.
You have graduated from the RemoteCamp.
You enjoy your party on this occasion.",
                WeekNumber = 4,
                Header = "Productivity vs. week3 increased + 25%",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id=118,
                        Description = "Check the results of your submissions. Identify the hardest problem.",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 21,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id=119,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 420,
                        UserCalendarItemId = 21,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id=120,
                        Description = "Fill the results for the last week to your deck",
                        Url = string.Empty,
                        Duration = 10,
                        UserCalendarItemId = 21,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id=121,
                        Description = "Graduation panel",
                        Url = string.Empty,
                        Duration = 20,
                        UserCalendarItemId = 21,
                        IsDeleted = true
                    }
                }
            };
        }

        #endregion

        #region week 1 Section (New)

        private static UserCalendarItem UserCalendarItemForWeek1MondayNew()
        {
            return new UserCalendarItem
            {
                Id = 2,
                Header = "Onboard to remote work and own your productivity",
                Day = DayOfWeek.Monday.ToString(),
                Description = @"You know your plan for this week.
You know how the tracker works.
You started your alignment with the Manager.
You started to work on your assignments and completed 5% of the weekly target",
                WeekNumber = 1,
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 354,
                        Description = "Read \"Most of what you read about remote work is wrong\"",
                        Url = "https://docs.google.com/document/d/1hRBBFZWNQY7tEX0RP0wRb6nvjv-y5xUUBWqaKgIkW1U/edit",
                        Duration = 4,
                        UserCalendarItemId = 2,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 355,
                        Description = "Read \"Weekly routine\"",
                        Url = "https://docs.google.com/document/d/1q7dwT0-EI2qXHGpAgzKB2bsTA6qN2JOdLEgK4YaJ0sY/edit?usp=sharing",
                        Duration = 3,
                        UserCalendarItemId = 2,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=123,
                        Description = "Read \"Welcome Negative feedback\"",
                        Url = "https://drive.google.com/open?id=1RF6wgfeobYV4c6b3TyAA7EjJiOViJtfxD2em7H_vfRU",
                        Duration = 8,
                        UserCalendarItemId = 2,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 356,
                        Description = "Read \"Tackle the Hardest Problem\"",
                        Url = "https://drive.google.com/file/d/1RQEXKpCgk__mjwTWf46h0Nf2O-ri_hof/view",
                        Duration = 5,
                        UserCalendarItemId = 2,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 357,
                        Description = "Read \"You have to be 3x as productive as an office worker\"",
                        Url = "https://docs.google.com/document/d/1fQmTAMMghqwPDZ5uUTGkK5HPgYL_7lUl1FGibohNgKA/edit?usp=sharing",
                        Duration = 2,
                        UserCalendarItemId = 2,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 358,
                        Description = "Read \"Own Your Productivity\"",
                        Url = "https://docs.google.com/document/d/1gpLbAU0Nzou3EvmpAWUQdRE-yMcPaaDYdeoEk8Y6xTw/edit?usp=sharing",
                        Duration = 5,
                        UserCalendarItemId = 2,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 359,
                        Description = "Watch \"Time Motion Study\"",
                        Url = "https://drive.google.com/file/d/1cH3BfDpQ_h7S6-HhFDPaMvnhWmzCgBAO/view?usp=sharing",
                        Duration = 19,
                        UserCalendarItemId = 2,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 360,
                        Description = "Watch \"Zero-Based Target\"",
                        Url = "https://crossover.zoom.us/recording/play/5tBvVn6BJAJh7rFFBZNrqACGNjF3mOpaF52g0lXd-MQHjCwVWGp-ii-HSIwVnsrD?continueMode=true",
                        Duration = 29,
                        UserCalendarItemId = 2,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 361,
                        Description = "Watch \"WSPro Tool Certified\"",
                        Url = "https://drive.google.com/file/d/1ZTHN44YPqBY5WFwsiFeUeSOp8qrecz_h/view?usp=sharing",
                        Duration = 18,
                        UserCalendarItemId = 2,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 362,
                        Description = "Read \"Intensity & Focus Blocks \"",
                        Url = "https://drive.google.com/open?id=1CMlnXFNBOOid6e5wsTgQeriapXMDfy3hi4qtH99nH5Q",
                        Duration = 6,
                        UserCalendarItemId = 2,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 122,
                        Description = "Read \"Follow Your Calendar\"",
                        Url = "https://drive.google.com/open?id=1u90OxXmLrfSsphaTJ81Gu-o5JU4aj5tqw36K_K6YoV4",
                        Duration = 9,
                        UserCalendarItemId = 2,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 124,
                        Description = "Get the list of assignments (jira) and do a preliminary analysis. Form your Input Quality Bar and use QnA sheet to ask questions for the assignments which are not clear.",
                        Url = "https://docs.google.com/spreadsheets/d/1-zKfuHjZKe-696mcumjdiCNR9jDJTeLtNZL-9eGgy3w/edit#gid=784927824",
                        Duration = 30,
                        UserCalendarItemId = 2,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 125,
                        Description = "Make a weekly plan of deliveries. Recommended distribution of load is: 5/30/30/30/5+fix+catchup. Use the daily plan sheet in your assignment folder.",
                        Url = "https://remoteu.trilogy.com/plan",
                        Duration = 20,
                        UserCalendarItemId = 2,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 126,
                        Description = "CiC with Manager",
                        Url = string.Empty,
                        Duration = 15,
                        UserCalendarItemId = 2,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 127,
                        Description = "Ask technical questions to mentors, setup projects, watch and read technical documentation applicable to your track. Align with your mentor on Internal Quality Bars, have no different opinion. Create a physical sheet of quality bars and assignment matrix.",
                        Url = "https://drive.google.com/open?id=1QNGyddEVA6mO8sbi4CZ8M-XxaybskglUP38gSqEgtmo",
                        Duration = 240,
                        UserCalendarItemId = 2,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 128,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 67,
                        UserCalendarItemId = 2,
                        IsDeleted = false
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek1TuesdayNew()
        {
            return new UserCalendarItem
            {
                Id = 3,
                Header = "Onboard to remote work and own your productivity",
                Day = DayOfWeek.Tuesday.ToString(),
                Description = @"You know your failures.
You are identified your hardest problem and started to think how to resolve it,and discussed it with your manager.
You completed 40% of your weekly target.",
                WeekNumber = 1,
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 132,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)",
                        Duration = 30,
                        UserCalendarItemId = 3,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 133,
                        Description = "CiC with Manager",
                        Url = string.Empty,
                        Duration = 15,
                        UserCalendarItemId = 3,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 134,
                        Description = "Development work",
                        Url = "https://drive.google.com/open?id=1IN3V4uEnjL2J5AnwdDmIABwCr3d6fzEJE_tDG7qXdqM",
                        Duration = 385,
                        UserCalendarItemId = 3,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 135,
                        Description = "Record a TMS video while producing a units",
                        Url = string.Empty,
                        Duration = 0,
                        UserCalendarItemId = 3,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=136,
                        Description = "Technical coaching session",
                        Url = "https://docs.google.com/document/u/1/d/1oc5kgAfOZgvOhvwHjLjyZJmPKkxMmwtg7vt-rncW1ss/edit",
                        Duration = 30,
                        UserCalendarItemId = 3,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=137,
                        Description = "Add your TMS to the Deck in your assignment folder",
                        Url = "https://docs.google.com/document/d/1oc5kgAfOZgvOhvwHjLjyZJmPKkxMmwtg7vt-rncW1ss/edit",
                        Duration = 20,
                        UserCalendarItemId = 3,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 129,
                        Description = "Read or watch \"Be an Expert/Tackle the hardest problem\"",
                        Url = "https://drive.google.com/open?id=1IN3V4uEnjL2J5AnwdDmIABwCr3d6fzEJE_tDG7qXdqM" ,
                        AdditionalUrl= "https://drive.google.com/open?id=1WbcAloWNZjJrWsYrFItyFUAmehm64ZFd",
                        Duration = 23,
                        UserCalendarItemId = 3,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 130,
                        Description = "Read \"Improving quality and productivity\"",
                        Url = "https://drive.google.com/open?id=12M7I2E4T47bk0jKprtdlsd8gt9iN4NVP7P4KLq-uv38",
                        Duration = 6,
                        UserCalendarItemId = 3,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 131,
                        Description = "Read \"Importance of Intensity and focus blocks\"",
                        Url = "https://drive.google.com/open?id=1CMlnXFNBOOid6e5wsTgQeriapXMDfy3hi4qtH99nH5Q",
                        Duration = 6,
                        UserCalendarItemId = 3,
                        IsDeleted = true
                    },
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek1WednesdayNew()
        {
            return new UserCalendarItem
            {
                Id = 4,
                Header = "Onboard to remote work and own your productivity",
                Day = DayOfWeek.Wednesday.ToString(),
                Description = @"You planned your improvements.
You completed 65% of your weekly target.
Your WSPro deck has TMS and improvement plan linked.",
                WeekNumber = 1,
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 140,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)",
                        Duration = 30,
                        UserCalendarItemId = 4,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 141,
                        Description = "CiC with Manager",
                        Url = string.Empty,
                        Duration = 15,
                        UserCalendarItemId = 4,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 142,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 375,
                        UserCalendarItemId = 4,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 143,
                        Description = "Technical coaching session",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 4,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 144,
                        Description = "Identify possible improvements",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 3,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 138,
                        Description = "Read \"How to deliver 100% quality?\"",
                        Url = "https://drive.google.com/open?id=1goA6vWrBJmmtJnmv-UOg5uXwcO6iHw9S1eKBNfRYFqM",
                        Duration = 6,
                        UserCalendarItemId = 4,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 139,
                        Description = "Read \"Root Cause Analysis\"",
                        Url = "https://drive.google.com/open?id=13iWjYSNF_00RNsevjWMyzX3DNQofLbsxpJF0vAXGiFE",
                        Duration = 6,
                        UserCalendarItemId = 4,
                        IsDeleted = true
                    },
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek1ThursdayNew()
        {
            return new UserCalendarItem
            {
                Id = 5,
                Header = "Onboard to remote work and own your productivity",
                Day = DayOfWeek.Thursday.ToString(),
                Description = @"You started to fill WSPro deck with your insights.
You completed 95% of your weekly target.",
                WeekNumber = 1,
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id=146,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)",
                        Duration = 30,
                        UserCalendarItemId = 5,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=147,
                        Description = "CiC with Manager",
                        Url = string.Empty,
                        Duration = 15,
                        UserCalendarItemId = 5,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=148,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 365,
                        UserCalendarItemId = 5,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 363,
                        Description = "Technical coaching session",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 5,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=145,
                        Description = "Read or Watch \"Put yourself in Customer's shoes\"",
                        Url = "https://drive.google.com/open?id=1J9kRxC_8dW2--6Jn_FxaQ1pa8KgSE-eYHj4CkwIfoe4" ,
                        AdditionalUrl="https://drive.google.com/open?id=1RUG_Ed2YCLeC52uRzQEZitcZfAe4IS6D",
                        Duration = 15,
                        UserCalendarItemId = 5,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id=149,
                        Description = "Check your WSPro statistics. Check your results. Find 1 insight and put it to WSPro deck",
                        Url = "https://app.crossover.com/x/dashboard/contractor/my-dashboard",
                        Duration = 40,
                        UserCalendarItemId = 5,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=150,
                        Description = "Fill the NPS form that you will receive within the day with an email to summarize your experience of the week",
                        Url = string.Empty,
                        Duration = 7,
                        UserCalendarItemId = 5,
                        IsDeleted = true
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek1FridayNew()
        {
            return new UserCalendarItem
            {
                Id = 6,
                Header = "Onboard to remote work and own your productivity",
                Day = DayOfWeek.Friday.ToString(),
                Description = @"You have 2 WSPro insights in your deck.
You completed 100% of your weekly target.
You provided the NPS to the RC management.",
                WeekNumber = 1,
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id=151,
                        Description = "Read \"Give Improvement Feedback\"",
                        Url = "https://drive.google.com/open?id=1Mt1HyCnSsU69yBmndtY0pYxtN787OD-gkjJpA3XLjeE",
                        Duration = 8,
                        UserCalendarItemId = 6,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id=152,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)",
                        Duration = 30,
                        UserCalendarItemId = 6,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=153,
                        Description = "CiC with Manager",
                        Url = string.Empty,
                        Duration = 15,
                        UserCalendarItemId = 6,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=154,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 360,
                        UserCalendarItemId = 6,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 364,
                        Description = "Technical coaching session",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 5,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=155,
                        Description = "Check your WSPro statistics. Check your results. Find 1 insight and put it to WSPro deck",
                        Url = "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)",
                        Duration = 40,
                        UserCalendarItemId = 6,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=156,
                        Description = "Fill the NPS form that you will receive within the day with an email to summarize your experience of the week",
                        Url = string.Empty,
                        Duration = 5,
                        UserCalendarItemId = 6,
                        IsDeleted = false
                    }
                }
            };
        }

        #endregion

        #region week 2 Section (New)

        private static UserCalendarItem UserCalendarItemForWeek2MondayNew()
        {
            return new UserCalendarItem
            {
                Id = 7,
                Day = DayOfWeek.Monday.ToString(),
                Description = @"You know your plan for this week.
You started to work on your assignments and completed 20% of the weekly target.
You planned your improvements(by 25%) and documented it.
You found the tools to improve your productivity.You have 3 WSPro insights in your deck",
                Header = "Be a quality expert",
                WeekNumber = 2,
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 379,
                        Description = "Read \"Be An Expert/Tackle the hardest problem\"",
                        Url = "https://drive.google.com/open?id=1IN3V4uEnjL2J5AnwdDmIABwCr3d6fzEJE_tDG7qXdqM",
                        Duration = 10,
                        UserCalendarItemId = 7,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 365,
                        Description = "Read \"Improving quality and productivity\"",
                        Url = "https://drive.google.com/open?id=12M7I2E4T47bk0jKprtdlsd8gt9iN4NVP7P4KLq-uv38",
                        Duration = 8,
                        UserCalendarItemId = 7,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 366,
                        Description = "Read \"How to deliver 100% quality\"",
                        Url = "https://drive.google.com/open?id=1goA6vWrBJmmtJnmv-UOg5uXwcO6iHw9S1eKBNfRYFqM",
                        Duration = 9,
                        UserCalendarItemId = 7,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 367,
                        Description = "Read \"Root Cause Analysis\"",
                        Url = "https://drive.google.com/open?id=13iWjYSNF_00RNsevjWMyzX3DNQofLbsxpJF0vAXGiFE",
                        Duration = 12,
                        UserCalendarItemId = 7,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 368,
                        Description = "Read \"Put yourself in customer shoes\"",
                        Url = "https://drive.google.com/open?id=1J9kRxC_8dW2--6Jn_FxaQ1pa8KgSE-eYHj4CkwIfoe4",
                        Duration = 5,
                        UserCalendarItemId = 7,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 369,
                        Description = "Read \"Give Improvement Feedback\"",
                        Url = "https://drive.google.com/open?id=1Mt1HyCnSsU69yBmndtY0pYxtN787OD-gkjJpA3XLjeE",
                        Duration = 6,
                        UserCalendarItemId = 7,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=157,
                        Description = "Read or watch \"Find tools to improve your productivity\"",
                        Url = "https://drive.google.com/open?id=1J9kRxC_8dW2--6Jn_FxaQ1pa8KgSE-eYHj4CkwIfoe4" ,
                        AdditionalUrl="https://drive.google.com/open?id=1RUG_Ed2YCLeC52uRzQEZitcZfAe4IS6D",
                        Duration = 15,
                        UserCalendarItemId = 7,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id=158,
                        Description = "Make a weekly plan of deliveries. Recommended distribution of load is: 20/25/25/25/5+fix+catchup",
                        Url = "https://remoteu.trilogy.com/plan" ,
                        AdditionalUrl ="https://drive.google.com/open?id=1YMslqRjd3tedFUXgUjHKZqjegXpF9Swn",
                        Duration = 20,
                        UserCalendarItemId = 7,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=159,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)",
                        Duration = 30,
                        UserCalendarItemId = 7,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=160,
                        Description = @"Analyse your last week performance. Plan this week improvements, document this plan. 
Search the tools to improve your productivity.",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 7,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=161,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 310,
                        UserCalendarItemId = 7,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 371,
                        Description = "Technical coaching session",
                        Url = string.Empty,
                        Duration = 15,
                        UserCalendarItemId = 7,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=162,
                        Description = "Add 1 WSPro insight to WSPro deck",
                        Url = string.Empty,
                        Duration = 25,
                        UserCalendarItemId = 7,
                        IsDeleted = false
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek2TuesdayNew()
        {
            return new UserCalendarItem
            {
                Id = 8,
                Day = DayOfWeek.Tuesday.ToString(),
                Description = @"You discussed your hardest problem with your manager.
You completed 45% of your weekly target.
You compared your results with the previous week and documented the changes.
You have 4 WSPro insights,1 negative feedback and 2 TMSs in your deck.",
                WeekNumber = 2,
                Header = "Be a quality expert",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 163,
                        Description = "Watch \"How to Make a Plan\"",
                        Url = "https://drive.google.com/open?id=1YMslqRjd3tedFUXgUjHKZqjegXpF9Swn",
                        Duration = 38,
                        UserCalendarItemId = 8,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id=164,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)",
                        Duration = 30,
                        UserCalendarItemId = 8,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=165,
                        Description = "CiC with Manager, ask for the negative feedback",
                        Url = string.Empty,
                        Duration = 10,
                        UserCalendarItemId = 8,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id=166,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 400,
                        UserCalendarItemId = 8,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=167,
                        Description = "Record a TMS video while producing a unit",
                        Url = string.Empty,
                        Duration = 0,
                        UserCalendarItemId = 8,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=168,
                        Description = "Compare TMS for this week and the previous, document the changes",
                        Url = string.Empty,
                        Duration = 16,
                        UserCalendarItemId = 8,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=169,
                        Description = "Technical coaching session",
                        Url = string.Empty,
                        Duration = 15,
                        UserCalendarItemId = 8,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=170,
                        Description = "Add 1 WSPro insight to WSPro deck",
                        Url = string.Empty,
                        Duration = 10,
                        UserCalendarItemId = 8,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=171,
                        Description = "Add 1 Negative feedback to WSPro deck",
                        Url = string.Empty,
                        Duration = 9,
                        UserCalendarItemId = 8,
                        IsDeleted = false
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek2WednesdayNew()
        {
            return new UserCalendarItem
            {
                Id = 9,
                Day = DayOfWeek.Wednesday.ToString(),
                Description = @"You completed 70% of your weekly target.
You completed the WSPro section in your deck.
You completed Negative feedback section of your deck",
                WeekNumber = 2,
                Header = "Be a quality expert",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id=172,
                        Description = "Read or watch \"Make Automation Suggestions to Team Lead\"",
                        Url = "https://drive.google.com/open?id=1WKGk2q2dfhP5_nB-HuQxzp04SIN4VL3gf2WlK7c5B9Q" ,
                        AdditionalUrl="https://drive.google.com/open?id=13QUNlMcVMN6yGIP7ym9ijAC3mTpFLkWs",
                        Duration = 15,
                        UserCalendarItemId = 9,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id=173,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)",
                        Duration = 30,
                        UserCalendarItemId = 9,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=174,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 410,
                        UserCalendarItemId = 9,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=175,
                        Description = "Technical coaching session",
                        Url = string.Empty,
                        Duration = 15,
                        UserCalendarItemId = 9,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=176,
                        Description = "Finish WSPro page in deck",
                        Url = string.Empty,
                        Duration = 25,
                        UserCalendarItemId = 9,
                        IsDeleted = false
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek2ThursdayNew()
        {
            return new UserCalendarItem
            {
                Id = 10,
                Day = DayOfWeek.Thursday.ToString(),
                Description = @"You completed 95% of your weekly target.
You reviewed WSPro section with your manager and addressed his feedback",
                WeekNumber = 2,
                Header = "Be a quality expert",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id=177,
                        Description = "Read or watch \"Seek Continuous Improvement and Experiment\"",
                        Url = "https://drive.google.com/open?id=1-4Zoh9MeXadFMxmF9sgsaP-4jK0VWCFBrr7urCaenDA" ,
                        AdditionalUrl ="https://drive.google.com/open?id=1gwq1h8hc-ucVLgk1aq1--D3ji_k4R8O_",
                        Duration = 15,
                        UserCalendarItemId = 10,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 178,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)",
                        Duration = 20,
                        UserCalendarItemId = 10,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 179,
                        Description = "CiC with Manager, ask for negative feedback",
                        Url = string.Empty,
                        Duration = 15,
                        UserCalendarItemId = 10,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id=180,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 425,
                        UserCalendarItemId = 10,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=181,
                        Description = "Technical coaching session",
                        Url = string.Empty,
                        Duration = 15,
                        UserCalendarItemId = 10,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=182,
                        Description = "Add 1 negative feedback to your deck",
                        Url = string.Empty,
                        Duration = 10,
                        UserCalendarItemId = 10,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=183,
                        Description = "Address manager's feedback in your deck",
                        Url = string.Empty,
                        Duration = 10,
                        UserCalendarItemId = 10,
                        IsDeleted = false
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek2FridayNew()
        {
            return new UserCalendarItem
            {
                Id = 11,
                Day = DayOfWeek.Friday.ToString(),
                Description = @"You checked all failures and caught up with all the tasks undone for this week.
You created the draft of your idea to double the productivity.
You provided the NPS to the RC management.",
                WeekNumber = 2,
                Header = "Be a quality expert",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id=184,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)",
                        Duration = 30,
                        UserCalendarItemId = 11,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=185,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 335,
                        UserCalendarItemId = 11,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 372,
                        Description = "Technical coaching session",
                        Url = string.Empty,
                        Duration = 15,
                        UserCalendarItemId = 11,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=186,
                        Description = "Prepare your automation idea to double your productivity. Send to your manager for approval",
                        Url = string.Empty,
                        Duration = 90,
                        UserCalendarItemId = 11,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=187,
                        Description = "Fill the NPS RemoteCamp form to summarize your experience of the week",
                        Url = string.Empty,
                        Duration = 10,
                        UserCalendarItemId = 11,
                        IsDeleted = false
                    }
                }
            };
        }

        #endregion

        #region week 3 Section (New)

        private static UserCalendarItem UserCalendarItemForWeek3MondayNew()
        {
            return new UserCalendarItem
            {
                Id = 12,
                Day = DayOfWeek.Monday.ToString(),
                Description = @"You know your plan for this week.
You started to work on your assignments and completed 20% of the weekly target.
You planned your improvements(by 25%) and documented it.
You refined your idea to double the productivity.
You added 1 feedback about the RC to your deck",
                WeekNumber = 3,
                Header = "Meet the team average and learn how to scale your productivity",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 373,
                        Description = "Read \"Enforcing Input Quality Bar\"",
                        Url = "https://crossover.atlassian.net/browse/TFR-318",
                        Duration = 10,
                        UserCalendarItemId = 12,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 374,
                        Description = "Read \"Find Tools to Improve Your Productivity\"",
                        Url = "https://drive.google.com/open?id=19dMKiWi6HUtC7eFK8hk0YUG6456wwn2VHlsrej8HW_Q",
                        Duration = 7,
                        UserCalendarItemId = 12,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 375,
                        Description = "Watch \"How to Make a Plan\"",
                        Url = "https://drive.google.com/open?id=1YMslqRjd3tedFUXgUjHKZqjegXpF9Swn",
                        Duration = 38,
                        UserCalendarItemId = 12,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 376,
                        Description = "Read \"Make Automation Suggestions to Team Lead\"",
                        Url = "https://drive.google.com/open?id=1WKGk2q2dfhP5_nB-HuQxzp04SIN4VL3gf2WlK7c5B9Q",
                        Duration = 5,
                        UserCalendarItemId = 12,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 377,
                        Description = "Read \"Seek Continuous Improvement and Experiment\"",
                        Url = "https://drive.google.com/open?id=1-4Zoh9MeXadFMxmF9sgsaP-4jK0VWCFBrr7urCaenDA",
                        Duration = 10,
                        UserCalendarItemId = 12,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 188,
                        Description = "Make a weekly plan of deliveries. Recommended distribution of load is: 20/25/25/25/5+fix+catchup",
                        Url = "https://remoteu.trilogy.com/plan",
                        Duration = 30,
                        UserCalendarItemId = 12,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 189,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)",
                        Duration = 30,
                        UserCalendarItemId = 12,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 190,
                        Description = "Analyse your last week performance. Plan this week improvements, document this plan. Search the tools to improve your productivity.",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 12,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 191,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 300,
                        UserCalendarItemId = 12,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 192,
                        Description = "Add 1 feedback about the RC to the WSPro deck",
                        Url = string.Empty,
                        Duration = 20,
                        UserCalendarItemId = 12,
                        IsDeleted = false
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek3TuesdayNew()
        {
            return new UserCalendarItem
            {
                Id = 13,
                Day = DayOfWeek.Tuesday.ToString(),
                Description = @"You discussed your hardest problem with your manager.
You completed 45% of your weekly target.
You compared your results with the previous week and documented the changes.
You have 2 feedbacks to RC in your deck",
                WeekNumber = 3,
                Header = "Meet the team average and learn how to scale your productivity",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 193,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)",
                        Duration = 30,
                        UserCalendarItemId = 13,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=194,
                        Description = "CiC with Manager, discuss your innovation idea",
                        Url = string.Empty,
                        Duration = 10,
                        UserCalendarItemId = 13,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=195,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 380,
                        UserCalendarItemId = 8,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=196,
                        Description = "Record a TMS video while producing a unit",
                        Url = string.Empty,
                        Duration = 0,
                        UserCalendarItemId = 13,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=197,
                        Description = "Compare TMS for this week and the previous, document the changes",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 13,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=198,
                        Description = "Technical coaching session",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 13,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id=199,
                        Description = "Add 1 feedback about the RC to WSPro deck",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 13,
                        IsDeleted = false
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek3WednesdayNew()
        {
            return new UserCalendarItem
            {
                Id = 14,
                Day = DayOfWeek.Wednesday.ToString(),
                Description = @"You completed 70% of your weekly target.
You completed the ""Provide feedback"" section in your deck",
                WeekNumber = 3,
                Header = "Meet the team average and learn how to scale your productivity",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id=200,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)",
                        Duration = 30,
                        UserCalendarItemId = 14,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=201,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 380,
                        UserCalendarItemId = 14,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=202,
                        Description = "Technical coaching session",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 14,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=203,
                        Description = "Finish RC feedback section in your deck",
                        Url = string.Empty,
                        Duration = 40,
                        UserCalendarItemId = 14,
                        IsDeleted = false
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek3ThursdayNew()
        {
            return new UserCalendarItem
            {
                Id = 15,
                Day = DayOfWeek.Thursday.ToString(),
                Description = @"You completed 95% of your weekly target.
You reviewed WSPro section,Provide feedback,Negative feedback sections with your manager and addressed his feedback",
                WeekNumber = 3,
                Header = "Meet the team average and learn how to scale your productivity",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id=204,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)",
                        Duration = 30,
                        UserCalendarItemId = 15,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=205,
                        Description = "CiC with Manager, review deck",
                        Url = string.Empty,
                        Duration = 10,
                        UserCalendarItemId = 15,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=206,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 410,
                        UserCalendarItemId = 15,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=207,
                        Description = "Technical coaching session",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 15,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id=208,
                        Description = "Address manager\"''\"s feedback in your deck",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 15,
                        IsDeleted = false
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek3FridayNew()
        {
            return new UserCalendarItem
            {
                Id = 16,
                Day = DayOfWeek.Friday.ToString(),
                Description = @"You checked all failures and caught up with all the tasks undone for this week.
You refined your idea to double the productivity based on the results of the previous week.
Your WSPro deck is ready except the final results page.
You provided the NPS to the RC management.",
                WeekNumber = 3,
                Header = "Meet the team average and learn how to scale your productivity",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id=209,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)",
                        Duration = 30,
                        UserCalendarItemId = 16,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=210,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 350,
                        UserCalendarItemId = 16,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=211,
                        Description = "Check the results of your automation idea, refine it.",
                        Url = string.Empty,
                        Duration = 90,
                        UserCalendarItemId = 16,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=212,
                        Description = "Fill the NPS RemoteCamp form to summarize your experience of the week",
                        Url = string.Empty,
                        Duration = 10,
                        UserCalendarItemId = 16,
                        IsDeleted = false
                    }
                }
            };
        }

        #endregion

        #region week 4 Section (New)

        private static UserCalendarItem UserCalendarItemForWeek4MondayNew()
        {
            return new UserCalendarItem
            {
                Id = 17,
                Day = DayOfWeek.Monday.ToString(),
                Description = @"You know your plan for this week.
You started to work on your assignments and completed 25% of the weekly target.
You planned your improvements(by 25%) and documented it.
You refined your idea to double the productivity.",
                WeekNumber = 4,
                Header = "Challenge the top performer",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 213,
                        Description = "Make a weekly plan of deliveries. Recommended distribution of load is: 25/25/25/25/fix+catchup",
                        Url = "https://remoteu.trilogy.com/plan",
                        Duration = 30,
                        UserCalendarItemId = 17,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 214,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)",
                        Duration = 30,
                        UserCalendarItemId = 17,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 215,
                        Description = "Analyse your last week performance. Plan this week improvements, document this plan. Search the tools to improve your productivity.",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 17,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id = 216,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 390,
                        UserCalendarItemId = 17,
                        IsDeleted = false
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek4TuesdayNew()
        {
            return new UserCalendarItem
            {
                Id = 18,
                Day = DayOfWeek.Tuesday.ToString(),
                Description = @"You discussed your hardest problem with your manager.
You completed 50% of your weekly target.
You compared your results with the previous week and documented the changes.",
                WeekNumber = 4,
                Header = "Challenge the top performer",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id=217,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)",
                        Duration = 30,
                        UserCalendarItemId = 18,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=218,
                        Description = "CiC with Manager, discuss your improvements during the previous weeks and the further directions to improve, ask for the feedback",
                        Url = string.Empty,
                        Duration = 10,
                        UserCalendarItemId = 18,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id=219,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 420,
                        UserCalendarItemId = 18,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=220,
                        Description = "Record a TMS video while producing a unit",
                        Url = string.Empty,
                        Duration = 0,
                        UserCalendarItemId = 18,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=221,
                        Description = "Compare TMS for this week and the previous, document the changes",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 18,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=222,
                        Description = "Technical coaching session",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 18,
                        IsDeleted = true
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek4WednesdayNew()
        {
            return new UserCalendarItem
            {
                Id = 19,
                Day = DayOfWeek.Wednesday.ToString(),
                Description = @"You completed 75% of your weekly target.
You filled the ""Results"" section of your deck(prev.3 weeks)",
                WeekNumber = 4,
                Header = "Challenge the top performer",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id=223,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)",
                        Duration = 30,
                        UserCalendarItemId = 19,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=224,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 450,
                        UserCalendarItemId = 19,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=225,
                        Description = "Technical coaching session",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 19,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id=226,
                        Description = "Fill the \"Results\" section in the deck (previous 3 weeks)",
                        Url = string.Empty,
                        Duration = 20,
                        UserCalendarItemId = 19,
                        IsDeleted = true
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek4ThursdayNew()
        {
            return new UserCalendarItem
            {
                Id = 20,
                Day = DayOfWeek.Thursday.ToString(),
                Description = @"You completed 100% of your weekly target.
You addressed all the feedbacks and your WSPro deck is ready",
                WeekNumber = 4,
                Header = "Challenge the top performer",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id=227,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)",
                        Duration = 30,
                        UserCalendarItemId = 20,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=228,
                        Description = "CiC with Manager, final review deck, ask for the feedback",
                        Url = string.Empty,
                        Duration = 10,
                        UserCalendarItemId = 20,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=229,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 410,
                        UserCalendarItemId = 20,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=230,
                        Description = "Technical coaching session",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 20,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id=231,
                        Description = "Address manager\"''\"s feedback in your deck",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 20,
                        IsDeleted = false
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek4FridayNew()
        {
            return new UserCalendarItem
            {
                Id = 21,
                Day = DayOfWeek.Friday.ToString(),
                Description = @"You checked all failures and caught up with all the tasks undone for this week.
You have graduated from the RemoteCamp.
You enjoy your party on this occasion.",
                WeekNumber = 4,
                Header = "Challenge the top performer",
                CalendarType = CalendarType.EngRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id=232,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://crossover.atlassian.net/issues/?filter=-1&jql=project%3DREM%20and%20type%3D%22RC%20Task%22%20and%20assignee%20%3DcurrentUser()%20AND%20status%20in%20(%22IN%20PROGRESS%22%2C%20%22IN%20REVIEW%22%2C%22APPROVED%22)",
                        Duration = 30,
                        UserCalendarItemId = 21,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=233,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 395,
                        UserCalendarItemId = 21,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=234,
                        Description = "Fill the results for the last week to your deck",
                        Url = string.Empty,
                        Duration = 10,
                        UserCalendarItemId = 21,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id=378,
                        Description = @"Fill the ""My progress"" and highlights sections in the deck",
                        Url = string.Empty,
                        Duration = 40,
                        UserCalendarItemId = 21,
                        IsDeleted = false
                    },
                    new UserCalendarItemAction
                    {
                        Id=235,
                        Description = "Graduation panel",
                        Url = string.Empty,
                        Duration = 15,
                        UserCalendarItemId = 21,
                        IsDeleted = false
                    }
                }
            };
        }

        #endregion

        #region week 0 Section (Calendar type ICRemoteU)

        private static UserCalendarItem UserCalendarItemForWeek0FridayIcRemoteU()
        {
            return new UserCalendarItem
            {
                Id = 22,
                Day = DayOfWeek.Friday.ToString(),
                Description = @"You are technically and mentally prepared to the adventure. 
All is set up. Check if everything works fine and please don't start the tracker until Monday morning.",
                WeekNumber = 0,
                Header = "Preparation for RemoteU",
                CalendarType = CalendarType.ICRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 245,
                        Description = "Get and read the Welcome email from RemoteU management and do the prerequisites in One-Pager",
                        Url = string.Empty,
                        Duration = 10,
                        UserCalendarItemId = 22,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 246,
                        Description = "Login RemoteU Portal with your company email and check if all accesses are green. Report failing accesses to remotecamp-sem@trilogy.com",
                        Url = "https://remoteu.trilogy.com",
                        Duration = 5,
                        UserCalendarItemId = 22,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 247,
                        Description = "Watch kickoff call and raise questions to remotecamp-sem@trilogy.com",
                        Url = "https://crossover.zoom.us/recording/play/kn9N20u326Ny-sdu4pVBkea0m2zIHtcwHDp_DQ9hYqXgi1Nmy33W9dLj1zrXgz1U?continueMode=true",
                        Duration = 30,
                        UserCalendarItemId = 22,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 248,
                        Description = "Read \"ESW Capital Factory Fundamentals\"",
                        Url = "https://docs.google.com/document/d/18BmZPmGPRCdbsqqEzvha7JVd61x_Dt-P-1WLZeipdB4/edit?usp=sharing",
                        Duration = 3,
                        UserCalendarItemId = 22,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 252,
                        Description = "\"Be an expert / Internet Strength\"",
                        Url = "https://docs.google.com/document/d/173RAU6zyRF0msWmBRUuNl6aCD8uai0yTi3FDo3YJZW4/edit?usp=sharing",
                        Duration = 2,
                        UserCalendarItemId = 22,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 253,
                        Description = "\"Be an expert / Physical background\"",
                        Url = "https://docs.google.com/document/d/1Nw4HU18zvY0f4F6MuYpbXUnMYBp7u4nT_j9JZe-8UxY/edit?usp=sharing",
                        Duration = 3,
                        UserCalendarItemId = 22,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 254,
                        Description = "\"Be an expert / Personal appearance\"",
                        Url = "https://docs.google.com/document/d/1IHdwqRndBQR4lHC2CYdcUD_BZUh2jskIvHiMtrDRDVQ/edit?usp=sharing",
                        Duration = 3,
                        UserCalendarItemId = 22,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 255,
                        Description = "\"Be an expert / Background noise\"",
                        Url = "https://docs.google.com/document/d/12HkOnCRiW3VD8Vw7z4mV3fQPZJ9pMA-TNK8Eu181txs/edit?usp=sharing",
                        Duration = 2,
                        UserCalendarItemId = 22,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 256,
                        Description = "\"Be an expert / Microphone quality and call etiquette\"",
                        Url = "https://docs.google.com/document/d/1KOFh2cG8V8OeVZOX8PmICN0ocdRumU6ZDma9_LZampI/edit?usp=sharing",
                        Duration = 2,
                        UserCalendarItemId = 22,
                        IsDeleted = true
                    },
                    new UserCalendarItemAction
                    {
                        Id = 257,
                        Description = "\"Be an expert / Computer\"",
                        Url = "https://docs.google.com/document/d/1-_KSD-EB28bay9qQYpz_Go1h7LJ23fi9eY7qGN2rYs0/edit?usp=sharing",
                        Duration = 2,
                        UserCalendarItemId = 22,
                        IsDeleted = true
                    }
                }
            };
        }

        #endregion

        #region week 1 Section (Calendar type ICRemoteU)

        private static UserCalendarItem UserCalendarItemForWeek1MondayIcRemoteU()
        {
            return new UserCalendarItem
            {
                Id = 23,
                Header = "IC RemoteU",
                Day = DayOfWeek.Monday.ToString(),
                Description = "You will work in IC RemoteU during the first week; our advice is to start preparations for EngRemoteU only after delivering all IC RemoteU related materials.",
                WeekNumber = 1,
                CalendarType = CalendarType.ICRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 258,
                        Description = "This week is reserved for IC RemoteU",
                        Url = string.Empty,
                        Duration = 480,
                        UserCalendarItemId = 23,
                        IsDeleted = false
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek1TuesdayIcRemoteU()
        {
            return new UserCalendarItem
            {
                Id = 24,
                Header = "IC RemoteU",
                Day = DayOfWeek.Tuesday.ToString(),
                Description = "You will work in IC RemoteU during the first week; our advice is to start preparations for EngRemoteU only after delivering all IC RemoteU related materials.",
                WeekNumber = 1,
                CalendarType = CalendarType.ICRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 259,
                        Description = "This week is reserved for IC RemoteU",
                        Url = string.Empty,
                        Duration = 480,
                        UserCalendarItemId = 24,
                        IsDeleted = false
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek1WednesdayIcRemoteU()
        {
            return new UserCalendarItem
            {
                Id = 25,
                Header = "IC RemoteU",
                Day = DayOfWeek.Wednesday.ToString(),
                Description = "You will work in IC RemoteU during the first week; our advice is to start preparations for EngRemoteU only after delivering all IC RemoteU related materials.",
                WeekNumber = 1,
                CalendarType = CalendarType.ICRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 260,
                        Description = "This week is reserved for IC RemoteU",
                        Url = string.Empty,
                        Duration = 480,
                        UserCalendarItemId = 25,
                        IsDeleted = false
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek1ThursdayIcRemoteU()
        {
            return new UserCalendarItem
            {
                Id = 26,
                Header = "IC RemoteU",
                Day = DayOfWeek.Thursday.ToString(),
                Description = "You will work in IC RemoteU during the first week; our advice is to start preparations for EngRemoteU only after delivering all IC RemoteU related materials.",
                WeekNumber = 1,
                CalendarType = CalendarType.ICRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 261,
                        Description = "This week is reserved for IC RemoteU",
                        Url = string.Empty,
                        Duration = 480,
                        UserCalendarItemId = 26,
                        IsDeleted = false
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek1FridayIcRemoteU()
        {
            return new UserCalendarItem
            {
                Id = 27,
                Header = "IC RemoteU",
                Day = DayOfWeek.Friday.ToString(),
                Description = "You will work in IC RemoteU during the first week; our advice is to start preparations for EngRemoteU only after delivering all IC RemoteU related materials.",
                WeekNumber = 1,
                CalendarType = CalendarType.ICRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 262,
                        Description = "This week is reserved for IC RemoteU",
                        Url = string.Empty,
                        Duration = 480,
                        UserCalendarItemId = 27,
                        IsDeleted = false,
                        Position = 0
                    },
                    new UserCalendarItemAction
                    {
                        Id = 380,
                        Description = "Read EngRemoteU Welcome email, watch kickoff calls and complete prerequisites",
                        Url = string.Empty,
                        Duration = 50,
                        UserCalendarItemId = 27,
                        IsDeleted = false,
                        Position = 1
                    },                    
                    new UserCalendarItemAction
                    {
                        Id = 249,
                        Description = "Read \"The Factory Model for Elite ICs\" and understand the benefits of \"Factory Model\" in IC's perspective",
                        Url = "https://drive.google.com/open?id=1LrrjfOJTXYckH70G5ohcSndp56cu9ALy6BvS7n_j40I",
                        Duration = 10,
                        UserCalendarItemId = 27,
                        IsDeleted = false,
                        Position = 2
                    },
                    new UserCalendarItemAction
                    {
                        Id = 250,
                        Description = "Read \"How you can fail in Eng.RemoteU\" and avoid common mistakes",
                        Url = "https://drive.google.com/open?id=1TE952cAjQo_MTVxBNKB4F4GsrwmFNMEI3JXXilS_M0Y",
                        Duration = 15,
                        UserCalendarItemId = 27,
                        IsDeleted = false,
                        Position = 3
                    },
                    new UserCalendarItemAction
                    {
                        Id = 251,
                        Description = "Watch \"Anti Cheating Policy\" and understand the boundaries of helping each other",
                        Url = "https://drive.google.com/open?id=1ToaleLywRtkhudjxBH9nCZAvdY1G27SH",
                        Duration = 30,
                        UserCalendarItemId = 27,
                        IsDeleted = false,
                        Position = 4
                    },
                    
                }
            };
        }

        #endregion

        #region week 2 Section (Calendar type ICRemoteU)

        private static UserCalendarItem UserCalendarItemForWeek2MondayIcRemoteU()
        {
            return new UserCalendarItem
            {
                Id = 28,
                Header = "Be a quality expert",
                Day = DayOfWeek.Monday.ToString(),
                Description = @"You;
* know your plan for this week and have resolved all your issues regarding accesses, backlog and technical assignments.
* know the list of quality bars and have printed a hard copy for yourself
* have completed all the training materials of the week.",
                WeekNumber = 2,
                CalendarType = CalendarType.ICRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 381,
                        Description = @"If you haven't confirmed before RemoteU, check if you have access to training materials, VPN and assignments. You should be a member of remotecamp-public Github group unless you are a QA Manual Tester.",
                        Url = "https://github.com/orgs/trilogy-group/teams/remotecamp-public/members",
                        Duration = 5,
                        UserCalendarItemId = 28,
                        IsDeleted = false,
                        Position = 0
                    },
                    new UserCalendarItemAction
                    {
                        Id = 382,
                        Description = @"Get the list of assignments in Jira and do a preliminary analysis. Learn how the ticket details are set.",
                        Url = "https://crossover.atlassian.net/issues/?filter=-1",
                        Duration = 20,
                        UserCalendarItemId = 28,
                        IsDeleted = false,
                        Position = 1
                    },
                    new UserCalendarItemAction
                    {
                        Id = 263,
                        Description = @"Get the list of assignments (jira) and do a preliminary analysis. Form your Input Quality Bar and use QnA sheet to ask questions for the assignments which are not clear.",
                        Url = "https://docs.google.com/spreadsheets/d/1-zKfuHjZKe-696mcumjdiCNR9jDJTeLtNZL-9eGgy3w/edit#gid=784927824",
                        Duration = 30,
                        UserCalendarItemId = 28,
                        IsDeleted = true,
                        Position = 2
                    },
                    new UserCalendarItemAction
                    {
                        Id = 264,
                        Description = "Read \"Be An Expert/Tackle the hardest problem\" Learn how to identify and tackle your hardest problem systematically.",
                        Url = "https://drive.google.com/open?id=1IN3V4uEnjL2J5AnwdDmIABwCr3d6fzEJE_tDG7qXdqM",
                        Duration = 15,
                        UserCalendarItemId = 28,
                        IsDeleted = false,
                        Position = 3
                    },
                    new UserCalendarItemAction
                    {
                        Id = 265,
                        Description = "Read \"Improving quality and productivity\" and understand how quality and productivity is measured and improved",
                        Url = "https://drive.google.com/open?id=12M7I2E4T47bk0jKprtdlsd8gt9iN4NVP7P4KLq-uv38",
                        Duration = 15,
                        UserCalendarItemId = 28,
                        IsDeleted = false,
                        Position = 4
                    },
                    new UserCalendarItemAction
                    {
                        Id = 266,
                        Description = "Read \"How to deliver 100% quality\" and shift your mindset to quality-focus. This week is about making mistakes and learning from it. Starting from the next week, you are asked to produce 100% quality.",
                        Url = "https://drive.google.com/open?id=1goA6vWrBJmmtJnmv-UOg5uXwcO6iHw9S1eKBNfRYFqM",
                        Duration = 15,
                        UserCalendarItemId = 28,
                        IsDeleted = false,
                        Position = 5
                    },
                    new UserCalendarItemAction
                    {
                        Id = 383,
                        Description = "Learn Input and Internal QBs of your module. Internalize them by watching the explanation videos. Print a physical copy of the quality bars and write down your understanding, assumptions and questions.",
                        Url = "https://docs.google.com/spreadsheets/d/1KjbpWYvB6dGFcowWlN2gAtNSsKsUDbgyixE-GSgdQBc/edit#gid=107425607",
                        Duration = 60,
                        UserCalendarItemId = 28,
                        IsDeleted = false,
                        Position = 6
                    },
                    new UserCalendarItemAction
                    {
                        Id = 384,
                        Description = "Learn where to check when you are blocked due to a technical knowledge gap.",
                        Url = "https://docs.google.com/spreadsheets/d/1KjbpWYvB6dGFcowWlN2gAtNSsKsUDbgyixE-GSgdQBc/edit#gid=1053071476",
                        Duration = 4,
                        UserCalendarItemId = 28,
                        IsDeleted = false,
                        Position = 7
                    },
                    new UserCalendarItemAction
                    {
                        Id = 385,
                        Description = "A ChatBot is available 24/7 to unblock you on Mattermost. Open Mattermost with the link and ask your first question: \"What is FTAR?\"",
                        Url = "https://xo.chat.crossover.com/core/channels/remoteu-general",
                        Duration = 2,
                        UserCalendarItemId = 28,
                        IsDeleted = false,
                        Position = 8
                    },
                    new UserCalendarItemAction
                    {
                        Id = 273,
                        Description = "Ask technical questions to mentors, set up projects, watch and read technical documentation applicable to your module. Align with your mentor on Quality Bars, have no different opinions.",
                        Url = "https://docs.google.com/spreadsheets/d/1-zKfuHjZKe-696mcumjdiCNR9jDJTeLtNZL-9eGgy3w/edit#gid=784927824",
                        Duration = 215,
                        UserCalendarItemId = 28,
                        IsDeleted = false,
                        Position = 9
                    },
                    new UserCalendarItemAction
                    {
                        Id = 267,
                        Description = "Read \"Root Cause Analysis\" and learn to make a great RCA and a corrective action",
                        Url = "https://drive.google.com/open?id=13iWjYSNF_00RNsevjWMyzX3DNQofLbsxpJF0vAXGiFE",
                        Duration = 15,
                        UserCalendarItemId = 28,
                        IsDeleted = false,
                        Position = 10
                    },
                    new UserCalendarItemAction
                    {
                        Id = 268,
                        Description = "Read \"Put yourself in customer shoes\" and understand the business value of your output",
                        Url = "https://drive.google.com/open?id=1J9kRxC_8dW2--6Jn_FxaQ1pa8KgSE-eYHj4CkwIfoe4",
                        Duration = 7,
                        UserCalendarItemId = 28,
                        IsDeleted = false,
                        Position = 11
                    },
                    new UserCalendarItemAction
                    {
                        Id = 275,
                        Description = "Read \"Give Improvement Feedback\" and be ready to provide your feedback to RemoteU on Friday with NPS form",
                        Url = "https://drive.google.com/open?id=1Mt1HyCnSsU69yBmndtY0pYxtN787OD-gkjJpA3XLjeE",
                        Duration = 7,
                        UserCalendarItemId = 28,
                        IsDeleted = false,
                        Position = 12
                    },
                    new UserCalendarItemAction
                    {
                        Id = 386,
                        Description = "Make a weekly plan for deliveries. Target a minimum of 2.5 for this week.",
                        Url = "https://remoteu.trilogy.com/plan",
                        Duration = 10,
                        UserCalendarItemId = 28,
                        IsDeleted = false,
                        Position = 13
                    },                    
                    new UserCalendarItemAction
                    {
                        Id = 269,
                        Description = @"Make a weekly plan of deliveries. Recommended distribution of load is: 20/25/25/25/5+fix+catchup.",
                        Url = "https://remoteu.trilogy.com/plan",
                        Duration = 20,
                        UserCalendarItemId = 28,
                        IsDeleted = true,
                        Position = 14
                    },
                    new UserCalendarItemAction
                    {
                        Id = 270,
                        Description = @"Prepare for CiC. Ask all RemoteU related questions to your manager. Learn how to conduct a CiC.",
                        Url = "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit",
                        Duration = 30,
                        UserCalendarItemId = 28,
                        IsDeleted = false,
                        Position = 15
                    },
                    new UserCalendarItemAction
                    {
                        Id = 271,
                        Description = @"Analyse your last week performance. Plan this week improvements, document this plan. Search the tools to improve your productivity.",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 28,
                        IsDeleted = true,
                        Position = 16
                    },
                    new UserCalendarItemAction
                    {
                        Id = 272,
                        Description = "Development work",
                        Url = "https://crossover.atlassian.net/issues/?filter=-1",
                        Duration = 60,
                        UserCalendarItemId = 28,
                        IsDeleted = false,
                        Position = 17
                    },
                    new UserCalendarItemAction
                    {
                        Id = 274,
                        Description = @"Add 1 WSPro insight to WSPro deck",
                        Url = string.Empty,
                        Duration = 25,
                        UserCalendarItemId = 28,
                        IsDeleted = true,
                        Position = 18
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek2TuesdayIcRemoteU()
        {
            return new UserCalendarItem
            {
                Id = 29,
                Header = "Be a quality expert",
                Day = DayOfWeek.Tuesday.ToString(),
                Description = @"You;
* have your local setup ready.
* have delivered units and received feedback from the reviewers.
* have identified your failures and taken actions to resolve them.
* have identified your hardest problem and discussed it with your manager.
* have your first WSPro insight and negative feedback on your Deck.
The quality of your work is improving as you have a quality bar - assignments matrix and checking submissions against QBs one by one. ",
                WeekNumber = 2,
                CalendarType = CalendarType.ICRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 387,
                        Description = "Review yesterday's submissions, take corrective actions on failures not to repeat them. Print a hard copy of a matrix with QBs and assignments. Check each submission against QBs before delivering.",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 29,
                        IsDeleted = false,
                        Position = 0
                    },
                    new UserCalendarItemAction
                    {
                        Id = 277,
                        Description = "Development work",
                        Url = "https://crossover.atlassian.net/issues/?filter=-1",
                        Duration = 330,
                        UserCalendarItemId = 29,
                        IsDeleted = false,
                        Position = 1
                    },
                    new UserCalendarItemAction
                    {
                        Id = 278,
                        Description = "Record a TMS video while producing a unit",
                        Url = string.Empty,
                        Duration = 0,
                        UserCalendarItemId = 29,
                        IsDeleted = false,
                        Position = 2
                    },           
                    new UserCalendarItemAction
                    {
                        Id = 279,
                        Description = "Watch your TMS, document activities in the TMS spreadsheet in your deliverables folder. Be granular while classifying activities.",
                        Url = Templater.IC_TMS_URL_PLACEHOLDER,
                        Duration = 30,
                        UserCalendarItemId = 29,
                        IsDeleted = false,
                        Position = 3
                    },
                    new UserCalendarItemAction
                    {
                        Id = 276,
                        Description = "It is the day you will start presenting in CiCs so learn CiC Framework and prepare for the meeting. Identify your hardest problem and discuss it with your manager.",
                        Url = "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit",
                        Duration = 40,
                        UserCalendarItemId = 29,
                        IsDeleted = false,
                        Position = 4
                    },
                    new UserCalendarItemAction
                    {
                        Id = 391,
                        Description = "Use ChatBot effectively to unblock yourself. Ask technical questions on the channel of your module. Use thumbs up for correct answers, thumbs down for wrong ones.",
                        Url = string.Empty,
                        Duration = 5,
                        UserCalendarItemId = 29,
                        IsDeleted = false,
                        Position = 5
                    },
                    new UserCalendarItemAction
                    {
                        Id = 280,
                        Description = "Attend technical coaching session.",
                        Url = "https://docs.google.com/spreadsheets/d/1-zKfuHjZKe-696mcumjdiCNR9jDJTeLtNZL-9eGgy3w/edit#gid=784927824",
                        Duration = 15,
                        UserCalendarItemId = 29,
                        IsDeleted = false,
                        Position = 6
                    },
                    new UserCalendarItemAction
                    {
                        Id = 281,
                        Description = "Start learning XO Dashboard application. Go through the timecards and add 1 WSPro insight to Deck.",
                        Url = "https://app.crossover.com/x/dashboard/contractor/my-dashboard",
                        Duration = 15,
                        UserCalendarItemId = 29,
                        IsDeleted = false,
                        Position = 7
                    },
                    new UserCalendarItemAction
                    {
                        Id = 282,
                        Description = "We love to provide feedback. Take all the negative feedback from your manager or mentor and add one of them to WSPro Deck.",
                        Url = Templater.IC_DECK_URL_PLACEHOLDER,
                        Duration = 15,
                        UserCalendarItemId = 29,
                        IsDeleted = false,
                        Position = 8
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek2WednesdayIcRemoteU()
        {
            return new UserCalendarItem
            {
                Id = 30,
                Header = "Be a quality expert",
                Day = DayOfWeek.Wednesday.ToString(),
                Description = @"You;
* have completed 60% of the weekly target. 
* have 3 WSPro insights on your Deck. 
* know how to be prepared for the meetings.
* have resolved any technical gaps.
* have an improving FTAR.",
                WeekNumber = 2,
                CalendarType = CalendarType.ICRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 283,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit",
                        Duration = 30,
                        UserCalendarItemId = 30,
                        IsDeleted = false,
                        Position = 0
                    },
                    new UserCalendarItemAction
                    {
                        Id = 284,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 335,
                        UserCalendarItemId = 30,
                        IsDeleted = false,
                        Position = 1
                    },
                    new UserCalendarItemAction
                    {
                        Id = 388,
                        Description = "Study your TMS for this week and identify your hardest problem. Implement the fix.",
                        Url = string.Empty,
                        Duration = 60,
                        UserCalendarItemId = 30,
                        IsDeleted = false,
                        Position = 2
                    },                    
                    new UserCalendarItemAction
                    {
                        Id = 285,
                        Description = "Attend technical coaching session",
                        Url = string.Empty,
                        Duration = 15,
                        UserCalendarItemId = 30,
                        IsDeleted = false,
                        Position = 3
                    },
                    new UserCalendarItemAction
                    {
                        Id = 286,
                        Description = "Check your WSPro statistics. Check your results. Find 2 insights and put it to WSPro Deck",
                        Url = "https://app.crossover.com/x/dashboard/contractor/my-dashboard",
                        Duration = 40,
                        UserCalendarItemId = 30,
                        IsDeleted = false,
                        Position = 4
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek2ThursdayIcRemoteU()
        {
            return new UserCalendarItem
            {
                Id = 31,
                Header = "Be a quality expert",
                Day = DayOfWeek.Thursday.ToString(),
                Description = @"You;
* have completed 80% of your weekly target. 
* have completed WSPro insights and negative feedback sections of Deck and addressed review feedbacks of your manager. 
* have TMS study added for the current week and fixed your hardest problem of the week.",
                WeekNumber = 2,
                CalendarType = CalendarType.ICRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 287,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem. Get review for WSPro insights and negative feedback slides.",
                        Url = "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit",
                        Duration = 20,
                        UserCalendarItemId = 31,
                        IsDeleted = false,
                        Position = 0
                    },
                    new UserCalendarItemAction
                    {
                        Id = 288,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 395,
                        UserCalendarItemId = 31,
                        IsDeleted = false,
                        Position = 1
                    },
                    new UserCalendarItemAction
                    {
                        Id = 289,
                        Description = "Attend technical coaching session",
                        Url = string.Empty,
                        Duration = 15,
                        UserCalendarItemId = 31,
                        IsDeleted = false,
                        Position = 2
                    },
                    new UserCalendarItemAction
                    {
                        Id = 290,
                        Description = "Add 1 negative feedback to your Deck",
                        Url = string.Empty,
                        Duration = 10,
                        UserCalendarItemId = 31,
                        IsDeleted = false,
                        Position = 3
                    },
                    new UserCalendarItemAction
                    {
                        Id = 291,
                        Description = "Check your WSPro statistics. Check your results. Find 1 insight and put it to WSPro Deck",
                        Url = "https://app.crossover.com/x/dashboard/contractor/my-dashboard",
                        Duration = 30,
                        UserCalendarItemId = 31,
                        IsDeleted = false,
                        Position = 4
                    },
                    new UserCalendarItemAction
                    {
                        Id = 292,
                        Description = "Address manager's feedback in your Deck",
                        Url = string.Empty,
                        Duration = 10,
                        UserCalendarItemId = 31,
                        IsDeleted = false,
                        Position = 5
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek2FridayIcRemoteU()
        {
            return new UserCalendarItem
            {
                Id = 32,
                Header = "Be a quality expert",
                Day = DayOfWeek.Friday.ToString(),
                Description = @"You;
* have completed 100% of your weekly target.
* are an expert of quality who knows how to produce 100% FTAR and make great RCAs.
* have provided NPS feedback to RU and added the same feedback to your Deck.",
                WeekNumber = 2,
                CalendarType = CalendarType.ICRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 293,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit",
                        Duration = 30,
                        UserCalendarItemId = 32,
                        IsDeleted = false,
                        Position = 0
                    },
                    new UserCalendarItemAction
                    {
                        Id = 294,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 425,
                        UserCalendarItemId = 32,
                        IsDeleted = false,
                        Position = 1
                    },
                    new UserCalendarItemAction
                    {
                        Id = 295,
                        Description = "Attend technical coaching session",
                        Url = string.Empty,
                        Duration = 15,
                        UserCalendarItemId = 32,
                        IsDeleted = false,
                        Position = 2
                    },
                    new UserCalendarItemAction
                    {
                        Id = 296,
                        Description = "Prepare your automation idea to double your productivity. Send to your manager for approval",
                        Url = string.Empty,
                        Duration = 90,
                        UserCalendarItemId = 32,
                        IsDeleted = true,
                        Position = 3
                    },
                    new UserCalendarItemAction
                    {
                        Id = 297,
                        Description = "Check your WSPro statistics. Check your results. Find 1 insight and put it to WSPro deck",
                        Url = "https://app.crossover.com/x/dashboard/contractor/my-dashboard",
                        Duration = 40,
                        UserCalendarItemId = 32,
                        IsDeleted = true,
                        Position = 4
                    },
                    new UserCalendarItemAction
                    {
                        Id = 298,
                        Description = "Fill the NPS form to summarize your experience of the week; add the same feedback to your Deck",
                        Url = "https://docs.google.com/forms/d/e/1FAIpQLScAZm0PCkwy0OcxXxRLAery7D5DQSLqgVN-V2vIMWry_wa6oA/viewform",
                        Duration = 10,
                        UserCalendarItemId = 32,
                        IsDeleted = false,
                        Position = 5
                    }
                }
            };
        }

        #endregion

        #region week 3 Section (Calendar type ICRemoteU)

        private static UserCalendarItem UserCalendarItemForWeek3MondayIcRemoteU()
        {
            return new UserCalendarItem
            {
                Id = 33,
                Header = "Meet the team average and learn how to scale your productivity",
                Day = DayOfWeek.Monday.ToString(),
                Description = @"You;
* target at least 3,75 points for this week in your plan.
* have completed 20% of the weekly goal.
* have gone through all productivity-related training materials.
* have your automation idea ready in your Deck.",
                WeekNumber = 3,
                CalendarType = CalendarType.ICRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 303,
                        Description = "Read \"Seek Continuous Improvement and Experiment\" and learn how to scale your productivity systematically",
                        Url = "https://drive.google.com/open?id=1-4Zoh9MeXadFMxmF9sgsaP-4jK0VWCFBrr7urCaenDA",
                        Duration = 15,
                        UserCalendarItemId = 33,
                        IsDeleted = false,
                        Position = 0
                    },
                    new UserCalendarItemAction
                    {
                        Id = 299,
                        Description = "Read \"Enforcing Input Quality Bar\" and refine your backlog",
                        Url = "https://crossover.atlassian.net/browse/TFR-318",
                        Duration = 30,
                        UserCalendarItemId = 33,
                        IsDeleted = false,
                        Position = 1
                    },
                    new UserCalendarItemAction
                    {
                        Id = 300,
                        Description = "Read \"Find Tools to Improve Your Productivity\" and search for tools that will help to speed up",
                        Url = "https://drive.google.com/open?id=19dMKiWi6HUtC7eFK8hk0YUG6456wwn2VHlsrej8HW_Q",
                        Duration = 30,
                        UserCalendarItemId = 33,
                        IsDeleted = false,
                        Position = 2
                    },
                    new UserCalendarItemAction
                    {
                        Id = 301,
                        Description = "Watch \"How to Make a Plan\" and create your plan of the week targeting a minimum of 3,75",
                        Url = "https://drive.google.com/open?id=1YMslqRjd3tedFUXgUjHKZqjegXpF9Swn",
                        Duration = 45,
                        UserCalendarItemId = 33,
                        IsDeleted = false,
                        Position = 3
                    },
                    new UserCalendarItemAction
                    {
                        Id = 389,
                        Description = "Read \"Make Automation Suggestions to Team Lead\" and come up with the idea that will boost your productivity. Identify your hardest problem and think about how you can eliminate it by using automation. Fill \"My automation suggestion to the Team Lead\" slide with the implementation plan",
                        Url = "https://drive.google.com/open?id=1WKGk2q2dfhP5_nB-HuQxzp04SIN4VL3gf2WlK7c5B9Q",
                        Duration = 45,
                        UserCalendarItemId = 33,
                        IsDeleted = false,
                        Position = 4
                    },
                    new UserCalendarItemAction
                    {
                        Id = 302,
                        Description = "Read \"Make Automation Suggestions to Team Lead\"",
                        Url = "https://drive.google.com/open?id=1WKGk2q2dfhP5_nB-HuQxzp04SIN4VL3gf2WlK7c5B9Q",
                        Duration = 5,
                        UserCalendarItemId = 33,
                        IsDeleted = true,
                        Position = 5
                    },
                    new UserCalendarItemAction
                    {
                        Id = 304,
                        Description = "Make a weekly plan of deliveries. Recommended distribution of load is: 20/25/25/25/5+fix+catchup",
                        Url = "https://remoteu.trilogy.com/plan",
                        Duration = 30,
                        UserCalendarItemId = 33,
                        IsDeleted = true,
                        Position = 6
                    },
                    new UserCalendarItemAction
                    {
                        Id = 305,
                        Description ="Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit",
                        Duration = 30,
                        UserCalendarItemId = 33,
                        IsDeleted = false,
                        Position = 7
                    },
                    new UserCalendarItemAction
                    {
                        Id = 306,
                        Description ="Analyse your last week performance. Plan this week improvements, document this plan. Search the tools to improve your productivity.",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 33,
                        IsDeleted = true,
                        Position = 8
                    },
                    new UserCalendarItemAction
                    {
                        Id = 307,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 285,
                        UserCalendarItemId = 33,
                        IsDeleted = false,
                        Position = 9
                    },
                    new UserCalendarItemAction
                    {
                        Id = 308,
                        Description = "Add 1 feedback about the RC to the WSPro deck",
                        Url = string.Empty,
                        Duration = 20,
                        UserCalendarItemId = 33,
                        IsDeleted = true,
                        Position = 10
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek3TuesdayIcRemoteU()
        {
            return new UserCalendarItem
            {
                Id = 34,
                Header = "Meet the team average and learn how to scale your productivity",
                Day = DayOfWeek.Tuesday.ToString(),
                Description = @"You;
* have completed 40% of the weekly target. 
* have analyzed TMS of the second week and validated your productivity increase after the implementation of the automation idea.",
                WeekNumber = 3,
                CalendarType = CalendarType.ICRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 309,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem. Get review for automation idea slide.",
                        Url = "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit",
                        Duration = 30,
                        UserCalendarItemId = 34,
                        IsDeleted = false,
                        Position = 0
                    },
                    new UserCalendarItemAction
                    {
                        Id = 310,
                        Description = "CiC with Manager, discuss your innovation idea",
                        Url = string.Empty,
                        Duration = 10,
                        UserCalendarItemId = 34,
                        IsDeleted = true,
                        Position = 1
                    },
                    new UserCalendarItemAction
                    {
                        Id = 311,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 420,
                        UserCalendarItemId = 34,
                        IsDeleted = false,
                        Position = 2
                    },
                    new UserCalendarItemAction
                    {
                        Id = 312,
                        Description = "Record a TMS video while producing a unit",
                        Url = string.Empty,
                        Duration = 0,
                        UserCalendarItemId = 34,
                        IsDeleted = false,
                        Position = 3
                    },
                    new UserCalendarItemAction
                    {
                        Id = 313,
                        Description = "Analyze TMS and compare with the previous week to identify the improvement after tool investigation, automation idea implementation and fixing knowledge gap; document the change in Deck",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 34,
                        IsDeleted = false,
                        Position = 4
                    },
                    new UserCalendarItemAction
                    {
                        Id = 314,
                        Description = "Finish WSPro page in deck",
                        Url = string.Empty,
                        Duration = 25,
                        UserCalendarItemId = 34,
                        IsDeleted = true,
                        Position = 5
                    },
                    new UserCalendarItemAction
                    {
                        Id = 315,
                        Description = "Add 1 feedback about the RC to WSPro deck",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 34,
                        IsDeleted = true,
                        Position = 6
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek3WednesdayIcRemoteU()
        {
            return new UserCalendarItem
            {
                Id = 35,
                Header = "Meet the team average and learn how to scale your productivity",
                Day = DayOfWeek.Wednesday.ToString(),
                Description = "You have completed 60% of your weekly target.",
                WeekNumber = 3,
                CalendarType = CalendarType.ICRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 316,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit",
                        Duration = 20,
                        UserCalendarItemId = 35,
                        IsDeleted = false,
                        Position = 0
                    },
                    new UserCalendarItemAction
                    {
                        Id = 317,
                        Description = "Technical coaching session",
                        Url = string.Empty,
                        Duration = 15,
                        UserCalendarItemId = 35,
                        IsDeleted = false,
                        Position = 1
                    },
                    new UserCalendarItemAction
                    {
                        Id = 318,
                        Description = "Finish RC feedback section in your deck",
                        Url = string.Empty,
                        Duration = 40,
                        UserCalendarItemId = 35,
                        IsDeleted = true,
                        Position = 2
                    },
                    new UserCalendarItemAction
                    {
                        Id = 319,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 445,
                        UserCalendarItemId = 35,
                        IsDeleted = false,
                        Position = 3
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek3ThursdayIcRemoteU()
        {
            return new UserCalendarItem
            {
                Id = 36,
                Header = "Meet the team average and learn how to scale your productivity",
                Day = DayOfWeek.Thursday.ToString(),
                Description = "You have completed 60% of your weekly target.",
                WeekNumber = 3,
                CalendarType = CalendarType.ICRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 320,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit",
                        Duration = 20,
                        UserCalendarItemId = 36,
                        IsDeleted = false,
                        Position = 0
                    },
                    new UserCalendarItemAction
                    {
                        Id = 321,
                        Description = "CiC with Manager",
                        Url = string.Empty,
                        Duration = 10,
                        UserCalendarItemId = 36,
                        IsDeleted = true,
                        Position = 1
                    },
                    new UserCalendarItemAction
                    {
                        Id = 322,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 460,
                        UserCalendarItemId = 36,
                        IsDeleted = false,
                        Position = 2
                    },
                    new UserCalendarItemAction
                    {
                        Id = 323,
                        Description = "Address manager's feedback in your deck",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 36,
                        IsDeleted = true,
                        Position = 3
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek3FridayIcRemoteU()
        {
            return new UserCalendarItem
            {
                Id = 37,
                Header = "Meet the team average and learn how to scale your productivity",
                Day = DayOfWeek.Friday.ToString(),
                Description = @"You;
* have completed 100% of your weekly target by delivering 100% quality. 
* have provided the NPS feedback of the week and added the same feedback to your Deck.
Congratulations! You are as productive as the team average and ready for the big challenge of the final week.",
                WeekNumber = 3,
                CalendarType = CalendarType.ICRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 324,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit",
                        Duration = 20,
                        UserCalendarItemId = 37,
                        IsDeleted = false,
                        Position = 0
                    },
                    new UserCalendarItemAction
                    {
                        Id = 325,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 450,
                        UserCalendarItemId = 37,
                        IsDeleted = false,
                        Position = 1
                    },
                    new UserCalendarItemAction
                    {
                        Id = 326,
                        Description = "Check the results of your automation idea, refine it.",
                        Url = string.Empty,
                        Duration = 90,
                        UserCalendarItemId = 37,
                        IsDeleted = true,
                        Position = 2
                    },
                    new UserCalendarItemAction
                    {
                        Id = 327,
                        Description = "Fill the NPS form to summarize your experience of the week; add the same feedback to your Deck",
                        Url = "https://docs.google.com/forms/d/e/1FAIpQLScAZm0PCkwy0OcxXxRLAery7D5DQSLqgVN-V2vIMWry_wa6oA/viewform",
                        Duration = 10,
                        UserCalendarItemId = 37,
                        IsDeleted = false,
                        Position = 3
                    },
                }
            };
        }

        #endregion

        #region week 4 Section (Calendar type ICRemoteU)

        private static UserCalendarItem UserCalendarItemForWeek4MondayIcRemoteU()
        {
            return new UserCalendarItem
            {
                Id = 38,
                Header = "Challenge the top performer",
                Day = DayOfWeek.Monday.ToString(),
                Description = @"You;
* are targeting to hit the performance of a top performer this week, so the target is a minimum of 5 points and 100% quality.
* have delivered 1 point today.
* have analyzed your TMS and have implemented the improvements.
Remember that this is the hands-off week, so there is no CiC with the manager.",
                WeekNumber = 4,
                CalendarType = CalendarType.ICRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 328,
                        Description = "Make a plan of deliverables",
                        Url = "https://remoteu.trilogy.com/plan",
                        Duration = 5,
                        UserCalendarItemId = 38,
                        IsDeleted = false,
                        Position = 0
                    },
                    new UserCalendarItemAction
                    {
                        Id = 329,
                        Description = "Identify your hardest problem and implement the fix",
                        Url = string.Empty,
                        Duration = 60,
                        UserCalendarItemId = 38,
                        IsDeleted = false,
                        Position = 1
                    },
                    new UserCalendarItemAction
                    {
                        Id = 330,
                        Description = "Analyze TMS and compare with the previous week to identify the improvement after tool investigation, automation idea implementation and fixing knowledge gap; document the change in Deck",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 38,
                        IsDeleted = false,
                        Position = 2
                    },
                    new UserCalendarItemAction
                    {
                        Id = 331,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 385,
                        UserCalendarItemId = 38,
                        IsDeleted = false,
                        Position = 3
                    },
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek4TuesdayIcRemoteU()
        {
            return new UserCalendarItem
            {
                Id = 39,
                Header = "Challenge the top performer",
                Day = DayOfWeek.Tuesday.ToString(),
                Description = "You have delivered 1 point today with 100% quality.",
                WeekNumber = 4,
                CalendarType = CalendarType.ICRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 332,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit",
                        Duration = 30,
                        UserCalendarItemId = 39,
                        IsDeleted = true,
                        Position = 0
                    },
                    new UserCalendarItemAction
                    {
                        Id = 333,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 450,
                        UserCalendarItemId = 39,
                        IsDeleted = false,
                        Position = 1
                    },
                    new UserCalendarItemAction
                    {
                        Id = 334,
                        Description = "Record a TMS video while producing a unit",
                        Url = string.Empty,
                        Duration = 0,
                        UserCalendarItemId = 39,
                        IsDeleted = true,
                        Position = 2
                    },
                    new UserCalendarItemAction
                    {
                        Id = 335,
                        Description = "Compare TMS for this week and the previous, document the changes",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 39,
                        IsDeleted = true,
                        Position = 3
                    },
                    new UserCalendarItemAction
                    {
                        Id = 392,
                        Description = "Record a TMS video while producing a unit",
                        Url = string.Empty,
                        Duration = 0,
                        UserCalendarItemId = 39,
                        IsDeleted = false,
                        Position = 4
                    },
                    new UserCalendarItemAction
                    {
                        Id = 393,
                        Description = "Analyze TMS and compare with the previous week to identify the improvement after tool investigation, automation idea implementation and fixing knowledge gap; document the change in Deck",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 39,
                        IsDeleted = false,
                        Position = 5
                    }
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek4WednesdayIcRemoteU()
        {
            return new UserCalendarItem
            {
                Id = 40,
                Header = "Challenge the top performer",
                Day = DayOfWeek.Wednesday.ToString(),
                Description = "You have delivered 1 point today with 100% quality.",
                WeekNumber = 4,
                CalendarType = CalendarType.ICRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 336,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit",
                        Duration = 30,
                        UserCalendarItemId = 40,
                        IsDeleted = true,
                        Position = 0
                    },
                    new UserCalendarItemAction
                    {
                        Id = 337,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 480,
                        UserCalendarItemId = 40,
                        IsDeleted = false,
                        Position = 1
                    },
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek4ThursdayIcRemoteU()
        {
            return new UserCalendarItem
            {
                Id = 41,
                Header = "Challenge the top performer",
                Day = DayOfWeek.Thursday.ToString(),
                Description = "You have delivered 1 point today with 100% quality.",
                WeekNumber = 4,
                CalendarType = CalendarType.ICRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 338,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit",
                        Duration = 30,
                        UserCalendarItemId = 41,
                        IsDeleted = true,
                        Position = 0
                    },
                    new UserCalendarItemAction
                    {
                        Id = 339,
                        Description = "CiC with Manager, final review deck, ask for the feedback",
                        Url = string.Empty,
                        Duration = 10,
                        UserCalendarItemId = 41,
                        IsDeleted = true,
                        Position = 1
                    },
                    new UserCalendarItemAction
                    {
                        Id = 340,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 480,
                        UserCalendarItemId = 41,
                        IsDeleted = false,
                        Position = 2
                    },
                    new UserCalendarItemAction
                    {
                        Id = 341,
                        Description = "Address manager's feedback in your deck",
                        Url = string.Empty,
                        Duration = 30,
                        UserCalendarItemId = 41,
                        IsDeleted = true,
                        Position = 3
                    },
                }
            };
        }

        private static UserCalendarItem UserCalendarItemForWeek4FridayIcRemoteU()
        {
            return new UserCalendarItem
            {
                Id = 42,
                Header = "Challenge the top performer",
                Day = DayOfWeek.Friday.ToString(),
                Description = @"You;
* have delivered 5 points this week with 100% quality.
* have provided the feedback of the last week.
* have finalized your Deck and had the final review with your manager.
* You are ready for the graduation panel.",
                WeekNumber = 4,
                CalendarType = CalendarType.ICRemoteU,
                UserCalendarItemActions = new List<UserCalendarItemAction>
                {
                    new UserCalendarItemAction
                    {
                        Id = 390,
                        Description = "Fill the NPS form to summarize your experience of the week; add the same feedback to your Deck",
                        Url = "https://docs.google.com/forms/d/e/1FAIpQLScAZm0PCkwy0OcxXxRLAery7D5DQSLqgVN-V2vIMWry_wa6oA/viewform",
                        Duration = 5,
                        UserCalendarItemId = 42,
                        IsDeleted = false,
                        Position = 0
                    },                    
                    new UserCalendarItemAction
                    {
                        Id = 342,
                        Description = "Prepare for CiC: Check the results of your submissions. Identify the hardest problem.",
                        Url = "https://docs.google.com/document/d/1IDD5TN33cQI65p2lSwnu285fJXSOVSe2ebNu1gIF5ak/edit",
                        Duration = 30,
                        UserCalendarItemId = 42,
                        IsDeleted = true,
                        Position = 1
                    },
                    new UserCalendarItemAction
                    {
                        Id = 343,
                        Description = "Development work",
                        Url = string.Empty,
                        Duration = 435,
                        UserCalendarItemId = 42,
                        IsDeleted = false,
                        Position = 2
                    },
                    new UserCalendarItemAction
                    {
                        Id = 344,
                        Description = "Fill \"My progress\", \"Highlights\" and the last improvement feedback in your Deck, and get the final review from your manager.",
                        Url = string.Empty,
                        Duration = 40,
                        UserCalendarItemId = 42,
                        IsDeleted = false,
                        Position = 3
                    },
                    new UserCalendarItemAction
                    {
                        Id = 345,
                        Description = "Graduation Panel",
                        Url = string.Empty,
                        Duration = 15,
                        UserCalendarItemId = 42,
                        IsDeleted = true,
                        Position = 4
                    }
                }
            };
        }

        #endregion

        public Pipeline[] GetPipelines()
        {
            return new[]
            {
                new Pipeline { Id = 1, Name = "Java Software Engineer" },
                new Pipeline { Id = 2, Name = "C# (.NET) Software Engineer" },
                new Pipeline { Id = 3, Name = "C++ Software Engineer" },
                new Pipeline { Id = 4, Name = "Front End Software Engineer" },
                new Pipeline { Id = 5, Name = "Java Software Architect" },
                new Pipeline { Id = 6, Name = "C# (.NET) Software Architect" },
                new Pipeline { Id = 7, Name = "Java Chief Software Architect" },
                new Pipeline { Id = 8, Name = "C# (.NET) Chief Software Architect" },
                new Pipeline { Id = 9, Name = "QA Manual Tester" },
                new Pipeline { Id = 10, Name = "QA Automation Engineer" },
                new Pipeline { Id = 11, Name = "Cloud Operations Engineer" },
                new Pipeline { Id = 12, Name = "Senior Cloud Operations Engineer" },
                new Pipeline { Id = 13, Name = "Senior Site Reliability Engineer" },
                new Pipeline { Id = 14, Name = "Test Automation Chief Software Architect" },
                new Pipeline { Id = 15, Name = "QA Software Architect" },
                new Pipeline { Id = 16, Name = "C++ Chief Software Architect" },
                new Pipeline { Id = 17, Name = "Front End Chief Software Architect" },
                new Pipeline { Id = 18, Name = "Front End Software Architect" },
                new Pipeline { Id = 19, Name = "C++ Software Architect" },
                new Pipeline { Id = 20, Name = "Software Tester" },
                new Pipeline { Id = 21, Name = "Technical Product Manager" }
                
            };
        }

        public PipelinePrerequisite[] GetPipelinePrerequisites()
        {
            return new[]
            {
                new PipelinePrerequisite { Id = 1, PipelineId = 1, Name = "Computer Skills" },
                new PipelinePrerequisite { Id = 2, PipelineId = 1, Name = "Java" },
                new PipelinePrerequisite { Id = 3, PipelineId = 1, Name = "Junit" },
                new PipelinePrerequisite { Id = 4, PipelineId = 1, Name = "Mockito" },
                new PipelinePrerequisite { Id = 5, PipelineId = 1, Name = "PowerMock" },
                new PipelinePrerequisite { Id = 6, PipelineId = 1, Name = "Git / GitHub" },
                new PipelinePrerequisite { Id = 7, PipelineId = 1, Name = "eclipse/IntelliJ" },
                new PipelinePrerequisite { Id = 8, PipelineId = 1, Name = "Mutation Testing" },
                new PipelinePrerequisite { Id = 9, PipelineId = 2, Name = "C#/Dot Net" },
                new PipelinePrerequisite { Id = 10, PipelineId = 2, Name = "Computer Skills" },
                new PipelinePrerequisite { Id = 11, PipelineId = 2, Name = "Nunit, MsTest, Xunit" },
                new PipelinePrerequisite { Id = 12, PipelineId = 2, Name = "Mock, MsFake" },
                new PipelinePrerequisite { Id = 13, PipelineId = 2, Name = "Shouldly" },
                new PipelinePrerequisite { Id = 14, PipelineId = 2, Name = "Visual Studio" },
                new PipelinePrerequisite { Id = 15, PipelineId = 2, Name = "Git / GitHub" },
                new PipelinePrerequisite { Id = 16, PipelineId = 2, Name = "Mutation Testing" },
                new PipelinePrerequisite { Id = 17, PipelineId = 3, Name = "Computer Skills" },
                new PipelinePrerequisite { Id = 18, PipelineId = 3, Name = "Google Test" },
                new PipelinePrerequisite { Id = 19, PipelineId = 3, Name = "Google Mock" },
                new PipelinePrerequisite { Id = 20, PipelineId = 3, Name = "Visual Studio" },
                new PipelinePrerequisite { Id = 21, PipelineId = 3, Name = "Open CPP" },
                new PipelinePrerequisite { Id = 22, PipelineId = 3, Name = "Git / GitHub" },
                new PipelinePrerequisite { Id = 23, PipelineId = 3, Name = "C++/VC++" },
                new PipelinePrerequisite { Id = 24, PipelineId = 3, Name = "Mutation Testing" },
                new PipelinePrerequisite { Id = 25, PipelineId = 4, Name = "Computer Skills" },
                new PipelinePrerequisite { Id = 26, PipelineId = 4, Name = "Git / GitHub" },
                new PipelinePrerequisite { Id = 27, PipelineId = 5, Name = "Computer Skills" },
                new PipelinePrerequisite { Id = 28, PipelineId = 5, Name = "Java" },
                new PipelinePrerequisite { Id = 29, PipelineId = 5, Name = "Git / GitHub" },
                new PipelinePrerequisite { Id = 30, PipelineId = 5, Name = "Refactoring technique" },
                new PipelinePrerequisite { Id = 31, PipelineId = 5, Name = "Design Patterns" },
                new PipelinePrerequisite { Id = 32, PipelineId = 5, Name = "Unit Testing" },
                new PipelinePrerequisite { Id = 33, PipelineId = 6, Name = "Computer Skills" },
                new PipelinePrerequisite { Id = 34, PipelineId = 6, Name = "Skils" },
                new PipelinePrerequisite { Id = 35, PipelineId = 6, Name = "C#" },
                new PipelinePrerequisite { Id = 36, PipelineId = 6, Name = "Git / GitHub" },
                new PipelinePrerequisite { Id = 37, PipelineId = 6, Name = "Refactoring Technique" },
                new PipelinePrerequisite { Id = 38, PipelineId = 6, Name = "Design Patterns" },
                new PipelinePrerequisite { Id = 39, PipelineId = 6, Name = "Unit Testing" },
                new PipelinePrerequisite { Id = 40, PipelineId = 7, Name = "Computer Skills" },
                new PipelinePrerequisite { Id = 41, PipelineId = 7, Name = "Git / GitHub" },
                new PipelinePrerequisite { Id = 42, PipelineId = 7, Name = "Windows" },
                new PipelinePrerequisite { Id = 43, PipelineId = 7, Name = "Apache Maven" },
                new PipelinePrerequisite { Id = 44, PipelineId = 7, Name = "Apache Tomcat" },
                new PipelinePrerequisite { Id = 45, PipelineId = 7, Name = "MySql" },
                new PipelinePrerequisite { Id = 46, PipelineId = 7, Name = "Java (deep knowledge)" },
                new PipelinePrerequisite { Id = 47, PipelineId = 7, Name = "Javascript" },
                new PipelinePrerequisite { Id = 48, PipelineId = 7, Name = "SQL" },
                new PipelinePrerequisite { Id = 49, PipelineId = 7, Name = "Hibernate" },
                new PipelinePrerequisite { Id = 50, PipelineId = 7, Name = "Spring Framework" },
                new PipelinePrerequisite { Id = 51, PipelineId = 7, Name = "SQL Query Optimization" },
                new PipelinePrerequisite { Id = 52, PipelineId = 7, Name = "Java Multi-threading" },
                new PipelinePrerequisite { Id = 53, PipelineId = 8, Name = "Computer Skills" },
                new PipelinePrerequisite { Id = 54, PipelineId = 8, Name = "Git / GitHub" },
                new PipelinePrerequisite { Id = 55, PipelineId = 8, Name = "Windows" },
                new PipelinePrerequisite { Id = 56, PipelineId = 8, Name = "MS Build" },
                new PipelinePrerequisite { Id = 57, PipelineId = 8, Name = "Internet Information Services (IIS)" },
                new PipelinePrerequisite { Id = 58, PipelineId = 8, Name = "MS SQL" },
                new PipelinePrerequisite { Id = 59, PipelineId = 8, Name = "C# (deep knowledge)" },
                new PipelinePrerequisite { Id = 60, PipelineId = 8, Name = "SQL" },
                new PipelinePrerequisite { Id = 61, PipelineId = 8, Name = "Entity Framework" },
                new PipelinePrerequisite { Id = 62, PipelineId = 8, Name = "ASP.NET Web Forms" },
                new PipelinePrerequisite { Id = 63, PipelineId = 8, Name = "SQL Query Optimization" },
                new PipelinePrerequisite { Id = 64, PipelineId = 8, Name = "C# Multi-threading" },
                new PipelinePrerequisite { Id = 65, PipelineId = 9, Name = "Computer Skills" },
                new PipelinePrerequisite { Id = 66, PipelineId = 9, Name = "Jira/Project Management Tool" },
                new PipelinePrerequisite { Id = 67, PipelineId = 9, Name = "Test Rail/ALM/ Test Management Tool" },
                new PipelinePrerequisite { Id = 68, PipelineId = 9, Name = "Functional & Non - Functional Testing" },
                new PipelinePrerequisite { Id = 69, PipelineId = 9, Name = "API Testing" },
                new PipelinePrerequisite { Id = 70, PipelineId = 9, Name = "Regression Testing" },
                new PipelinePrerequisite { Id = 71, PipelineId = 9, Name = "Smoke Testing" },
                new PipelinePrerequisite { Id = 72, PipelineId = 9, Name = "System Integration Testing" },
                new PipelinePrerequisite { Id = 73, PipelineId = 9, Name = "E2E Testing" },
                new PipelinePrerequisite { Id = 74, PipelineId = 9, Name = "Knowledge of SQL" },
                new PipelinePrerequisite { Id = 75, PipelineId = 9, Name = "SDLC Concepts" },
                new PipelinePrerequisite { Id = 76, PipelineId = 10, Name = "Computer Skills" },
                new PipelinePrerequisite { Id = 77, PipelineId = 10, Name = "TypeScript / JavaScript Knowledge" },
                new PipelinePrerequisite { Id = 78, PipelineId = 10, Name = "Git / GitHub" },
                new PipelinePrerequisite { Id = 79, PipelineId = 10, Name = "Protractor" },
                new PipelinePrerequisite { Id = 80, PipelineId = 10, Name = "Jira/Project Management" },
                new PipelinePrerequisite { Id = 81, PipelineId = 10, Name = "Test Rail/ALM/ Test Management Tool." },
                new PipelinePrerequisite { Id = 82, PipelineId = 10, Name = "E2E Testing" },
                new PipelinePrerequisite { Id = 83, PipelineId = 11, Name = "Virtualization" },
                new PipelinePrerequisite { Id = 84, PipelineId = 11, Name = "Cloud (AWS)" },
                new PipelinePrerequisite { Id = 85, PipelineId = 11, Name = "Docker" },
                new PipelinePrerequisite { Id = 86, PipelineId = 11, Name = "Kubernetes" },
                new PipelinePrerequisite { Id = 87, PipelineId = 11, Name = "Linux" },
                new PipelinePrerequisite { Id = 88, PipelineId = 11, Name = "Windows" },
                new PipelinePrerequisite { Id = 89, PipelineId = 11, Name = "Git / GitHub" },
                new PipelinePrerequisite { Id = 90, PipelineId = 11, Name = "Bash" },
                new PipelinePrerequisite { Id = 91, PipelineId = 11, Name = "Logging" },
                new PipelinePrerequisite { Id = 92, PipelineId = 11, Name = "TCP/IP" },
                new PipelinePrerequisite { Id = 93, PipelineId = 11, Name = "VPN, routing" },
                new PipelinePrerequisite { Id = 94, PipelineId = 11, Name = "FTP/SFTP" },
                new PipelinePrerequisite { Id = 95, PipelineId = 12, Name = "Virtualization" },
                new PipelinePrerequisite { Id = 96, PipelineId = 12, Name = "Cloud (AWS)" },
                new PipelinePrerequisite { Id = 97, PipelineId = 12, Name = "Docker" },
                new PipelinePrerequisite { Id = 98, PipelineId = 12, Name = "Kubernetes" },
                new PipelinePrerequisite { Id = 99, PipelineId = 12, Name = "Linux" },
                new PipelinePrerequisite { Id = 100, PipelineId = 12, Name = "Windows" },
                new PipelinePrerequisite { Id = 101, PipelineId = 12, Name = "Git / GitHub" },
                new PipelinePrerequisite { Id = 102, PipelineId = 12, Name = "Bash/Python" },
                new PipelinePrerequisite { Id = 103, PipelineId = 12, Name = "Java (minimal)" },
                new PipelinePrerequisite { Id = 104, PipelineId = 12, Name = "Logging" },
                new PipelinePrerequisite { Id = 105, PipelineId = 12, Name = "Monitoring" },
                new PipelinePrerequisite { Id = 106, PipelineId = 12, Name = "TCP/IP" },
                new PipelinePrerequisite { Id = 107, PipelineId = 12, Name = "VPN, routing" },
                new PipelinePrerequisite { Id = 108, PipelineId = 12, Name = "FTP/SFTP" },
                new PipelinePrerequisite { Id = 109, PipelineId = 12, Name = "SQL (MySQL)" },
                new PipelinePrerequisite { Id = 110, PipelineId = 13, Name = "Virtualization" },
                new PipelinePrerequisite { Id = 111, PipelineId = 13, Name = "Cloud (AWS)" },
                new PipelinePrerequisite { Id = 112, PipelineId = 13, Name = "Docker" },
                new PipelinePrerequisite { Id = 113, PipelineId = 13, Name = "Kubernetes" },
                new PipelinePrerequisite { Id = 114, PipelineId = 13, Name = "Linux" },
                new PipelinePrerequisite { Id = 115, PipelineId = 13, Name = "Windows" },
                new PipelinePrerequisite { Id = 116, PipelineId = 13, Name = "Git / GitHub" },
                new PipelinePrerequisite { Id = 117, PipelineId = 13, Name = "CI/CD (Jenkins)" },
                new PipelinePrerequisite { Id = 118, PipelineId = 13, Name = "Bash/Python" },
                new PipelinePrerequisite { Id = 119, PipelineId = 13, Name = "Java (minimal)" },
                new PipelinePrerequisite { Id = 120, PipelineId = 13, Name = "Infra-as-code" },
                new PipelinePrerequisite { Id = 121, PipelineId = 13, Name = "Terraform" },
                new PipelinePrerequisite { Id = 122, PipelineId = 13, Name = "Ansible" },
                new PipelinePrerequisite { Id = 123, PipelineId = 13, Name = "Logging" },
                new PipelinePrerequisite { Id = 124, PipelineId = 13, Name = "Monitoring" },
                new PipelinePrerequisite { Id = 125, PipelineId = 13, Name = "TCP/IP" },
                new PipelinePrerequisite { Id = 126, PipelineId = 13, Name = "VPN, routing" },
                new PipelinePrerequisite { Id = 127, PipelineId = 13, Name = "FTP/SFTP" },
                new PipelinePrerequisite { Id = 128, PipelineId = 13, Name = "SQL (MySQL)" },
                new PipelinePrerequisite { Id = 129, PipelineId = 14, Name = "Computer Skills" },
                new PipelinePrerequisite { Id = 130, PipelineId = 15, Name = "Computer Skills" },
                new PipelinePrerequisite { Id = 131, PipelineId = 16, Name = "Computer Skills" },
                new PipelinePrerequisite { Id = 132, PipelineId = 17, Name = "Computer Skills" },
                new PipelinePrerequisite { Id = 148, PipelineId = 17, Name = "Git / GitHub" },
                new PipelinePrerequisite { Id = 149, PipelineId = 17, Name = "JavaScript" },
                new PipelinePrerequisite { Id = 150, PipelineId = 17, Name = "AngularJS" },
                new PipelinePrerequisite { Id = 151, PipelineId = 17, Name = "Karma/Jasmine" },
                new PipelinePrerequisite { Id = 152, PipelineId = 17, Name = "Jira/Project Management" },
                new PipelinePrerequisite { Id = 153, PipelineId = 17, Name = "Unit Testing" },
                new PipelinePrerequisite { Id = 154, PipelineId = 17, Name = "Gulp" },
                new PipelinePrerequisite { Id = 133, PipelineId = 18, Name = "Computer Skills" },
                new PipelinePrerequisite { Id = 135, PipelineId = 4, Name = "JavaScript" },
                new PipelinePrerequisite { Id = 136, PipelineId = 4, Name = "AngularJS" },
                new PipelinePrerequisite { Id = 137, PipelineId = 4, Name = "Karma/Jasmine" },
                new PipelinePrerequisite { Id = 138, PipelineId = 4, Name = "Jira/Project Management" },
                new PipelinePrerequisite { Id = 139, PipelineId = 4, Name = "Unit Testing" },
                new PipelinePrerequisite { Id = 140, PipelineId = 4, Name = "Gulp" },
                new PipelinePrerequisite { Id = 141, PipelineId = 18, Name = "Git / GitHub" },
                new PipelinePrerequisite { Id = 142, PipelineId = 18, Name = "JavaScript" },
                new PipelinePrerequisite { Id = 143, PipelineId = 18, Name = "AngularJS" },
                new PipelinePrerequisite { Id = 144, PipelineId = 18, Name = "Karma/Jasmine" },
                new PipelinePrerequisite { Id = 145, PipelineId = 18, Name = "Jira/Project Management" },
                new PipelinePrerequisite { Id = 146, PipelineId = 18, Name = "Unit Testing" },
                new PipelinePrerequisite { Id = 147, PipelineId = 18, Name = "Gulp" },                
                new PipelinePrerequisite { Id = 134, PipelineId = 19, Name = "Computer Skills" },
                new PipelinePrerequisite { Id = 155, PipelineId = 20, Name = "Computer Skills" },
                new PipelinePrerequisite { Id = 156, PipelineId = 20, Name = "Jira/Project Management Tool" },
                new PipelinePrerequisite { Id = 157, PipelineId = 20, Name = "Test Rail/ALM/ Test Management Tool" },
                new PipelinePrerequisite { Id = 158, PipelineId = 20, Name = "Functional & Non - Functional Testing" },
                new PipelinePrerequisite { Id = 159, PipelineId = 20, Name = "API Testing" },
                new PipelinePrerequisite { Id = 160, PipelineId = 20, Name = "Regression Testing" },
                new PipelinePrerequisite { Id = 161, PipelineId = 20, Name = "Smoke Testing" },
                new PipelinePrerequisite { Id = 162, PipelineId = 20, Name = "System Integration Testing" },
                new PipelinePrerequisite { Id = 163, PipelineId = 20, Name = "E2E Testing" },
                new PipelinePrerequisite { Id = 164, PipelineId = 20, Name = "Knowledge of SQL" },
                new PipelinePrerequisite { Id = 165, PipelineId = 20, Name = "SDLC Concepts" },
                new PipelinePrerequisite { Id = 166, PipelineId = 21, Name = "Computer Skills" }
            };
        }
    }
}
