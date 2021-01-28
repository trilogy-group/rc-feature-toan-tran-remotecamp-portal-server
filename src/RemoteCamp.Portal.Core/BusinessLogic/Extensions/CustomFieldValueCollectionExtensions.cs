using System.Linq;
using Atlassian.Jira;

namespace RemoteCamp.Portal.Core.BusinessLogic.Extensions
{
    public static class CustomFieldValueCollectionExtensions
    {
        /// <summary>
        /// Use the method instead of build-in index property,
        /// as the index property can throw an exception even an issue has a field value
        /// but project configuration forbids something related to the field 
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="fieldKey"></param>
        /// <returns></returns>
        public static CustomFieldValue GetById(this CustomFieldValueCollection collection, string fieldKey)
        {
            return collection.FirstOrDefault(x => x.Id == fieldKey);
        }
    }
}