using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Teste_Aptidao_UGB.Model.Models;

namespace Teste_Aptidao_UGB.ViewModel
{
    public class UsuarioVM
    {
    
        [Display(Name ="Matrícula")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int Matricula { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Nome { get; set;}

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int CodigoDepartamento{ get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Departamento{ get; set; }

        public UsuarioVM()
        {
            
        }

        /// <summary>
        /// Método para retornar todos os usuários cadastrados
        /// </summary>
        /// <returns></returns>
        public async static Task<List<UsuarioVM>> ListUsuariosAsync()
        {
            var db = new SOLICITACAO_MATERIAISContext();
            return await (from usuario in db.Usuarios
                    join departamento in db.Departamento on usuario.UscodDepartamento equals departamento.Decodigo
                    select new UsuarioVM
                    {
                        Departamento = departamento.Dedescricao,
                        CodigoDepartamento = departamento.Decodigo,
                        Matricula = usuario.Usmatricula,
                        Nome = usuario.Usnome
                    }).ToListAsync();
        }
    }
}
