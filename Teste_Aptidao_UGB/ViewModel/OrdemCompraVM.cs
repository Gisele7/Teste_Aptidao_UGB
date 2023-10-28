using Microsoft.EntityFrameworkCore;
using Teste_Aptidao_UGB.Model.Models;

namespace Teste_Aptidao_UGB.ViewModel
{
    public class OrdemCompraVM
    {
        public int Codigo { get; set; }
        public int? CodigoFornecedor { get; set; }
        public string Fornecedor { get; set; }
        public DateTime? Data { get; set; }
        public List<SolicitacaoVM> Solicitacoes { get; set; }

        public OrdemCompraVM()
        {
            List<SolicitacaoVM> listaSolicitacoes = new List<SolicitacaoVM>();
            listaSolicitacoes = SolicitacaoVM.ListSolicitacoesAsync();

            Solicitacoes = listaSolicitacoes;
        }

        public async static Task<OrdemCompraVM> SelecionaOrdemCompra(int codigoOrdemCompra)
        {
            var db = new SOLICITACAO_MATERIAISContext();
            List<SolicitacaoVM> listaSolicitacoes = new List<SolicitacaoVM>();
            listaSolicitacoes = await SolicitacaoVM.ListSolicitacoesPorOrdemCompraAsync(codigoOrdemCompra);
            var ordemCompra = await db.OrdemCompra.FirstOrDefaultAsync(x => x.Occodigo == codigoOrdemCompra);
            return new OrdemCompraVM()
            {
                Codigo = ordemCompra.Occodigo,
                CodigoFornecedor = ordemCompra.OccodFornecedor,
                Data = ordemCompra.Ocdata,
                Fornecedor = db.Fornecedores.FirstOrDefault(x => x.Focodigo == ordemCompra.OccodFornecedor).Fonome,
                Solicitacoes = listaSolicitacoes
            };
        }

        public async static Task<List<OrdemCompraVM>> ListOrdensCompras()
        {
            var db = new SOLICITACAO_MATERIAISContext();
            var ordensCompras = await db.OrdemCompra.ToListAsync();
            var retorno = new List<OrdemCompraVM>();

            foreach (var item in ordensCompras)
            {
                var ordemCompraVM = new OrdemCompraVM()
                {
                    Codigo = item.Occodigo,
                    CodigoFornecedor = item.OccodFornecedor,
                    Data = item.Ocdata,
                    Fornecedor = db.Fornecedores.FirstOrDefault(x => x.Focodigo == item.OccodFornecedor).Fonome,
                };
                retorno.Add(ordemCompraVM);
            }
            return retorno;
        }
    }
}

