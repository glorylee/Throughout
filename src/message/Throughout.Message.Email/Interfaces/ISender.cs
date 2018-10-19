using System.Threading;
using System.Threading.Tasks;
using Throughout.Message.Email.Models;

namespace Throughout.Message.Email.Interfaces
{
    public interface ISender
    {
        SendResponse Send(IEmail email, CancellationToken? token = null);
        Task<SendResponse> SendAsync(IEmail email, CancellationToken? token = null);
    }
}
