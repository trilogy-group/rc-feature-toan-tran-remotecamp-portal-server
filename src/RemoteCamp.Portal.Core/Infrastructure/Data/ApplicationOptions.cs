using System;

namespace RemoteCamp.Portal.Core.Infrastructure.Data
{
    public class ApplicationOptions : ICloneable
    {
        public string XoJiraUserName { get; set; }
        public string XoJiraPassword { get; set; }
        public string GoogleApiEmail { get; set; }
        public string GoogleApiPrivateKey { get; set; }
        public bool IsProductionMode { get; set; }
        public string GithubAccessToken { get; set; }
        public string CrossoverUserName { get; set; }
        public string CrossoverPassword { get; set; }
        public string ItOpsOnBoardRequestUrl { get; set; }
        public string DbConnectionString { get; set; }
        public string TicketBackupNoSqlDbConnectionString { get; set; }
        public string TicketBackupNoSqlDatabaseName { get; set; }
        public string SmtpUserName { get; set; }
        public string SmtpPassword { get; set; }
        public SmtpSetting SmtpSettings { get; set; } = new SmtpSetting();

        public JiraSetting JiraSettings { get; set; } = new JiraSetting();

        public class JiraSetting
        {
            public string AssignmentsProject { get; set; }
            public string IcCardProject { get; set; }
            public string StudentJiraGroup { get; set; }
            public string QeJiraGroup { get; set; }
            public string ManagementJiraGroup { get; set; }
            public string WatchersJiraGroup { get; set; }
        }

        public class SmtpSetting
        {
            public string Host { get; set; }
            public int Port { get; set; }
            public string SenderEmail { get; set; }
            public bool UseSSL { get; set; }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
