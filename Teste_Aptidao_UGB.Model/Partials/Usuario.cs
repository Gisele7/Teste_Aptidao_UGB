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
    [ModelMetadataType(typeof(MD_Usuario))]
    public partial class Usuarios
    {
        private class MD_Usuario
        {
            [Display(Name ="Matrícula")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public int Usmatricula { get; set; }
            [Display(Name = "Nome")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public string Usnome { get; set; }
            [Display(Name = "Departamento")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public int? UscodDepartamento { get; set; }
        }
    }
}
