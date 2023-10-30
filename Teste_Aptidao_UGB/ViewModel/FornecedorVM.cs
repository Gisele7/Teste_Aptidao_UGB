using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Teste_Aptidao_UGB.Model.Models;

namespace Teste_Aptidao_UGB.ViewModel
{
    public class FornecedorVM
    {
        [Display(Name ="Código")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MaxLength(13, ErrorMessage ="O tamanho máximo do CNPJ são 13 caracteres.")]
        public string CNPJ { get; set; }

        [Display(Name = "Inscrição Estadual")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string InscricaoEstadual { get; set; }

        [Display(Name = "Inscrição Municipal")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string InscricaoMunicipal { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int? CEP { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Logradouro { get; set; }

        public string? Complemento { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Cidade { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Estado { get; set; }


        [Display(Name = "Número")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Numero { get; set; }


        /// <summary>
        /// Método para retornar todos os fornecedores cadastrados
        /// </summary>
        /// <returns>List of FornecedorVM</returns>
        public async static Task<List<FornecedorVM>> ListFornecedoresAsync()
        {
            var db = new SOLICITACAO_MATERIAISContext();
            return await (from fornecedor in db.Fornecedores
                          join endereco in db.Endereco on fornecedor.Focodigo equals endereco.EncodFornecedor
                          select new FornecedorVM
                          {
                              CNPJ = fornecedor.Focnpj,
                              Codigo = fornecedor.Focodigo,
                              Email = fornecedor.Foemail,
                              InscricaoEstadual = fornecedor.FoinscricaoEstadual,
                              InscricaoMunicipal = fornecedor.FoinscricaoMunicipal,
                              Nome = fornecedor.Fonome,
                              CEP = endereco.Encep,
                              Logradouro = endereco.Enlogradouro,
                              Bairro = endereco.Enbairro,
                              Cidade = endereco.Encidade,
                              Complemento = endereco.Encomplemento,
                              Estado = endereco.Enestado,
                              Numero = endereco.Ennumero
                          }).ToListAsync();
        }

        /// <summary>
        /// Método para selecionar um fornecedor
        /// </summary>
        /// <param name="codigo">Código do fornecedor</param>
        /// <returns>FornecedorVM</returns>
        public static async Task<FornecedorVM> SelecionaFornecedorAsync(int codigo)
        {
            var db = new SOLICITACAO_MATERIAISContext();
            return await (from fornecedor in db.Fornecedores
                          join endereco in db.Endereco on fornecedor.Focodigo equals endereco.EncodFornecedor
                          select new FornecedorVM
                          {
                              CNPJ = fornecedor.Focnpj,
                              Codigo = fornecedor.Focodigo,
                              Email = fornecedor.Foemail,
                              InscricaoEstadual = fornecedor.FoinscricaoEstadual,
                              InscricaoMunicipal = fornecedor.FoinscricaoMunicipal,
                              Nome = fornecedor.Fonome,
                              CEP = endereco.Encep,
                              Logradouro = endereco.Enlogradouro,
                              Bairro = endereco.Enbairro,
                              Cidade = endereco.Encidade,
                              Complemento = endereco.Encomplemento,
                              Estado = endereco.Enestado,
                              Numero = endereco.Ennumero
                          })!.FirstOrDefaultAsync();
        }
    }
}
