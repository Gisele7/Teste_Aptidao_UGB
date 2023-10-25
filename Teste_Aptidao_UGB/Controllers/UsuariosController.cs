using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teste_Aptidao_UGB.Helpers;
using Teste_Aptidao_UGB.Model.Models;
using Teste_Aptidao_UGB.Model.Repositories;
using Teste_Aptidao_UGB.ViewModel;

namespace Teste_Aptidao_UGB.Controllers
{
    public class UsuariosController : Controller
    {
        RepositoryUsuario _RepositoryUsuario = new RepositoryUsuario();
        RepositoryDepartamento _RepositoryDepartamento = new RepositoryDepartamento();

        /// <summary>
        /// Preenche a lista de departamento, para utilizar no selectList das telas de create e edit
        /// </summary>
        public void CarregaViewBag()
        {
            ViewData["UscodDepartamento"] = new SelectList(_RepositoryDepartamento.SelecionarTodos(), "Decodigo", "Dedescricao");
        }
        public IActionResult Create()
        {
            CarregaViewBag();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuarios usuario)
        {
            try
            {
                CarregaViewBag();
                if (ModelState.IsValid)
                {
                    await _RepositoryUsuario.IncluirAsync(usuario);
                    ViewData["Mensagem"] = Mensagens.MensagemOK;
                    return View(usuario);
                }
                else
                {
                    ViewData["MensagemErro"] = Mensagens.MensagemErro;
                    return View(usuario);
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public async Task<IActionResult> Edit(int matricula)
        {
            CarregaViewBag();
            var usuario = await _RepositoryUsuario.SelecionarPkAsync(matricula);
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Usuarios usuario)
        {
            try
            {
                CarregaViewBag();
                if (ModelState.IsValid)
                {
                    await _RepositoryUsuario.AlterarAsync(usuario);
                    ViewData["Mensagem"] = Mensagens.MensagemOK;
                    return View(usuario);
                }
                else
                {
                    ViewData["MensagemErro"] = Mensagens.MensagemErro;
                    return View(usuario);
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public async Task<IActionResult> List()
        {
            var list = await UsuarioVM.ListUsuariosAsync();
            return View(list);
        }

        public async Task<IActionResult> Delete(int matricula)
        {
            try
            {
                await _RepositoryUsuario.ExcluirAsync(matricula);
                return RedirectToAction("List", new { mensagem = Mensagens.MensagemExclusao });
            }
            catch (Exception ex)
            {
                return RedirectToAction("List", new { mensagem = ex.Message });
            }
        }
    }
}
