using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teste_Aptidao_UGB.Helpers;
using Teste_Aptidao_UGB.Model.Models;
using Teste_Aptidao_UGB.Model.Repositories;
using Teste_Aptidao_UGB.ViewModel;

namespace Teste_Aptidao_UGB.Controllers
{
    public class DepartamentoController : Controller
    {
        RepositoryDepartamento _RepositoryDepartamento = new RepositoryDepartamento();

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Departamento departamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _RepositoryDepartamento.IncluirAsync(departamento);
                    ViewData["Mensagem"] = Mensagens.MensagemOK;
                    return View(departamento);
                }
                else
                {
                    ViewData["MensagemErro"] = Mensagens.MensagemErro;
                    return View(departamento);
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var departamento = await _RepositoryDepartamento.SelecionarPkAsync(id);
            return View(departamento);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Departamento departamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _RepositoryDepartamento.AlterarAsync(departamento);
                    ViewData["Mensagem"] = Mensagens.MensagemOK;
                    return View(departamento);
                }
                else
                {
                    ViewData["MensagemErro"] = Mensagens.MensagemErro;
                    return View(departamento);
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public async Task<IActionResult> List()
        {
            var list = await _RepositoryDepartamento.SelecionarTodosAsync();
            return View(list);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _RepositoryDepartamento.ExcluirAsync(id);
                return RedirectToAction("List", new { mensagem = Mensagens.MensagemExclusao });
            }
            catch (Exception ex)
            {
                return RedirectToAction("List", new { mensagem = ex.Message });
            }
        }


    }
}
