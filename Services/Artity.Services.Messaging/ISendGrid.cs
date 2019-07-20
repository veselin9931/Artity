using System.Threading.Tasks;

namespace Artity.Services.Messaging
{
    public interface ISendGrid
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
