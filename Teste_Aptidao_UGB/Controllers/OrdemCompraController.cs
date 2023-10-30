using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing;
using System.Text;
using Teste_Aptidao_UGB.Helpers;
using Teste_Aptidao_UGB.Model.Models;
using Teste_Aptidao_UGB.Model.Repositories;
using Teste_Aptidao_UGB.Models;
using Teste_Aptidao_UGB.Services;
using Teste_Aptidao_UGB.ViewModel;

namespace Teste_Aptidao_UGB.Controllers
{
    public class OrdemCompraController : Controller
    {
        private readonly IMailService _mailService;
        RepositoryFornecedor _RepositoryFornecedor = new RepositoryFornecedor();
        RepositoryOrdemCompra _RepositoryOrdemCompra = new RepositoryOrdemCompra();

        public OrdemCompraController(IMailService mailService)
        {
            _mailService = mailService;
        }

        /// <summary>
        /// Preenche a lista dos selects, para utilizar no selectList das telas de create e edit
        /// </summary>
        public void CarregaViewBag()
        {

            ViewData["codigofornecedor"] = new SelectList(_RepositoryFornecedor.SelecionarTodos(), "Focodigo", "Fonome");
        }
        public IActionResult Create()
        {
            CarregaViewBag();
            OrdemCompraVM ordemCompraVM= new OrdemCompraVM();
            return View(ordemCompraVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrdemCompraVM ordemCompraVM)
        {

            try
            {
                CarregaViewBag();
                {
                     OrdemCompra ordemCompra = new OrdemCompra()
                    {
                        OccodFornecedor = ordemCompraVM.CodigoFornecedor,
                        Ocdata = ordemCompraVM.Data
                    };

                    List<OrdemCompraSolicitacao> ordemCompraSolicitacoes = new List<OrdemCompraSolicitacao>();

                    foreach (var item in ordemCompraVM.Solicitacoes)
                    {
                        ordemCompra.OrdemCompraSolicitacao.Add(new OrdemCompraSolicitacao
                        {
                            OsdataEntrega = item.DataEntrega,
                            Osquantidade = item.Quantidade,
                            OscodSolicitacao = item.Codigo
                        });
                    }

                     _RepositoryOrdemCompra.Incluir(ordemCompra, ordemCompra.OrdemCompraSolicitacao.ToList());
                    ordemCompraVM.EmailFornecedor = _RepositoryFornecedor.SelecionarPk(ordemCompraVM.CodigoFornecedor).Foemail;
                    ViewData["Mensagem"] = Mensagens.MensagemOK;

                    await  EnviarEmail(ordemCompra);
                    return RedirectToAction("Edit", new {id = ordemCompra.Occodigo, mensagem = Mensagens.MensagemOK, erro = false} );
                }
            }
            catch (Exception ex)
            {
                ViewData["MensagemErro"] = ex.Message;
                return View(ordemCompraVM);
            }
        }
        public async Task EnviarEmail(OrdemCompra ordemCompra)
        {
            var mailRequest = new EmailRequest()
            {
                Body = MontarCorpoEmail(ordemCompra),
                Subject = "Ordem de Compra",
                ToEmail= _RepositoryFornecedor.SelecionarPk(ordemCompra.OccodFornecedor).Foemail
            };

            await _mailService.SendEmailAsync(mailRequest);

        }
        public string MontarCorpoEmail(OrdemCompra ordemCompra)
        {

            StringBuilder corpoEmail = new StringBuilder();
            var solicitacoes =  SolicitacaoVM.ListSolicitacoesPorOrdemCompra(ordemCompra.Occodigo);

            corpoEmail.AppendLine(" ");
            corpoEmail.AppendLine("<br><br><p><b> Não responda este email, ela é uma notificação automática.</b></p>");
            corpoEmail.AppendLine("<span style='font-size: large; font-weight: bold;'>Solicitação de Compras</span>");
            corpoEmail.AppendLine("<table><tr><td>Produto</td><td>Quantidade</td><td>Valor</td><td>Valor Total</td></tr><tr></tr>");
          
            foreach (var item in solicitacoes)
            {
                var produto = item.IsServico ? item.Servico : item.Produto;
                corpoEmail.AppendLine($"<tr><td>{produto}</td><td>{item.Quantidade}</td><td>{item.ValorUnitario}</td><td>{item.ValorTotal}</td></tr><tr></tr>");
               
            }
            corpoEmail.AppendLine("</table>");


            return corpoEmail.ToString();
        }

        public async Task<IActionResult> Edit(int id, string mensagem = "", bool erro = false)
        {
            CarregaViewBag();
            var ordemCompra = await OrdemCompraVM.SelecionaOrdemCompra(id);
            if (mensagem != null)
            {
                if (erro)
                {
                    ViewData["MensagemErro"] = mensagem;
                }
                else
                {

                ViewData["Mensagem"] = mensagem;
                }
            }
            return View(ordemCompra);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OrdemCompraVM ordemCompraVM)
        {
            try
            {
                CarregaViewBag();
                {
                    OrdemCompra ordemCompra = new OrdemCompra()
                    {
                        Occodigo = ordemCompraVM.Codigo,
                        OccodFornecedor = ordemCompraVM.CodigoFornecedor,
                        Ocdata = ordemCompraVM.Data
                    };

                    List<OrdemCompraSolicitacao> ordemCompraSolicitacoes = new List<OrdemCompraSolicitacao>();

                    foreach (var item in ordemCompraVM.Solicitacoes)
                    {
                        ordemCompra.OrdemCompraSolicitacao.Add(new OrdemCompraSolicitacao
                        {
                            OsdataEntrega = item.DataEntrega,
                            Osquantidade = item.Quantidade,
                            OscodSolicitacao = item.Codigo
                        });
                    }

                    await _RepositoryOrdemCompra.AlterarAsync(ordemCompra, ordemCompra.OrdemCompraSolicitacao.ToList());
                    ordemCompraVM.EmailFornecedor = _RepositoryFornecedor.SelecionarPk(ordemCompraVM.CodigoFornecedor).Foemail;
                    await EnviarEmail(ordemCompra);
                    ViewData["Mensagem"] = Mensagens.MensagemOK;
                    return RedirectToAction("Edit", new { id = ordemCompra.Occodigo, mensagem = Mensagens.MensagemOK, erro = false });
                }
            }
            catch (Exception ex)
            {
                ViewData["MensagemErro"] = ex.Message;
                return View(ordemCompraVM);
            }
        }

        public async Task<IActionResult> List()
        {

            var list = await OrdemCompraVM.ListOrdensCompras();
            return View(list);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _RepositoryOrdemCompra.ExcluirAsync(id);
                return RedirectToAction("List", new { mensagem = Mensagens.MensagemExclusao });
            }
            catch (Exception ex)
            {
                return RedirectToAction("List", new { mensagem = ex.Message });
            }
        }
    }
}
