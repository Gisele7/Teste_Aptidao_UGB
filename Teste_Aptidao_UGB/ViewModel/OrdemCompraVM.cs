using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Teste_Aptidao_UGB.Model.Models;

namespace Teste_Aptidao_UGB.ViewModel
{
    public class OrdemCompraVM
    {
        [Display(Name ="Código")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int Codigo { get; set; }
        [Display(Name = "Fornecedor")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int? CodigoFornecedor { get; set; }

        [Display(Name = "Email")]

        public string EmailFornecedor { get; set; }

        [Display(Name = "Fornecedor")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Fornecedor { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public DateTime? Data { get; set; }

        [Display(Name = "Solicitações")]
        public List<SolicitacaoVM> Solicitacoes { get; set; }

        public OrdemCompraVM()
        {
            List<SolicitacaoVM> listaSolicitacoes = new List<SolicitacaoVM>();
            listaSolicitacoes = SolicitacaoVM.ListSolicitacoesAsync();

            Solicitacoes = listaSolicitacoes;
        }
        /// <summary>
        /// Retorna uma Ordem de Compra específica
        /// </summary>
        /// <param name="codigoOrdemCompra">Código da Ordem de Compra</param>
        /// <returns>OrdemCompraVM</returns>
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
                Fornecedor = db.Fornecedores.FirstOrDefault(x => x.Focodigo == ordemCompra.OccodFornecedor)!.Fonome,
                EmailFornecedor = db.Fornecedores.FirstOrDefault(x => x.Focodigo == ordemCompra.OccodFornecedor)!.Foemail,
                Solicitacoes = listaSolicitacoes
            };
        }
        /// <summary>
        /// Rertorna todas as Ordens de Compra pela ViweModel
        /// </summary>
        /// <returns>TLista de Tasks de OrdemCompraVM</returns>
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
                    EmailFornecedor = db.Fornecedores.FirstOrDefault(x => x.Focodigo == item.OccodFornecedor)!.Foemail,
                    Fornecedor = db.Fornecedores.FirstOrDefault(x => x.Focodigo == item.OccodFornecedor)!.Fonome,
                };
                retorno.Add(ordemCompraVM);
            }
            return retorno;
        }
    }
}

