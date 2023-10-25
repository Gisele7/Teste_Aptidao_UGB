using Microsoft.AspNetCore.Mvc;
using Teste_Aptidao_UGB.Helpers;
using Teste_Aptidao_UGB.Model.Models;
using Teste_Aptidao_UGB.Model.Repositories;

namespace Teste_Aptidao_UGB.Controllers
{
    public class DepositoController : Controller
    {
        RepositoryDeposito _RepositoryDeposito = new RepositoryDeposito();

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Depositos deposito)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _RepositoryDeposito.IncluirAsync(deposito);
                    ViewData["Mensagem"] = Mensagens.MensagemOK;
                    return View(deposito);
                }
                else
                {
                    ViewData["MensagemErro"] = Mensagens.MensagemErro;
                    return View(deposito);
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var deposito = await _RepositoryDeposito.SelecionarPkAsync(id);
            return View(deposito);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Depositos deposito)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _RepositoryDeposito.AlterarAsync(deposito);
                    ViewData["Mensagem"] = Mensagens.MensagemOK;
                    return View(deposito);
                }
                else
                {
                    ViewData["MensagemErro"] = Mensagens.MensagemErro;
                    return View(deposito);
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public async Task<IActionResult> List()
        {
            var list = await _RepositoryDeposito.SelecionarTodosAsync();
            return View(list);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _RepositoryDeposito.ExcluirAsync(id);
                return RedirectToAction("List", new { mensagem = Mensagens.MensagemExclusao });
            }
            catch (Exception ex)
            {
                return RedirectToAction("List", new { mensagem = ex.Message });
            }
        }
    }
}
