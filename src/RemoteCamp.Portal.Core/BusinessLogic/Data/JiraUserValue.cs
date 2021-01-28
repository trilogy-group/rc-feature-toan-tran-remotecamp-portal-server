using System;

namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class JiraUserValue : IEquatable<JiraUserValue>
    {
        public string AccountId { get; set; }
        public string DisplayName { get; set; }
        
        public string EmailAddress { get; set; }

        public override string ToString()
        {
            return $"AccountId: {AccountId}, DisplayName={DisplayName}, emailAddress={EmailAddress}";
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public bool Equals(JiraUserValue other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return AccountId == other.AccountId && DisplayName == other.DisplayName && EmailAddress == other.EmailAddress;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (AccountId != null ? AccountId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (DisplayName != null ? DisplayName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (EmailAddress != null ? EmailAddress.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}