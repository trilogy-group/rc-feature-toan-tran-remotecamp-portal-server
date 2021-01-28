using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteCamp.Portal.Core.Database.Model
{
    public interface ILogicalDeleteEntity
    {
        bool? IsDeleted { get; set; }
    }
}
