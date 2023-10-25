using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teste_Aptidao_UGB.Helpers;
using Teste_Aptidao_UGB.Model.Models;
using Teste_Aptidao_UGB.Model.Repositories;
using Teste_Aptidao_UGB.ViewModel;

namespace Teste_Aptidao_UGB.Controllers
{
    public class ProdutosController : Controller
    {
        RepositoryProdutos _RepositoryProdutos = new RepositoryProdutos();
        RepositoryUnidade _RepositoryUnidade = new RepositoryUnidade();
        /// <summary>
        /// Preenche a lista de unidades, para utilizar no selectList das telas de create e edit
        /// </summary>
        public void CarregaViewBag()
        {
            ViewData["PrcodUnidade"] = new SelectList(_RepositoryUnidade.SelecionarTodos(), "Uncodigo", "Undescricao");
        }
        public IActionResult Create()
        {
            CarregaViewBag();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Produtos produtos)
        {
            try
            {
                CarregaViewBag();
                if (ModelState.IsValid)
                {
                    await _RepositoryProdutos.IncluirAsync(produtos);
                    ViewData["Mensagem"] = Mensagens.MensagemOK;
                    return View(produtos);
                }
                else
                {
                    ViewData["MensagemErro"] = Mensagens.MensagemErro;
                    return View(produtos);
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public async Task<IActionResult> Edit(long id)
        {
            CarregaViewBag();
            var produto = await _RepositoryProdutos.SelecionarPkAsync(id);
            return View(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Produtos produto)
        {
            try
            {
                CarregaViewBag();
                if (ModelState.IsValid)
                {
                    await _RepositoryProdutos.AlterarAsync(produto);
                    ViewData["Mensagem"] = Mensagens.MensagemOK;
                    return View(produto);
                }
                else
                {
                    ViewData["MensagemErro"] = Mensagens.MensagemErro;
                    return View(produto);
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public async Task<IActionResult> List()
        {
            var list = await ProdutoVM.ListProdutosAsync();
            return View(list);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _RepositoryProdutos.ExcluirAsync(id);
                return RedirectToAction("List", new { mensagem = Mensagens.MensagemExclusao });
            }
            catch (Exception ex)
            {
                return RedirectToAction("List", new { mensagem = ex.Message });
            }
        }
    }
}
