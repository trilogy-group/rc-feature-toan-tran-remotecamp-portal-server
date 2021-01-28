using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlassian.Jira;

namespace RemoteCamp.Portal.Core.Infrastructure.Jira
{
    public static class CustomFieldValueCollectionExtensions
    {
        public static void SetValue(this CustomFieldValueCollection customFields, string fieldName, string value)
        {
            if (!customFields.Any(x => x.Name.Equals(fieldName, StringComparison.OrdinalIgnoreCase)))
            {
                customFields.Add(fieldName, value);
            }
            else
            {
                customFields[fieldName].Values = new[] { value };
            }
        }
    }
}
