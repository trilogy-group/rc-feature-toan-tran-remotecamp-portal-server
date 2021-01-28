using System;
using System.Collections.Generic;

namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class CompanyDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class LocationDetail
    {
        public string Country { get; set; }
        public string City { get; set; }
        public TimeZone TimeZone { get; set; }
    }

    public class UserAvatar
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }

    public class ManagerAvatar
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrintableName { get; set; }
        public string PhotoUrl { get; set; }
        public LocationDetail Location { get; set; }
        public IList<string> AvatarTypes { get; set; }
        public IList<UserAvatar> UserAvatars { get; set; }
        public CompanyDetail Company { get; set; }
        public bool FeedbackRequired { get; set; }
    }

    public class CrossoverCandidateDetail
    {
        public ManagerAvatar ManagerAvatar { get; set; }
        public string Headline { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string PhotoUrl { get; set; }
        public bool InfoShared { get; set; }
        public string CommunicationStatus { get; set; }
    }

}