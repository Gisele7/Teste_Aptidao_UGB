using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Teste_Aptidao_UGB.Model.Models
{
    [ModelMetadataType(typeof(MD_Saida))]
    public partial class Saida
    {
        private class MD_Saida
        {
            [Display(Name = "Código")]
            public int Sacodigo { get; set; }

            [Display(Name = "Usuário")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public int? SacodUsuario { get; set; }

            [Display(Name = "Produto")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public long? SacodProduto { get; set; }

            [Display(Name = "Departamento")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public int? SacodDepartamento { get; set; }

            [Display(Name = "Data")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public DateTime? Sadata { get; set; }

            [Display(Name = "Quantidade")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public int? Saquantidade { get; set; }
        }
    }
}
