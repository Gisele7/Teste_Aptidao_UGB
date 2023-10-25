using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teste_Aptidao_UGB.Helpers;
using Teste_Aptidao_UGB.Model.Models;
using Teste_Aptidao_UGB.Model.Repositories;
using Teste_Aptidao_UGB.ViewModel;

namespace Teste_Aptidao_UGB.Controllers
{
    public class UnidadeController : Controller
    {
        RepositoryUnidade _RepositoryUnidade = new RepositoryUnidade();

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Unidade unidade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _RepositoryUnidade.IncluirAsync(unidade);
                    ViewData["Mensagem"] = Mensagens.MensagemOK;
                    return View(unidade);
                }
                else
                {
                    ViewData["MensagemErro"] = Mensagens.MensagemErro;
                    return View(unidade);
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var unidade = await _RepositoryUnidade.SelecionarPkAsync(id);
            return View(unidade);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Unidade unidade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _RepositoryUnidade.AlterarAsync(unidade);
                    ViewData["Mensagem"] = Mensagens.MensagemOK;
                    return View(unidade);
                }
                else
                {
                    ViewData["MensagemErro"] = Mensagens.MensagemErro;
                    return View(unidade);
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public async Task<IActionResult> List()
        {
            var list = await _RepositoryUnidade.SelecionarTodosAsync();
            return View(list);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _RepositoryUnidade.ExcluirAsync(id);
                return RedirectToAction("List", new { mensagem = Mensagens.MensagemExclusao });
            }
            catch (Exception ex)
            {
                return RedirectToAction("List", new { mensagem = ex.Message });
            }
        }


    }
}
