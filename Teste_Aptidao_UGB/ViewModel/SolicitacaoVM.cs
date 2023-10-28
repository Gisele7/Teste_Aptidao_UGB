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
        public decimal? ValorUnitario { get; set; }
        public decimal? ValorTotal { get; set; }
        public string Unidade { get; set; }
        public int? QuantidadeRequisitada { get; set; }
        public DateTime? DataEntrega { get; set; }
        public bool IsServico { get; set; } = false;


        /// <summary>
        /// Método para retornar todos as solicitações cadastradas
        /// </summary>
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
                solicitacaoVM.Unidade = db.Unidade.FirstOrDefault(x => x.Uncodigo == produto.PrcodUnidade).Undescricao;
                solicitacaoVM.ValorUnitario = produto != null ? produto.PrprecoUnitario : servico.Sevalor;
                solicitacaoVM.ValorTotal = produto == null ? 0 : produto.PrprecoUnitario * solicitacao.Soquantidade;
                solicitacaoVM.QuantidadeRequisitada = solicitacao.Soquantidade;
                solicitacaoVM.DataEntrega = db.OrdemCompraSolicitacao.FirstOrDefault(x => x.Oscodigo == item.Oscodigo).OsdataEntrega;

                retorno.Add(solicitacaoVM);
            }

            return retorno;
        }

    }
}
