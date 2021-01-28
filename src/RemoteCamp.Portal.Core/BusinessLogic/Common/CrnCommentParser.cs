using System.Text.RegularExpressions;

namespace RemoteCamp.Portal.Core.BusinessLogic.Common
{
    static class CrnCommentParser
    {
        public static string GetSummary(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            var match = Regex.Match(text, @"^.*\*\*(.*)\*\*", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            return null;
        }

        public static string GetLink(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            var match = Regex.Match(text, @"\[More details\]\((.*)\)", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            return null;
        }
    }
}
