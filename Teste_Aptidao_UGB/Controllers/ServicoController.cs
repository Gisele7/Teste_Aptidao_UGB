using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teste_Aptidao_UGB.Helpers;
using Teste_Aptidao_UGB.Model.Models;
using Teste_Aptidao_UGB.Model.Repositories;
using Teste_Aptidao_UGB.ViewModel;

namespace Teste_Aptidao_UGB.Controllers
{
    public class ServicoController : Controller
    {
        RepositoryFornecedor _RepositoryFornecedor = new RepositoryFornecedor();
        RepositoryServico _RepositoryServico = new RepositoryServico();
        /// <summary>
        /// Preenche a lista de fornecedores, para utilizar no selectList das telas de create e edit
        /// </summary>
        public void CarregaViewBag()
        {
            ViewData["Secodfornecedor"] = new SelectList(_RepositoryFornecedor.SelecionarTodos(), "Fecodigo", "Fenome");
        }
        public IActionResult Create()
        {
            CarregaViewBag();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Servicos servico)
        {
            try
            {
                CarregaViewBag();
                if (ModelState.IsValid)
                {
                    await _RepositoryServico.IncluirAsync(servico);
                    ViewData["Mensagem"] = Mensagens.MensagemOK;
                    return View(servico);
                }
                else
                {
                    ViewData["MensagemErro"] = Mensagens.MensagemErro;
                    return View(servico);
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
            var servico = await _RepositoryServico.SelecionarPkAsync(id);
            return View(servico);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Servicos servico)
        {
            try
            {
                CarregaViewBag();
                if (ModelState.IsValid)
                {
                    await _RepositoryServico.AlterarAsync(servico);
                    ViewData["Mensagem"] = Mensagens.MensagemOK;
                    return View(servico);
                }
                else
                {
                    ViewData["MensagemErro"] = Mensagens.MensagemErro;
                    return View(servico);
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public async Task<IActionResult> List()
        {
            var list = await ServicoVM.ListServicosAsync();
            return View(list);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _RepositoryServico.ExcluirAsync(id);
                return RedirectToAction("List", new { mensagem = Mensagens.MensagemExclusao });
            }
            catch (Exception ex)
            {
                return RedirectToAction("List", new { mensagem = ex.Message });
            }
        }
    }
}
