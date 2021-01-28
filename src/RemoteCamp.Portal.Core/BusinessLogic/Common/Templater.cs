using System;
using RemoteCamp.Portal.Core.BusinessLogic.Data;

namespace RemoteCamp.Portal.Core.BusinessLogic.Common
{
    public class Templater : ITemplater
    {
        public const string IC_TMS_URL_PLACEHOLDER = "{{IcTmsDocumentUrl}}";
        public const string IC_DECK_URL_PLACEHOLDER = "{{IcDeckUrl}}";

        public string Render(string text, Profile profile)
        {
            if (text == null)
            {
                return null;
            }
            
            profile = profile ?? throw new ArgumentNullException(nameof(profile));
            
            return text
                .Replace(IC_TMS_URL_PLACEHOLDER, profile.TmsUrl)
                .Replace(IC_DECK_URL_PLACEHOLDER, profile.DeckUrl);
        }        
    }
}