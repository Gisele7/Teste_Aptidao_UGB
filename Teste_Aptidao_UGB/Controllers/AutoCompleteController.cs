using Microsoft.AspNetCore.Mvc;
using Teste_Aptidao_UGB.Model.Models;
using Teste_Aptidao_UGB.Model.Repositories;

namespace Teste_Aptidao_UGB.Controllers
{
    public class AutoCompleteController : Controller
    {
        public async Task<JsonResult> SearchProduto(string termo)
         {
            RepositoryProdutos _RepositoryProdutos = new RepositoryProdutos();
            List<Produtos> oLista = await _RepositoryProdutos.ListarProdutoPorCodigoOuDescricao(termo);
            return new JsonResult(oLista);
        }

        public async Task<JsonResult> SearchFornecedores(string termo)
        {
            RepositoryFornecedor _RepositoryFornecedor = new RepositoryFornecedor();
            List<Fornecedores> oLista = await _RepositoryFornecedor.ListarFornecedoresPorNome(termo);
            return new JsonResult(oLista);
        }
    }
}
