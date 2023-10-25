using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Aptidao_UGB.Helpers;

namespace Teste_Aptidao_UGB.Model.Models
{
    [ModelMetadataType(typeof(MD_Departamento))]
    public partial class Departamento
    {
        private class MD_Departamento
        {

            [Display(Name ="Código")]
            public int Decodigo { get; set; }

            [Display(Name = "Descrição")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public string Dedescricao { get; set; }
        }
    }
}
