﻿using Microsoft.EntityFrameworkCore;
using Teste_Aptidao_UGB.Model.Interfaces;
using Teste_Aptidao_UGB.Model.Models;

namespace Teste_Aptidao_UGB.Model.Repositories
{
    public class RepositoryOrdemCompra : RepositoryBase<OrdemCompra>, IOrdemCompra
    {
        public async Task AlterarAsync(OrdemCompra ordemCompra, List<OrdemCompraSolicitacao> ordemCompraSolicitacoes)
        {
            _context.Entry(ordemCompra).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var listaOrdemCompraSolicitacaoExistentes = await _context.OrdemCompraSolicitacao.Where(x => x.OscodOrdemCompra == ordemCompra.Occodigo).ToListAsync();
            _context.RemoveRange(listaOrdemCompraSolicitacaoExistentes);
            foreach (var item in ordemCompraSolicitacoes)
            {
                item.OscodOrdemCompra = ordemCompra.Occodigo;
            }
            _context.AddRangeAsync(ordemCompraSolicitacoes);
            await _context.SaveChangesAsync();

            foreach (var item in ordemCompraSolicitacoes)
            {
                var solicitacao =await _context.Solicitacao.FindAsync(item.OscodSolicitacao);
                solicitacao.Soconcluida = true;
                _context.Entry(solicitacao).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
         }
    }
}
