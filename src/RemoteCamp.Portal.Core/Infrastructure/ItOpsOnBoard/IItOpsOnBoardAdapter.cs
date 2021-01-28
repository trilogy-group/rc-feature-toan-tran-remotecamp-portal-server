using System.Threading.Tasks;

namespace RemoteCamp.Portal.Core.Infrastructure.ItOpsOnBoard
{
    public interface IItOpsOnBoardAdapter
    {
        /// <summary>
        ///     Returns <c>true</c> if it's sent successfully 
        /// </summary>
        Task<bool> SendAsync(ItOpsOnBoardRequest itOpsOnBoardRequest);
    }
}