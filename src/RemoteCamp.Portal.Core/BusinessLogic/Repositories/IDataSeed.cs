using RemoteCamp.Portal.Core.Database.Model;
using System;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    public interface IDataSeed
    {
        User[] GetUsers();
        UserCalendarItem[] GetUserCalendarItems();
        UserCalendarItemAction[] GetUserCalendarItemActions();
        UserCheckInChatItem[] GetUserCheckInChatItem();
        Pipeline[] GetPipelines();
        PipelinePrerequisite[] GetPipelinePrerequisites();
    }
}