using Microsoft.EntityFrameworkCore;
using Teste_Aptidao_UGB.Model.Models;

namespace Teste_Aptidao_UGB.ViewModel
{
    public class SolicitacaoVM
    {
        public int Codigo { get; set; }
        public long? CodigoProduto { get; set; }
        public string Produto { get; set; }
        public int? Quantidade { get; set; }
        public int? CodDepartamento { get; set; }
        public string Departamento { get; set; }
        public int MatriculaUsuario { get; set; }
        public string Usuario { get; set; }
        public DateTime? Data { get; set; }
        public int? CodigoServico { get; set; }
        public string Servico { get; set; }
        public int? CodFornecedor { get; set; }
        public string Fornecedor { get; set; }
        public string Observacao { get; set; }
        public bool? Concluida { get; set; }


        /// <summary>
        /// Método para retornar todos as solicitações cadastradas
        /// </summary>
        /// <returns></returns>
        public static List<SolicitacaoVM> ListSolicitacoesAsync()
        {
            var db = new SOLICITACAO_MATERIAISContext();
            var retorno = new List<SolicitacaoVM>();

            var solicitacoes = db.Solicitacao.ToList();

            foreach (var item in solicitacoes)
            {
                SolicitacaoVM solicitacaoVM = new SolicitacaoVM()
                {
                    CodDepartamento = item.SocodDepartamento,
                    CodFornecedor = item.SocodFornecedor,
                    CodigoProduto = item.SocodProduto,
                    CodigoServico = item.SocodServico,
                    Concluida = item.Soconcluida,
                    Data = item.Sodata,
                    Departamento = db.Departamento.FirstOrDefault(x => x.Decodigo == item.SocodDepartamento).Dedescricao,
                    Fornecedor = item.SocodFornecedor == null ? "" : db.Fornecedores.FirstOrDefault(x => x.Focodigo == item.SocodFornecedor).Fonome,
                    MatriculaUsuario = (int)item.SocodUsuario,
                    Observacao = item.Soobservacao,
                    Produto = item.SocodProduto == null ? "" : db.Produtos.FirstOrDefault(x => x.PrcodigoEan == item.SocodProduto).Prdescricao,
                    Quantidade = item.Soquantidade,
                    Servico = item.SocodServico == null ? "" : db.Servicos.FirstOrDefault(x => x.Secodigo == item.SocodServico).Sedescricao,
                    Usuario = db.Usuarios.FirstOrDefault(x => x.Usmatricula == item.SocodUsuario).Usnome,
                };

                retorno.Add(solicitacaoVM);
            }
            return retorno;
        }
    }
}
