using Teste_Aptidao_UGB.Models;

namespace Teste_Aptidao_UGB.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(EmailRequest emailRequest);
    }
}
