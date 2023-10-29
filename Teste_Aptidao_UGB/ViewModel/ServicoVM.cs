using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Teste_Aptidao_UGB.Model.Models;

namespace Teste_Aptidao_UGB.ViewModel
{
    public class ServicoVM
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int Codigo { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Nome { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Descricao { get; set; }
        [Display(Name = "Fornecedor")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int CodigoFornecedor { get; set; }
        [Display(Name = "Fornecedor")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Fornecedor { get; set; }
        [Display(Name = "Prazo de entrega")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public DateTime? PrazoEntrega { get; set; }

        /// <summary>
        /// Método para retornar todos os serviços cadastrados
        /// </summary>
        /// <returns>Lista de Tasks de ServicoVM</returns>
        public async static Task<List<ServicoVM>> ListServicosAsync()
        {
            var db = new SOLICITACAO_MATERIAISContext();
            return await (from servico in db.Servicos
                          join fornecedor in db.Fornecedores on servico.SecodFornecedor equals fornecedor.Focodigo
                          select new ServicoVM
                          {
                              Codigo =servico.Secodigo,
                              CodigoFornecedor = fornecedor.Focodigo,
                              Descricao = servico.Sedescricao,
                              Nome = servico.Senome,
                              Fornecedor = fornecedor.Fonome,
                              PrazoEntrega = servico.SeprazoEntrega
                          }).ToListAsync();
        }
        /// <summary>
        /// Lista todos os serviços de um determinado fornecedor
        /// </summary>
        /// <param name="codFornecedor">Código do Fornecedor</param>
        /// <returns>Lista de Tasks de ServicoVM</returns>
        public async static Task<List<ServicoVM>> ListServicosPorFornecedorAsync(int codFornecedor)
        {
            var db = new SOLICITACAO_MATERIAISContext();
            return await (from servico in db.Servicos
                          join fornecedor in db.Fornecedores on servico.SecodFornecedor equals fornecedor.Focodigo
                          where fornecedor.Focodigo == codFornecedor
                          select new ServicoVM
                          {
                              Codigo = servico.Secodigo,
                              CodigoFornecedor = fornecedor.Focodigo,
                              Descricao = servico.Sedescricao,
                              Nome = servico.Senome,
                              Fornecedor = fornecedor.Fonome,
                              PrazoEntrega = servico.SeprazoEntrega
                          }).ToListAsync();
        }


    }
}
