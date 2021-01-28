using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteCamp.Portal.Core.BusinessLogic.Email.Templates
{
    public partial class MissedWeeklyPlanWarningEmailTemplate
    {
        public string IcName { get; set; }

        public MissedWeeklyPlanWarningEmailTemplate(string name)
        {
            IcName = name;
        }
    }
}
