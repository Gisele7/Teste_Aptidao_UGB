using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste_Aptidao_UGB.Model.Repositories;
using Teste_Aptidao_UGB.ViewModel;

namespace Teste_Aptidao_UGB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaSolicitacaoController : ControllerBase
    {
        RepositorySolicitacao _RepositorySolicitacao = new RepositorySolicitacao();
        [HttpGet]
        public async Task<IActionResult> GetSolicitacao(int codigoSolicitacao)
        {
            try
            {
                return Ok(await SolicitacaoVM.SelecionaSolicitacaoAsync(codigoSolicitacao));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
