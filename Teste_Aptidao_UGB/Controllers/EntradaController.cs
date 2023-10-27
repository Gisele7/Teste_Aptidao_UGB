using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teste_Aptidao_UGB.Helpers;
using Teste_Aptidao_UGB.Model.Models;
using Teste_Aptidao_UGB.Model.Repositories;
using Teste_Aptidao_UGB.ViewModel;

namespace Teste_Aptidao_UGB.Controllers
{
    public class EntradaController : Controller
    {
        RepositoryEntrada _RepositoryEntrada = new RepositoryEntrada();
        RepositoryDeposito _RepositoryDeposito = new RepositoryDeposito();
        RepositoryFornecedor _RepositoryFornecedor = new RepositoryFornecedor();
        RepositoryProdutos _RepositoryProdutos = new RepositoryProdutos();


        /// <summary>
        /// Preenche a lista dos selects, para utilizar no selectList das telas de create e edit
        /// </summary>
        public void CarregaViewBag()
        {
            ViewData["EtcodDeposito"] = new SelectList(_RepositoryDeposito.SelecionarTodos(), "Decodigo", "Dedescricao");
            ViewData["EtcodFornecedor"] = new SelectList(_RepositoryFornecedor.SelecionarTodos(), "Focodigo", "Fonome");
            ViewData["EtcodProduto"] = new SelectList(_RepositoryProdutos.SelecionarTodos(), "PrcodigoEan", "Prdescricao");
        }
        public IActionResult Create()
        {
            CarregaViewBag();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Entrada entrada)
        {
            try
            {
                CarregaViewBag();
                if (ModelState.IsValid)
                {
                    await _RepositoryEntrada.IncluirAsync(entrada);
                    ViewData["Mensagem"] = Mensagens.MensagemOK;
                    return View(entrada);
                }
                else
                {
                    ViewData["MensagemErro"] = Mensagens.MensagemErro;
                    return View(entrada);
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            CarregaViewBag();
            var entrada = await _RepositoryEntrada.SelecionarPkAsync(id);
            return View(entrada);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Entrada entrada)
        {
            try
            {
                CarregaViewBag();
                if (ModelState.IsValid)
                {
                    await _RepositoryEntrada.AlterarAsync(entrada);
                    ViewData["Mensagem"] = Mensagens.MensagemOK;
                    return View(entrada);
                }
                else
                {
                    ViewData["MensagemErro"] = Mensagens.MensagemErro;
                    return View(entrada);
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public async Task<IActionResult> List()
        {
            var list = await EntradaVM.ListEntradasAsync();
            return View(list);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _RepositoryEntrada.ExcluirAsync(id);
                return RedirectToAction("List", new { mensagem = Mensagens.MensagemExclusao });
            }
            catch (Exception ex)
            {
                return RedirectToAction("List", new { mensagem = ex.Message });
            }
        }
    }
}
