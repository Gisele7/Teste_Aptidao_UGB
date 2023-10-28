using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teste_Aptidao_UGB.Helpers;
using Teste_Aptidao_UGB.Model.Models;
using Teste_Aptidao_UGB.Model.Repositories;
using Teste_Aptidao_UGB.ViewModel;

namespace Teste_Aptidao_UGB.Controllers
{
    public class OrdemCompraController : Controller
    {
        RepositoryFornecedor _RepositoryFornecedor = new RepositoryFornecedor();
        RepositoryOrdemCompra _RepositoryOrdemCompra = new RepositoryOrdemCompra();

        /// <summary>
        /// Preenche a lista dos selects, para utilizar no selectList das telas de create e edit
        /// </summary>
        public void CarregaViewBag()
        {
            ViewData["CodigoFornecedor"] = new SelectList(_RepositoryFornecedor.SelecionarTodos(), "Focodigo", "Fonome");
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

                    await _RepositoryOrdemCompra.IncluirAsync(ordemCompra);
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

        public async Task<IActionResult> Edit(int id)
        {
            CarregaViewBag();
            var ordemCompra = await OrdemCompraVM.SelecionaOrdemCompra(id);
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
