using System;
using System.Text.RegularExpressions;

namespace RemoteCamp.Portal.Core.Infrastructure.GitHub
{
    public class GitHubPullRequestReference : IEquatable<GitHubPullRequestReference>
    {
        public string Owner { get; set; }
        public string Repository { get; set; }
        public int Number { get; set; }

        public static bool TryParse(string pullRequestUrl, out GitHubPullRequestReference result)
        {
            if (string.IsNullOrWhiteSpace(pullRequestUrl))
            {
                result = null;
                return false;
            }

            var match = Regex.Match(pullRequestUrl, @"https?:\/\/github\.com\/([a-zA-Z0-9\-_]+)\/([a-zA-Z0-9\-_]+)\/pull\/(\d+).*");
            if (!match.Success)
            {
                result = null;
                return false;
            }

            result = new GitHubPullRequestReference()
            {
                Owner = match.Groups[1].Value,
                Repository = match.Groups[2].Value,
                Number = int.TryParse(match.Groups[3].Value, out var number)
                    ? number
                    : 0
            };

            return true;
        }

        public bool Equals(GitHubPullRequestReference other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(Owner, other.Owner) && string.Equals(Repository, other.Repository) && Number == other.Number;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((GitHubPullRequestReference)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Owner != null
                    ? Owner.GetHashCode()
                    : 0);

                hashCode = (hashCode * 397) ^
                           (Repository != null
                               ? Repository.GetHashCode()
                               : 0);

                hashCode = (hashCode * 397) ^ Number;
                return hashCode;
            }
        }
    }
}
