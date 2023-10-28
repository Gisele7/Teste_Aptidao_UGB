using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
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

        public async Task AlterarAsync(Fornecedores fornecedor, Endereco endereco)
        {
            _context.Entry(fornecedor).State = EntityState.Modified;
            var enderecoCadastradro = _context.Endereco.FirstOrDefault(x => x.EncodFornecedor == fornecedor.Focodigo);
            _context.Remove(enderecoCadastradro!);
            await _context.SaveChangesAsync();
            endereco.EncodFornecedor = fornecedor.Focodigo;
            _context.Entry(endereco).State = EntityState.Added;
            await _context.SaveChangesAsync();  
           

        }
        
    }
}
