using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Teste_Aptidao_UGB.Model.Models;

namespace Teste_Aptidao_UGB.ViewModel
{
    public class ProdutoVM
    {
        [Display(Name = "Código")]
        public long CodigoProduto { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Preço Unitário")]
        public decimal? PrecoUnitario { get; set; }
        [Display(Name ="Cota mínima")]
        public int? CotaMinimaEstoque { get; set; }
        public int? CodigoUnidade { get; set; }
        public string Unidade { get; set; }

        public ProdutoVM()
        {

        }

        /// <summary>
        /// Método para retornar todos os produtos cadastrados
        /// </summary>
        /// <returns>Lista de Tasks de ProdutoVM</returns>
        public async static Task<List<ProdutoVM>> ListProdutosAsync()
        {
            var db = new SOLICITACAO_MATERIAISContext();
            return await (from produto in db.Produtos
                          join unidade in db.Unidade on produto.PrcodUnidade equals unidade.Uncodigo
                          select new ProdutoVM
                          {
                              CodigoProduto = produto.PrcodigoEan,
                              CodigoUnidade = produto.PrcodUnidade,
                              CotaMinimaEstoque = produto.PrcotaMinimaEstoque,
                              Descricao = produto.Prdescricao,
                              PrecoUnitario = produto.PrprecoUnitario,
                              Unidade = unidade.Undescricao
                          }).ToListAsync();
        }
    }
}
