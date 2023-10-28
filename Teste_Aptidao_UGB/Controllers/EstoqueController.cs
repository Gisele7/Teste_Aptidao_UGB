using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste_Aptidao_UGB.Model.Repositories;

namespace Teste_Aptidao_UGB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        RepositoryVWEstoque _RepositoryVWEstoque = new RepositoryVWEstoque();
        [HttpGet]
        public async Task<IActionResult> GetEstoque(long codigoProduto)
        {
            try
            {
                return Ok(await _RepositoryVWEstoque.SelecionaEstoqueProduto(codigoProduto));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
