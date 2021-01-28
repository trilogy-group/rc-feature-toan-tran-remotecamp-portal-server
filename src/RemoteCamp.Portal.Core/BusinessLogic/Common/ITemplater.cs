using RemoteCamp.Portal.Core.BusinessLogic.Data;

namespace RemoteCamp.Portal.Core.BusinessLogic.Common
{
    public interface ITemplater
    {
        string Render(string text, Profile profile);
    }
}