using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using Shouldly;
using Xunit;

namespace RemoteCamp.Portal.Core.Test.BusinessLogic.Common
{
    public class TemplaterTest
    {
        [Fact]
        public void Render_TextIsSet_ReplacesPlaceholders()
        {
            // Arrange
            var templater = new Templater();
            var text = $"{Templater.IC_TMS_URL_PLACEHOLDER} {Templater.IC_DECK_URL_PLACEHOLDER}";
            var profile = new Profile
            {
                TmsUrl = "tmsUrl1",
                DeckUrl = "deckUrl1"
            };

            // Act
            var resultText = templater.Render(text, profile);

            // Assert
            resultText.ShouldBe($"{profile.TmsUrl} {profile.DeckUrl}", resultText);
        }
    }
}