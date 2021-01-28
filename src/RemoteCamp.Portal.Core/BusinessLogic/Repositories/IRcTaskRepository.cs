using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.Utils;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    public interface IRcTaskJiraRepository
    {
        Task<List<RcTask>> FindByAssigneeAsync(string assignee, RcTaskLoadOptions rcTaskLoadOptions = RcTaskLoadOptions.All);
        Task<List<RcTask>> FindFailedByAssigneeAndDatesAsync(string assignee, Range<DateTime> dateRange, RcTaskLoadOptions rcTaskLoadOptions = RcTaskLoadOptions.All);
        Task<IList<RcTask>> FindAllAsync(RcTaskLoadOptions rcTaskLoadOptions);
    }
    [Flags]
    public enum RcTaskLoadOptions
    {
        Key = 0x1,
        Summary = 0x2,
        Assignee = 0x4,
        Status = 0x8,
        FirstSubmissionDate = 0x10,
        Ftar = 0x20,
        Score = 0x40,
        Module = 0x60,
        Reviewer = 0x80,
        SubmissionUrl = 0x100,
        IssueLinks = 0x200,
        All = Key | Summary | Assignee | Status | FirstSubmissionDate | Ftar | Score | Module | Reviewer | SubmissionUrl | IssueLinks
    }
}