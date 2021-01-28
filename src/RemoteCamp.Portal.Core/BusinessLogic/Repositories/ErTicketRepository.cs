using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atlassian.Jira;
using Newtonsoft.Json.Linq;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Extensions;
using RemoteCamp.Portal.Core.Infrastructure.Data;
using RemoteCamp.Portal.Core.Infrastructure.Jira;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    public class ErTicketRepository : IErTicketRepository
    {
        private static readonly string[] GradeBookJiraFields =
        {
            JiraConstants.Field.Key,
            JiraConstants.Field.Status,
            JiraConstants.Field.Assignee,
            JiraConstants.Field.Summary,
            JiraConstants.Field.StartDateFieldKey,
            JiraConstants.Field.RcPipelineNameFieldKey,
            JiraConstants.Field.RcPipelineNameFieldKey,
            JiraConstants.Field.RcJiraIdFieldKey,
            JiraConstants.Field.RcXoIdFieldKey,
            JiraConstants.Field.NameFieldKey,
            JiraConstants.Field.HiringManagerFieldKey,
            JiraConstants.Field.RcDeckFieldKey,
            JiraConstants.Field.RcTMSFieldKey,
            JiraConstants.Field.RcXoLoginEmailKey,
            JiraConstants.Field.ItOpsTicketFieldKey,
            JiraConstants.Field.AdAccountFieldKey,
            JiraConstants.Field.CompanyEmailFieldKey,
            JiraConstants.Field.Application360LinkFieldKey,
            JiraConstants.Field.GitHubIdFieldKey,
            JiraConstants.Field.IcRemoteUFieldKey,
            JiraConstants.Field.StartEruFieldKey,
            JiraConstants.Field.RemoteUModuleKey
        };

        private readonly IJiraClientAdapter _jiraClientAdapter;
        private readonly ApplicationOptions _applicationOptions;

        public ErTicketRepository(IJiraClientAdapter jiraClientAdapter, ApplicationOptions applicationOptions)
        {
            _jiraClientAdapter = jiraClientAdapter;
            _applicationOptions = applicationOptions;
        }

        public async Task<ErTicket> GetByCompanyEmailAsync(string email, ErTicketLoadOptions loadOptions = ErTicketLoadOptions.None)
        {
            _jiraClientAdapter.Initialize();
            var jql = $"Project = '{_applicationOptions.JiraSettings.IcCardProject}' AND '{JiraConstants.Field.CompanyEmailFieldName}' ~ '{email}'";
            return await GetErTicket(loadOptions, jql);
        }

        public async Task<ErTicket> GetByXoEmailAsync(string email, ErTicketLoadOptions loadOptions = ErTicketLoadOptions.None)
        {
            _jiraClientAdapter.Initialize();
            var jql = $"Project = '{_applicationOptions.JiraSettings.IcCardProject}' AND '{JiraConstants.Field.XoEmailEmailFieldName}' ~ '{email}'";
            return await GetErTicket(loadOptions, jql);
        }

        private async Task ApplyLoadOptionsAsync(ErTicketLoadOptions loadOptions, ErTicket erTicket)
        {
            if (loadOptions != ErTicketLoadOptions.None)
            {
                var attachments = await _jiraClientAdapter.Issues.GetAttachmentsAsync(erTicket.JiraKey);
                if (attachments.Any())
                {
                    foreach (var attachment in attachments)
                    {
                        erTicket.Attachment.Add(attachment);
                    }
                }
            }
        }

        public async Task<IList<ErTicket>> GetAllAsync()
        {
            _jiraClientAdapter.Initialize();
            var jql = $"Project = '{_applicationOptions.JiraSettings.IcCardProject}' AND status='RC Active' AND resolution=Unresolved ORDER BY summary ASC";
            var issues = await _jiraClientAdapter.LoadAllIssuesAsync(
                jql,
                GradeBookJiraFields,
                CreateRcTaskForGradeBookFromIssueJTokenCallback());
            return issues.ToList();
        }

        public async Task UpdateAsync(ErTicketUpdateRequest erTicketUpdateRequest)
        {
            _jiraClientAdapter.Initialize();

            var issue = await _jiraClientAdapter.Issues.GetIssueAsync(erTicketUpdateRequest.JiraKey);
            if (issue == null)
            {
                return;
            }

            if (erTicketUpdateRequest.UpdateDeckUrl)
            {
                issue.CustomFields.SetValue(JiraConstants.Field.RcDeckFieldName, erTicketUpdateRequest.DeckUrl);
            }

            if (erTicketUpdateRequest.UpdatePipeline)
            {
                issue.CustomFields.SetValue(JiraConstants.Field.RcPipelineNameFieldName, erTicketUpdateRequest.Pipeline);
            }

            if (erTicketUpdateRequest.UpdateVideoOfPurpose)
            {
                issue.CustomFields.SetValue(JiraConstants.Field.VideoOfPurposeFieldName, erTicketUpdateRequest.VideoOfPurpose);
            }

            if (erTicketUpdateRequest.UpdateName)
            {
                issue.CustomFields.SetValue(JiraConstants.Field.NameFieldName, erTicketUpdateRequest.Name);
            }

            if (erTicketUpdateRequest.UpdateStartDate)
            {
                issue.CustomFields.SetValue(JiraConstants.Field.StartDateFieldName, erTicketUpdateRequest.StartDate?.ToString("o"));
            }

            if (erTicketUpdateRequest.UpdateTmsUrl)
            {
                issue.CustomFields.SetValue(JiraConstants.Field.RcTMSFieldName, erTicketUpdateRequest.TmsUrl);
            }

            if (erTicketUpdateRequest.UpdateItOpsTicket)
            {
                issue.CustomFields.SetValue(JiraConstants.Field.ItOpsTicketFieldName, erTicketUpdateRequest.ItOpsTicket);
            }

            if (erTicketUpdateRequest.UpdateGitHubId)
            {
                issue.CustomFields.SetValue(JiraConstants.Field.GitHubIdFieldName, erTicketUpdateRequest.GitHubId);
            }

            if (erTicketUpdateRequest.LabelsForAdding.Any())
            {
                issue.Labels.AddRange(erTicketUpdateRequest.LabelsForAdding);
            }

            if (erTicketUpdateRequest.UploadAttachmentInfo.Any())
            {
                await issue.AddAttachmentAsync(erTicketUpdateRequest.UploadAttachmentInfo.ToArray());
            }

            await _jiraClientAdapter.Issues.UpdateIssueAsync(issue, new IssueUpdateOptions
            {
                SuppressEmailNotification = true
            });

            if (!string.IsNullOrWhiteSpace(erTicketUpdateRequest.TransitionName))
            {
                await issue.WorkflowTransitionAsync(erTicketUpdateRequest.TransitionName, new WorkflowTransitionUpdates());
            }
        }

        private DateTime? GetDateTimeOrNull(CustomFieldValue customFieldValue)
        {
            return DateTime.TryParse(customFieldValue?.Values[0], out var result) ? result : (DateTime?)null;
        }

        private int? GetIntOrNull(CustomFieldValue customFieldValue)
        {
            return int.TryParse(customFieldValue?.Values[0], out var result) ? result : (int?)null;
        }

        private static Func<JToken, ErTicket> CreateRcTaskForGradeBookFromIssueJTokenCallback()
        {
            return x => new ErTicket
            {
                JiraKey = x[JiraConstants.Field.Key]?.ToString(),
                Status = x[JiraConstants.Json.Fields][JiraConstants.Field.Status][JiraConstants.Field.Name]?.ToString(),
                Assignee = x[JiraConstants.Json.Fields][JiraConstants.Field.Assignee].ToJiraUserValue(),
                Summary = x[JiraConstants.Json.Fields][JiraConstants.Field.Summary]?.ToString(),
                StartDate = DateTime.TryParse(x[JiraConstants.Json.Fields][JiraConstants.Field.StartDateFieldKey]?.ToString(), out var startDate)
                    ? startDate
                    : (DateTime?)null,
                Pipeline = x[JiraConstants.Json.Fields][JiraConstants.Field.RcPipelineNameFieldKey].SelectToken(JiraConstants.Field.Value)?.ToString(),
                PipelineJiraId = int.TryParse(
                    x[JiraConstants.Json.Fields][JiraConstants.Field.RcPipelineNameFieldKey]
                        .SelectToken(
                            JiraConstants.Field.Id)?.ToString(),
                            out var pipeLineJiraId)
                        ? pipeLineJiraId
                        : (int?)null,
                RcJiraId = x[JiraConstants.Json.Fields][JiraConstants.Field.RcJiraIdFieldKey]?.ToString(),
                RcXoId = int.TryParse(x[JiraConstants.Json.Fields][JiraConstants.Field.RcXoIdFieldKey]?.ToString(), out var rcXoId) ? rcXoId : (int?)null,
                Name = x[JiraConstants.Json.Fields][JiraConstants.Field.NameFieldKey]?.ToString(),
                HiringManager = x[JiraConstants.Json.Fields][JiraConstants.Field.HiringManagerFieldKey]?.ToString(),
                DeckUrl = x[JiraConstants.Json.Fields][JiraConstants.Field.RcDeckFieldKey]?.ToString(),
                TmsUrl = x[JiraConstants.Json.Fields][JiraConstants.Field.RcTMSFieldKey]?.ToString(),
                XoLoginEmail = x[JiraConstants.Json.Fields][JiraConstants.Field.RcXoLoginEmailKey]?.ToString(),
                ItOpsTicket = x[JiraConstants.Json.Fields][JiraConstants.Field.ItOpsTicketFieldKey].SelectToken(JiraConstants.Field.Value)?.ToString(),
                AdAccount = x[JiraConstants.Json.Fields][JiraConstants.Field.AdAccountFieldKey]?.ToString(),
                CompanyEmail = x[JiraConstants.Json.Fields][JiraConstants.Field.CompanyEmailFieldKey]?.ToString(),
                Application360Link = x[JiraConstants.Json.Fields][JiraConstants.Field.Application360LinkFieldKey]?.ToString(),
                GitHubId = x[JiraConstants.Json.Fields][JiraConstants.Field.GitHubIdFieldKey]?.ToString(),
                IcRemoteU = x[JiraConstants.Json.Fields][JiraConstants.Field.IcRemoteUFieldKey].SelectToken(JiraConstants.Field.Value)?.ToString(),
                StartEru = x[JiraConstants.Json.Fields][JiraConstants.Field.StartEruFieldKey].SelectToken(JiraConstants.Field.Value)?.ToString(),
                RemoteUModuleId = int.TryParse(
                    x[JiraConstants.Json.Fields][JiraConstants.Field.RemoteUModuleKey]
                        .SelectToken(
                            JiraConstants.Field.Id)?.ToString(),
                            out var remoteUModuleId)
                        ? remoteUModuleId
                        : (int?)null
            };
        }

        private async Task<ErTicket> GetErTicket(ErTicketLoadOptions loadOptions, string jql)
        {
            var issues = await _jiraClientAdapter.LoadAllIssuesAsync(
                jql,
                GradeBookJiraFields,
                CreateRcTaskForGradeBookFromIssueJTokenCallback());

            var erTicket = issues.FirstOrDefault();
            if (erTicket == null)
            {
                return null;
            }

            await ApplyLoadOptionsAsync(loadOptions, erTicket);
            return erTicket;
        }
    }
}