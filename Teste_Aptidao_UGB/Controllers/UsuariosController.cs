using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teste_Aptidao_UGB.Model.Models;
using Teste_Aptidao_UGB.Model.Repositories;

namespace Teste_Aptidao_UGB.Controllers
{
    public class UsuariosController : Controller
    {
		RepositoryUsuario _RepositoryUsuario = new RepositoryUsuario();
		RepositoryDepartamento _RepositoryDepartamento = new RepositoryDepartamento();


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
        public IActionResult Create(Usuarios usuario)
        {
			try
			{
                CarregaViewBag();
                _RepositoryUsuario.Incluir(usuario);
				return View(usuario);
			}
			catch (Exception ex)
			{
				return View(ex);
			}
        }
    }
}
