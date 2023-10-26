using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Aptidao_UGB.Model.Models
{
    [ModelMetadataType(typeof(MD_Servicos))]
    public partial class Servicos
    {
        private class MD_Servicos
        {
            [Display(Name = "Código")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public int Secodigo { get; set; }

            [Display(Name = "Nome")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public string Senome { get; set; }

            [Display(Name = "Descrição")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public string Sedescricao { get; set; }

            [Display(Name = "Fornecedor")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public int? SecodFornecedor { get; set; }

            [Display(Name = "Prazo de entrega")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public DateTime? SeprazoEntrega { get; set; }
        }

    }
}
