using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Aptidao_UGB.Model.Models
{
    [ModelMetadataType(typeof(MD_Produtos))]
    public partial class Produtos
    {
        private class MD_Produtos
        {
            [Display(Name = "Código")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public long PrcodigoEan { get; set; }
            [Display(Name = "Descrição")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public string Prdescricao { get; set; }
            [Display(Name = "Preço Unitário")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public decimal? PrprecoUnitario { get; set; }
            [Display(Name = "Cota mínima")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public int? PrcotaMinimaEstoque { get; set; }
            [Display(Name = "Unidade")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public int? PrcodUnidade { get; set; }
        }

    }
}
