using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Teste_Aptidao_UGB.Model.Models;

namespace Teste_Aptidao_UGB.ViewModel
{
    public class SolicitacaoVM
    {

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int Codigo { get; set; }

        [Display(Name = "Produto")]
        public long? CodigoProduto { get; set; }

        [Display(Name = "Produto")]
        public string Produto { get; set; }

        [Display(Name = "Qtd")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int? Quantidade { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int? CodDepartamento { get; set; }

        [Display(Name = "Departamento")]
        public string Departamento { get; set; }

        [Display(Name = "Matrícula")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int MatriculaUsuario { get; set; }

        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Usuario { get; set; }

        [Display(Name = "Data")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public DateTime? Data { get; set; }


        [Display(Name = "Serviço")]
        public int? CodigoServico { get; set; }

        [Display(Name = "Serviço")]
        public string Servico { get; set; }

        [Display(Name = "Fornecedor")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int? CodFornecedor { get; set; }

        [Display(Name = "Fornecedor")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Fornecedor { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        [Display(Name = "Concluída?")]
        public bool? Concluida { get; set; }

        [Display(Name = "Valor unitário")]
        public decimal? ValorUnitario { get; set; }

        [Display(Name = "Valor total")]
        public decimal? ValorTotal { get; set; }

        [Display(Name = "Unidade")]
        public string Unidade { get; set; }

        [Display(Name = "Quantidade requisitada")]
        public int? QuantidadeRequisitada { get; set; }

        [Display(Name = "Data de entrega")]
        public DateTime? DataEntrega { get; set; }
        public bool IsServico { get; set; } = false;


/// <summary>
/// Método para listar todas as solicitações de acordo com status
/// </summary>
/// <param name="concluida">Parâmetro opctional para listar as Solicitações conclúdas ou não</param>
/// <returns></returns>
        public static List<SolicitacaoVM> ListSolicitacoesAsync(bool concluida = false)
        {
            var db = new SOLICITACAO_MATERIAISContext();
            var retorno = new List<SolicitacaoVM>();

            var solicitacoes = db.Solicitacao.Where(x => x.Soconcluida == concluida).ToList();

            foreach (var solicitacao in solicitacoes)
            {
                SolicitacaoVM solicitacaoVM = new SolicitacaoVM();
                var produto = db.Produtos.FirstOrDefault(x => x.PrcodigoEan == solicitacao.SocodProduto);
                var servico = db.Servicos.FirstOrDefault(x => x.Secodigo == solicitacao.SocodServico);

                solicitacaoVM.Codigo = solicitacao.Socodigo;
                solicitacaoVM.CodDepartamento = solicitacao.SocodDepartamento;
                solicitacaoVM.CodFornecedor = solicitacao.SocodFornecedor;
                solicitacaoVM.CodigoProduto = solicitacao.SocodProduto;
                solicitacaoVM.CodigoServico = solicitacao.SocodServico;
                solicitacaoVM.Concluida = solicitacao.Soconcluida;
                solicitacaoVM.Data = solicitacao.Sodata;
                solicitacaoVM.Departamento = db.Departamento.FirstOrDefault(x => x.Decodigo == solicitacao.SocodDepartamento).Dedescricao;
                solicitacaoVM.Fornecedor = solicitacao.SocodFornecedor == null ? "" : db.Fornecedores.FirstOrDefault(x => x.Focodigo == solicitacao.SocodFornecedor).Fonome;
                solicitacaoVM.MatriculaUsuario = (int)solicitacao.SocodUsuario;
                solicitacaoVM.Observacao = solicitacao.Soobservacao;
                solicitacaoVM.Produto = solicitacao.SocodProduto == null ? "" : db.Produtos.FirstOrDefault(x => x.PrcodigoEan == solicitacao.SocodProduto).Prdescricao;
                solicitacaoVM.Quantidade = solicitacao.Soquantidade;
                solicitacaoVM.Servico = solicitacao.SocodServico == null ? "" : db.Servicos.FirstOrDefault(x => x.Secodigo == solicitacao.SocodServico).Sedescricao;
                solicitacaoVM.Usuario = produto == null ? "" : db.Usuarios.FirstOrDefault(x => x.Usmatricula == solicitacao.SocodUsuario).Usnome;
                solicitacaoVM.Unidade = produto == null ? "" :  db.Unidade.FirstOrDefault(x => x.Uncodigo == produto.PrcodUnidade).Undescricao;
                solicitacaoVM.ValorUnitario = produto != null ? produto.PrprecoUnitario : servico.Sevalor;
                solicitacaoVM.ValorTotal = produto == null ? 0 : produto.PrprecoUnitario * solicitacao.Soquantidade;
                solicitacaoVM.QuantidadeRequisitada = solicitacao.Soquantidade;
                solicitacaoVM.IsServico = produto == null ? true : false;


                retorno.Add(solicitacaoVM);
            }
            return retorno;
        }
        /// <summary>
        /// Metodo para selecionar uma solicitação específica
        /// </summary>
        /// <param name="codigoSolicitacao">Código da Solicitação</param>
        /// <returns></returns>
        public async static Task<SolicitacaoVM> SelecionaSolicitacaoAsync(int codigoSolicitacao)
        {
            var db = new SOLICITACAO_MATERIAISContext();

            var solicitacao = await db.Solicitacao.FirstOrDefaultAsync(x => x.Socodigo == codigoSolicitacao);

            SolicitacaoVM solicitacaoVM = new SolicitacaoVM();
            var produto = db.Produtos.FirstOrDefault(x => x.PrcodigoEan == solicitacao.SocodProduto);
            var servico = db.Servicos.FirstOrDefault(x => x.Secodigo == solicitacao.SocodServico);

            solicitacaoVM.Codigo = solicitacao.Socodigo;
            solicitacaoVM.CodDepartamento = solicitacao.SocodDepartamento;
            solicitacaoVM.CodFornecedor = solicitacao.SocodFornecedor;
            solicitacaoVM.CodigoProduto = solicitacao.SocodProduto;
            solicitacaoVM.CodigoServico = solicitacao.SocodServico;
            solicitacaoVM.Concluida = solicitacao.Soconcluida;
            solicitacaoVM.Data = solicitacao.Sodata;
            solicitacaoVM.Departamento = db.Departamento.FirstOrDefault(x => x.Decodigo == solicitacao.SocodDepartamento).Dedescricao;
            solicitacaoVM.Fornecedor = solicitacao.SocodFornecedor == null ? "" : db.Fornecedores.FirstOrDefault(x => x.Focodigo == solicitacao.SocodFornecedor).Fonome;
            solicitacaoVM.MatriculaUsuario = (int)solicitacao.SocodUsuario;
            solicitacaoVM.Observacao = solicitacao.Soobservacao;
            solicitacaoVM.Produto = solicitacao.SocodProduto == null ? "" : db.Produtos.FirstOrDefault(x => x.PrcodigoEan == solicitacao.SocodProduto).Prdescricao;
            solicitacaoVM.Quantidade = 0;
            solicitacaoVM.Servico = solicitacao.SocodServico == null ? "" : db.Servicos.FirstOrDefault(x => x.Secodigo == solicitacao.SocodServico).Sedescricao;
            solicitacaoVM.Usuario = produto == null ? "" : db.Usuarios.FirstOrDefault(x => x.Usmatricula == solicitacao.SocodUsuario).Usnome;
            solicitacaoVM.Unidade = db.Unidade.FirstOrDefault(x => x.Uncodigo == produto.PrcodUnidade).Undescricao;
            solicitacaoVM.ValorUnitario = produto != null ? produto.PrprecoUnitario : servico.Sevalor;
            solicitacaoVM.ValorTotal = produto == null ? 0 : produto.PrprecoUnitario * solicitacao.Soquantidade;
            solicitacaoVM.QuantidadeRequisitada = solicitacao.Soquantidade;
            solicitacaoVM.IsServico = produto == null ? true : false;

            return solicitacaoVM;
        }
        /// <summary>
        /// Métodod para listar todas as solicitações de uma determinada ordem de compra
        /// </summary>
        /// <param name="codigoOrdemCompra">Código da Ordem de Compra</param>
        /// <returns></returns>
        public async static Task<List<SolicitacaoVM>> ListSolicitacoesPorOrdemCompraAsync(int codigoOrdemCompra)
        {
            var db = new SOLICITACAO_MATERIAISContext();
            var retorno = new List<SolicitacaoVM>();

            var ordemCompraSolicitacoes = await db.OrdemCompraSolicitacao.Where(x=> x.OscodOrdemCompra == codigoOrdemCompra).ToListAsync();

            foreach (var item in ordemCompraSolicitacoes)
            {
                var solicitacao = await db.Solicitacao.FirstOrDefaultAsync(x => x.Socodigo == item.OscodSolicitacao);
                var produto = db.Produtos.FirstOrDefault(x => x.PrcodigoEan == solicitacao.SocodProduto);
                var servico = db.Servicos.FirstOrDefault(x => x.Secodigo == solicitacao.SocodServico);

                SolicitacaoVM solicitacaoVM = new SolicitacaoVM();

                solicitacaoVM.Codigo = solicitacao.Socodigo;
                solicitacaoVM.CodDepartamento = solicitacao.SocodDepartamento;
                solicitacaoVM.CodFornecedor = solicitacao.SocodFornecedor;
                solicitacaoVM.CodigoProduto = solicitacao.SocodProduto;
                solicitacaoVM.CodigoServico = solicitacao.SocodServico;
                solicitacaoVM.Concluida = solicitacao.Soconcluida;
                solicitacaoVM.Data = solicitacao.Sodata;
                solicitacaoVM.Departamento = db.Departamento.FirstOrDefault(x => x.Decodigo == solicitacao.SocodDepartamento).Dedescricao;
                solicitacaoVM.Fornecedor = solicitacao.SocodFornecedor == null ? "" : db.Fornecedores.FirstOrDefault(x => x.Focodigo == solicitacao.SocodFornecedor).Fonome;
                solicitacaoVM.MatriculaUsuario = (int)solicitacao.SocodUsuario;
                solicitacaoVM.Observacao = solicitacao.Soobservacao;
                solicitacaoVM.Produto = solicitacao.SocodProduto == null ? "" : db.Produtos.FirstOrDefault(x => x.PrcodigoEan == solicitacao.SocodProduto).Prdescricao;
                solicitacaoVM.Quantidade = db.OrdemCompraSolicitacao.FirstOrDefault(x => x.Oscodigo == item.Oscodigo).Osquantidade;
                solicitacaoVM.Servico = solicitacao.SocodServico == null ? "" : db.Servicos.FirstOrDefault(x => x.Secodigo == solicitacao.SocodServico).Sedescricao;
                solicitacaoVM.Usuario = produto == null ? "" : db.Usuarios.FirstOrDefault(x => x.Usmatricula == solicitacao.SocodUsuario).Usnome;
                solicitacaoVM.Unidade = produto == null ? "" : db.Unidade.FirstOrDefault(x => x.Uncodigo == produto.PrcodUnidade).Undescricao;
                solicitacaoVM.ValorUnitario = produto != null ? produto.PrprecoUnitario : servico.Sevalor;
                solicitacaoVM.ValorTotal = produto == null ? 0 : produto.PrprecoUnitario * item.Osquantidade ;
                solicitacaoVM.QuantidadeRequisitada = solicitacao.Soquantidade;
                solicitacaoVM.DataEntrega = db.OrdemCompraSolicitacao.FirstOrDefault(x => x.Oscodigo == item.Oscodigo).OsdataEntrega;

                retorno.Add(solicitacaoVM);
            }

            return retorno;
        }

    }
}
