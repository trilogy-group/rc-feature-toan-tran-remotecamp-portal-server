using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class CrossoverTrackerActivity
    {
        public Grouping Grouping { get; set; }
        public AssignmentHistory AssignmentHistory { get; set; }
        public Assignment Assignment { get; set; }
        public DayActivitiesTime DayActivitiesTime { get; set; }
    }

    public class Grouping
    {
        public int PeriodLong { get; set; }
        public int TotalTrackedTime { get; set; }
        public int AlignmentScore { get; set; }
        public List<object> AdvancedGroups { get; set; }
        public int FocusScore { get; set; }
        public int IntensityScore { get; set; }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool @Internal { get; set; }
        public double XoPercentage { get; set; }
        public double CurrentBalance { get; set; }
    }
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Company Company { get; set; }
        public List<object> MetricsSetups { get; set; }
        public bool Deleted { get; set; }
    }

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Allowed { get; set; }
    }

    public class TimeZone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StandardOffset { get; set; }
        public string HourlyOffset { get; set; }
        public int Offset { get; set; }
    }

    public class Location
    {
        public Country Country { get; set; }
        public TimeZone TimeZone { get; set; }
        public string City { get; set; }
    }

    public class AssignmentAvatar
    {
        public int Id { get; set; }
        public string AvatarUrl { get; set; }
    }

    public class AssignmentHistory
    {
        public int Id { get; set; }
        public DateTime EffectiveDateBegin { get; set; }
        public string AssignmentHistoryStatus { get; set; }
        public Team Team { get; set; }
        public Manager manager { get; set; }
        public double Salary { get; set; }
        public string SalaryType { get; set; }
        public string SalaryUnit { get; set; }
        public string PaymentPlatform { get; set; }
        public int WeeklyLimit { get; set; }
        public string Status { get; set; }
        public string CompanyEmail { get; set; }
        public DateTime? EffectiveDateEnd { get; set; }
        public AssignmentAvatar AssignmentAvatar { get; set; }
    }

    public class Candidate
    {
        public string Type { get; set; }
        public int Id { get; set; }
        public double AverageRatings { get; set; }
        public double WorkedHours { get; set; }
        public double BilledHours { get; set; }
        public List<object> Languages { get; set; }
        public List<object> Certifications { get; set; }
        public List<object> Educations { get; set; }
        public List<object> Employments { get; set; }
        public List<object> Connections { get; set; }
        public List<object> Skills { get; set; }
        public string SkypeId { get; set; }
        public bool AgreementAccepted { get; set; }
        public bool Personal { get; set; }
        public string PrintableName { get; set; }
        public bool candidate { get; set; }
        public string Email { get; set; }
        public Location Location { get; set; }
        public bool Manager { get; set; }
        public string PhotoUrl { get; set; }
        public int UserId { get; set; }
        public bool CompanyAdmin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> AvatarTypes { get; set; }
        public List<object> AppFeatures { get; set; }
        public List<object> UserAvatars { get; set; }
        public List<object> BusySlots { get; set; }
    }

    public class Application
    {
        public int Id { get; set; }
        public Candidate Candidate { get; set; }
        public string Status { get; set; }
        public List<object> Files { get; set; }
        public List<object> TestScores { get; set; }
        public double Score { get; set; }
        public int YearsOfExperience { get; set; }
        public string HighestEducationLevel { get; set; }
        public bool InterestInHiringEvent { get; set; }
        public bool TermsAccepted { get; set; }
        public List<object> Variants { get; set; }
    }

    public class MarketplaceMember
    {
        public int Id { get; set; }
        public Application Application { get; set; }
        public DateTime ActiveOn { get; set; }
        public string Status { get; set; }
    }

    public class Selection
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public MarketplaceMember MarketplaceMember { get; set; }
    }

    public class Manager
    {
        public string Type { get; set; }
        public int Id { get; set; }
        public List<object> RejectedCandidates { get; set; }
        public List<object> AvailableSlots { get; set; }
        public bool ManualTimeNotificationsEnabled { get; set; }
        public string Email { get; set; }
        public bool manager { get; set; }
        public bool Personal { get; set; }
        public string PrintableName { get; set; }
        public int UserId { get; set; }
        public bool CompanyAdmin { get; set; }
        public bool Candidate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<object> AvatarTypes { get; set; }
        public List<object> AppFeatures { get; set; }
        public List<object> UserAvatars { get; set; }
        public List<object> BusySlots { get; set; }
        public Location Location { get; set; }
    }

    public class CurrentAssignmentHistory
    {
        public int Id { get; set; }
        public Team Team { get; set; }
        public Manager Manager { get; set; }
        public double Salary { get; set; }
        public string SalaryType { get; set; }
        public string SalaryUnit { get; set; }
        public string PaymentPlatform { get; set; }
        public int WeeklyLimit { get; set; }
        public string Status { get; set; }
        public string CompanyEmail { get; set; }
    }

    public class Assignment
    {
        public int Id { get; set; }
        public Selection Selection { get; set; }
        public List<AssignmentHistory> AssignmentHistories { get; set; }
        public CurrentAssignmentHistory CurrentAssignmentHistory { get; set; }
        public bool TrackerRequired { get; set; }
        public string JobTitle { get; set; }
        public int OvertimeWarningHours { get; set; }
        public Candidate Candidate { get; set; }
        public Team Team { get; set; }
        public string PaymentPlatform { get; set; }
        public double Salary { get; set; }
        public int WeeklyLimit { get; set; }
        public string SalaryType { get; set; }
        public string SalaryUnit { get; set; }
        public string Status { get; set; }
        public Manager Manager { get; set; }
    }

    public class ContractorTimeSlot
    {
        public int Index { get; set; }
        public int AppId { get; set; }
        public string ActName { get; set; }
        public string Color { get; set; }
        public string AppName { get; set; }
    }

    public class ManagerTimeSlot
    {
        public int Index { get; set; }
        public int AppId { get; set; }
        public string ActName { get; set; }
        public string Color { get; set; }
        public string AppName { get; set; }
    }

    public class DayActivitiesTime
    {
        public List<ContractorTimeSlot> ContractorTimeSlots { get; set; }
        public List<ManagerTimeSlot> ManagerTimeSlots { get; set; }
    }
}
