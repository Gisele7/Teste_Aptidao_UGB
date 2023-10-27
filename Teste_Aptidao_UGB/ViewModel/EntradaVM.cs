using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Teste_Aptidao_UGB.Model.Models;

namespace Teste_Aptidao_UGB.ViewModel
{
    public class EntradaVM
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int Codigo { get; set; }

        [Display(Name = "Nota Fiscal")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string NotaFiscal { get; set; }

        [Display(Name = "Data")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public DateTime? Data { get; set; }

        [Display(Name = "Depósito")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int? CodigoDeposito { get; set; }

        [Display(Name = "Depósito")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Deposito { get; set; }

        [Display(Name = "Fornecedor")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int? CodigoFornecedor { get; set; }

        [Display(Name = "Fornecedor")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Fornecedor { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int? Quantidade { get; set; }

        [Display(Name = "Produto")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public long? CodigoProduto { get; set; }

        [Display(Name = "Produto")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Produto { get; set; }

        /// <summary>
        /// Método para retornar todos as entradas cadastradas
        /// </summary>
        /// <returns></returns>
        public async static Task<List<EntradaVM>> ListEntradasAsync()
        {
            var db = new SOLICITACAO_MATERIAISContext();
            var retorno = new List<EntradaVM>();

            var entradas = db.Entrada.ToList();

            foreach (var item in entradas)
            {
                EntradaVM entradaVM = new EntradaVM()
                {
                    CodigoDeposito = item.EtcodDeposito,
                    CodigoFornecedor = item.EtcodFornecedor,
                    CodigoProduto = item.EtcodProduto,
                    Data = item.Etdata,
                    Deposito = db.Depositos.FirstOrDefault(x => x.Decodigo == item.EtcodDeposito).Dedescricao,
                    Fornecedor = db.Fornecedores.FirstOrDefault(x => x.Focodigo == item.EtcodFornecedor).Fonome,
                    Produto = db.Produtos.FirstOrDefault(x => x.PrcodigoEan == item.EtcodProduto).Prdescricao,
                    NotaFiscal = item.EtnotaFiscal,
                    Quantidade = item.Etquantidade

                };

                retorno.Add(entradaVM);
            }
            return  retorno;
        }
    }
}
