using Microsoft.EntityFrameworkCore;
using Teste_Aptidao_UGB.Model.Interfaces;
using Teste_Aptidao_UGB.Model.Models;

namespace Teste_Aptidao_UGB.Model.Repositories
{
    public class RepositoryFornecedor : RepositoryBase<Fornecedores>, IFornecedor
    {

        public async Task<List<Fornecedores>> ListarFornecedoresPorNome(string termo)
        {
            return await _context.Fornecedores.Where(x => x.Fonome.Contains(termo)).ToListAsync();
        }
    }
}
