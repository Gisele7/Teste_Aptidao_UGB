using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Teste_Aptidao_UGB.Model.Models
{
    [ModelMetadataType(typeof(MD_Solicitacao))]
    public partial class Solicitacao
    {
        private class MD_Solicitacao
        {

            public int Socodigo { get; set; }
            [Display(Name ="Produto")]
        
            public long? SocodProduto { get; set; }
            [Display(Name = "Quantidade")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public int? Soquantidade { get; set; }
            [Display(Name = "Departamento")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public int? SocodDepartamento { get; set; }
            [Display(Name = "Usuário")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public int? SocodUsuario { get; set; }
            [Display(Name = "Data")]
            [Required(ErrorMessage = "Este campo é obrigatório.")]
            public DateTime? Sodata { get; set; }
          
            [Display(Name = "Serviço")]
            public int? SocodServico { get; set; }       
            [Display(Name = "Fornecedor")]
            public int? SocodFornecedor { get; set; }
            [Display(Name = "Observação")]
         
            public string Soobservacao { get; set; }

            public bool? Soconcluida { get; set; }
        }

    }
}
