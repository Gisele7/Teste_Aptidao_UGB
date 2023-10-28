using Microsoft.EntityFrameworkCore;
using Teste_Aptidao_UGB.Model.Interfaces;
using Teste_Aptidao_UGB.Model.Models;

namespace Teste_Aptidao_UGB.Model.Repositories
{
    public class RepositoryVWEstoque : RepositoryBase<VwEstoque>, IVWEstoque
    {

        public async Task<VwEstoque> SelecionaEstoqueProduto(long codigoProduto)
        {
            return await _context.VwEstoque.FirstOrDefaultAsync(x => x.EtcodProduto == codigoProduto);
        }
    }
}
