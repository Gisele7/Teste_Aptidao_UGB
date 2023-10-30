using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teste_Aptidao_UGB.Helpers;
using Teste_Aptidao_UGB.Model.Models;
using Teste_Aptidao_UGB.Model.Repositories;
using Teste_Aptidao_UGB.ViewModel;

namespace Teste_Aptidao_UGB.Controllers
{
    public class SaidaController : Controller
    {
        RepositoryUsuario _RepositoryUsuario = new RepositoryUsuario();
        RepositoryProdutos _RepositoryProdutos = new RepositoryProdutos();
        RepositoryDepartamento _RepositoryDepartamento = new RepositoryDepartamento();
        RepositorySaida _RepositorySaida = new RepositorySaida();


        /// <summary>
        /// Preenche a lista dos selects, para utilizar no selectList das telas de create e edit
        /// </summary>
        public void CarregaViewBag()
        {
            ViewData["SacodUsuario"] = new SelectList(_RepositoryUsuario.SelecionarTodos(), "Usmatricula", "Usnome");
            ViewData["SacodProduto"] = new SelectList(_RepositoryProdutos.SelecionarTodos(), "PrcodigoEan", "Prdescricao");
            ViewData["SacodDepartamento"] = new SelectList(_RepositoryDepartamento.SelecionarTodos(), "Decodigo", "Dedescricao");
        }
        public IActionResult Create()
        {
            CarregaViewBag();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Saida saida)
        {
            try
            {
                CarregaViewBag();
                if (ModelState.IsValid)
                {
                    await _RepositorySaida.IncluirAsync(saida);
                    ViewBag.produto = _RepositoryProdutos.SelecionarPk(saida.SacodProduto).Prdescricao;
                    ViewData["Mensagem"] = Mensagens.MensagemOK;
                    return View(saida);
                }
                else
                {
                    ViewBag.produto = _RepositoryProdutos.SelecionarPk(saida.SacodProduto).Prdescricao;
                    ViewData["MensagemErro"] = Mensagens.MensagemErro;
                    return View(saida);
                }
            }
            catch (Exception ex)
            {
                ViewBag.produto = _RepositoryProdutos.SelecionarPk(saida.SacodProduto).Prdescricao;
                ViewData["MensagemErro"] =ex.Message;
                return View(saida);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            CarregaViewBag();
            var saida = await _RepositorySaida.SelecionarPkAsync(id);
            ViewBag.produto = _RepositoryProdutos.SelecionarPk(saida.SacodProduto).Prdescricao;
            return View(saida);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Saida saida)
        {
            try
            {
                CarregaViewBag();
                if (ModelState.IsValid)
                {
                    await _RepositorySaida.AlterarAsync(saida);
                    ViewBag.produto = _RepositoryProdutos.SelecionarPk(saida.SacodProduto).Prdescricao;
                    ViewData["Mensagem"] = Mensagens.MensagemOK;
                    return View(saida);
                }
                else
                {
                    ViewBag.produto = _RepositoryProdutos.SelecionarPk(saida.SacodProduto).Prdescricao;
                    ViewData["MensagemErro"] = Mensagens.MensagemErro;
                    return View(saida);
                }
            }
            catch (Exception ex)
            {
                ViewBag.produto = _RepositoryProdutos.SelecionarPk(saida.SacodProduto).Prdescricao;
                ViewData["MensagemErro"] = ex.Message;
                return View(saida);
            }
        }

        public async Task<IActionResult> List()
        {
            var list = await SaidaVM.ListSaidasAsync();
            return View(list);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _RepositorySaida.ExcluirAsync(id);
                return RedirectToAction("List", new { mensagem = Mensagens.MensagemExclusao });
            }
            catch (Exception ex)
            {
                return RedirectToAction("List", new { mensagem = ex.Message });
            }
        }
    }
}
