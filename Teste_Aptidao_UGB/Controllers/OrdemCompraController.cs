using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                    ViewData["Mensagem"] = Mensagens.MensagemOK;

                    await  EnviarEmail(ordemCompraVM);
                    return RedirectToAction("Edit", new {id = ordemCompra.Occodigo, mensagem = Mensagens.MensagemOK, erro = false} );
                }
            }
            catch (Exception ex)
            {
                ViewData["MensagemErro"] = ex.Message;
                return View(ordemCompraVM);
            }
        }
        public async Task EnviarEmail(OrdemCompraVM ordemCompraVM)
        {
            var mailRequest = new EmailRequest()
            {
                Body = MontarCorpoEmail(ordemCompraVM),
                Subject = "Ordem de Compra",
                ToEmail= ordemCompraVM.EmailFornecedor
            };

            await _mailService.SendEmailAsync(mailRequest);

        }
        public string MontarCorpoEmail(OrdemCompraVM ordemCompraVM)
        {

            StringBuilder corpoEmail = new StringBuilder();

            corpoEmail.AppendLine(" ");
            corpoEmail.AppendLine("<br><br><p><b> Não responda este email, ela é uma notificação automática.</b></p>");
            corpoEmail.AppendLine("<span style='font-align:left;font-size:12px'> Ordem de Compra</span><br />");
            corpoEmail.AppendLine("<span style='font-align:left;font-size:12px'> Itens</span><br />");
            foreach (var item in ordemCompraVM.Solicitacoes)
            {
                corpoEmail.AppendLine($"<span style='font-align:left;font-size:12px'>{item.Produto}</span><br />");
                corpoEmail.AppendLine($"<span style='font-align:left;font-size:12px'>{item.Quantidade}</span><br />");
                corpoEmail.AppendLine($"<span style='font-align:left;font-size:12px'>{item.ValorUnitario}</span><br />");
                corpoEmail.AppendLine($"<span style='font-align:left;font-size:12px'>{item.ValorTotal}</span><br />");
            }
           
           
            
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
                    await EnviarEmail(ordemCompraVM);
                    ViewData["Mensagem"] = Mensagens.MensagemOK;
                    return View(ordemCompraVM);
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
