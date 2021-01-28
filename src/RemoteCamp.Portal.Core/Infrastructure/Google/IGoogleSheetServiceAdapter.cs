using System.Collections.Generic;
using System.Threading.Tasks;

namespace RemoteCamp.Portal.Core.Infrastructure.Google
{
    public interface IGoogleSheetServiceAdapter
    {
        void Initialize();
        IList<IList<object>> GetValues(string spreadsheetId, string range);

        Task<IList<IList<object>>> GetValuesAsync(string spreadsheetId, string range);
    }
}