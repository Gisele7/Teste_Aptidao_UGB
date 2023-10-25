using Microsoft.EntityFrameworkCore;
using Teste_Aptidao_UGB.Model.Models;

namespace Teste_Aptidao_UGB.ViewModel
{
    public class UsuarioVM
    {
        public int Matricula { get; set; }
        public string Nome { get; set;}
        public int CodigoDepartamento{ get; set; }
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
