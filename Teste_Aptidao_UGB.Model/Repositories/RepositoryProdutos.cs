using Microsoft.EntityFrameworkCore;
using Teste_Aptidao_UGB.Model.Interfaces;
using Teste_Aptidao_UGB.Model.Models;

namespace Teste_Aptidao_UGB.Model.Repositories
{
    public class RepositoryProdutos : RepositoryBase<Produtos>, IProduto
    {
        public async Task<List<Produtos>> ListarProdutoPorDescricao(string termo)
        {
            return await _context.Produtos.Where(x => x.Prdescricao.Contains(termo)).ToListAsync();
        }
    }
}
