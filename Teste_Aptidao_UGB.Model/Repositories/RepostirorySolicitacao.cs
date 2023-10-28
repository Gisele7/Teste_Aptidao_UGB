using Microsoft.EntityFrameworkCore;
using Teste_Aptidao_UGB.Model.Interfaces;
using Teste_Aptidao_UGB.Model.Models;

namespace Teste_Aptidao_UGB.Model.Repositories
{
    public class RepositorySolicitacao : RepositoryBase<Solicitacao>, ISolicitacao
    {
        public async Task<List<Solicitacao>> GetSolicitacao(int codigoSolicitacao)
        {
            return await _context.Solicitacao.Where(x => x.Socodigo == codigoSolicitacao).ToListAsync();
        }
    }
}
