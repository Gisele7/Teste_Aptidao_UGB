using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Teste_Aptidao_UGB.Model.Models
{
    [ModelMetadataType(typeof(MD_Entrada))]
    public partial class Entrada
    {
        private class MD_Entrada
        {
            [Display(Name = "Código")]
            public int Etcodigo { get; set; }

            [Display(Name = "Nota Fiscal")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public string EtnotaFiscal { get; set; }

            [Display(Name = "Data")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public DateTime? Etdata { get; set; }

            [Display(Name = "Depósito")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public int? EtcodDeposito { get; set; }

            [Display(Name = "Fornecedor")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public int? EtcodFornecedor { get; set; }

            [Display(Name = "Quantidade")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public int? Etquantidade { get; set; }

            [Display(Name = "Produto")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public long? EtcodProduto { get; set; }
        }
    }
}
