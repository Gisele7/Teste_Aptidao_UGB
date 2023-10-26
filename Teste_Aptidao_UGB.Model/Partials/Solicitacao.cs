using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

            public long? SocodProduto { get; set; }

            public int? Soquantidade { get; set; }

            public int? SocodDepartamento { get; set; }

            public int? SocodUsuario { get; set; }

            public DateTime? Sodata { get; set; }

            public int? SocodServico { get; set; }

            public int? SocodFornecedor { get; set; }

            public string Soobservacao { get; set; }

            public bool? Soconcluida { get; set; }
        }

    }
}
