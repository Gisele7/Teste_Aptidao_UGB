using System.ComponentModel.DataAnnotations;
using Teste_Aptidao_UGB.Model.Models;

namespace Teste_Aptidao_UGB.ViewModel
{
    public class SaidaVM
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int Codigo { get; set; }

        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int? CodigoUsuario { get; set; }

        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string NomeUsuario { get; set; }

        [Display(Name = "Produto")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public long? CodigoProduto { get; set; }

        [Display(Name = "Produto")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Produto { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int? CodigoDepartamento { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Departamento { get; set; }

        [Display(Name = "Data")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public DateTime? Data { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int? Quantidade { get; set; }

        /// <summary>
        /// Método para retornar todas as saídas cadastradas
        /// </summary>
        /// <returns></returns>
        public async static Task<List<SaidaVM>> ListSaidasAsync()
        {
            var db = new SOLICITACAO_MATERIAISContext();
            var retorno = new List<SaidaVM>();

            var saidas = db.Saida.ToList();

            foreach (var item in saidas)
            {
                SaidaVM saidaVM = new SaidaVM()
                {
                    CodigoDepartamento = item.SacodDepartamento,
                    CodigoProduto = item.SacodProduto,
                    CodigoUsuario = item.SacodUsuario,
                    Data = item.Sadata,
                    Departamento = db.Departamento.FirstOrDefault(x => x.Decodigo == item.SacodDepartamento).Dedescricao,
                    NomeUsuario = db.Usuarios.FirstOrDefault(x => x.Usmatricula == item.SacodUsuario).Usnome,
                    Produto = db.Produtos.FirstOrDefault(x => x.PrcodigoEan == item.SacodProduto).Prdescricao,
                };

                retorno.Add(saidaVM);
            }
            return retorno;
        }
    }
}
