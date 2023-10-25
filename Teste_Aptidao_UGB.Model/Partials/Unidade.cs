using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Aptidao_UGB.Model.Models
{
    [ModelMetadataType(typeof(MD_Unidade))]
    public partial class Unidade
    {
        private class MD_Unidade
        {
            [Display(Name = "Código")]
            public int Uncodigo { get; set; }
            [Display(Name = "Código")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public string Undescricao { get; set; }
        }
    }

}
