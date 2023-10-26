using Microsoft.EntityFrameworkCore;
using Teste_Aptidao_UGB.Model.Models;

namespace Teste_Aptidao_UGB.ViewModel
{
    public class ServicoVM
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public int CodigoFornecedor { get; set; }
        public string Fornecedor { get; set; }
        public DateTime? PrazoEntrega{ get; set; }

        /// <summary>
        /// Método para retornar todos os serviços cadastrados
        /// </summary>
        /// <returns></returns>
        public async static Task<List<ServicoVM>> ListServicosAsync()
        {
            var db = new SOLICITACAO_MATERIAISContext();
            return await (from servico in db.Servicos
                          join fornecedor in db.Fornecedores on servico.SecodFornecedor equals fornecedor.Focodigo
                          select new ServicoVM
                          {
                              CodigoFornecedor = fornecedor.Focodigo,
                              Descricao = servico.Sedescricao,
                              Fornecedor = fornecedor.Fonome,
                              PrazoEntrega = servico.SeprazoEntrega
                          }).ToListAsync();
        }
    }
}
