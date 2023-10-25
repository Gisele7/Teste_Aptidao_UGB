
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teste_Aptidao_UGB.Helpers;
using Teste_Aptidao_UGB.Model.Models;
using Teste_Aptidao_UGB.Model.Repositories;
using Teste_Aptidao_UGB.ViewModel;

namespace Teste_Aptidao_UGB.Controllers
{
    public class FornecedorController : Controller
    {
        RepositoryFornecedor _RepositoryFornecedor = new RepositoryFornecedor();

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FornecedorVM fornecedorVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var fornecedor = new Fornecedores()
                    {
                        Focnpj = fornecedorVM.CNPJ,
                        Foemail = fornecedorVM.Email,
                        FoinscricaoEstadual = fornecedorVM.InscricaoEstadual,
                        FoinscricaoMunicipal = fornecedorVM.InscricaoMunicipal,
                        Fonome = fornecedorVM.Nome
                    };

                    var endereco = new Endereco()
                    {
                        Enbairro = fornecedorVM.Bairro,
                        Encep = fornecedorVM.CEP,
                        Encidade = fornecedorVM.Cidade,
                        Encomplemento = fornecedorVM.Complemento,
                        Enestado = fornecedorVM.Estado,
                        Enlogradouro = fornecedorVM.Logradouro,
                        Ennumero = fornecedorVM.Numero
                    };

                    fornecedor.Endereco.Add(endereco);
                    await _RepositoryFornecedor.IncluirAsync(fornecedor);
                    ViewData["Mensagem"] = Mensagens.MensagemOK;
                    return View(fornecedorVM);
                }
                else
                {
                    ViewData["MensagemErro"] = Mensagens.MensagemErro;
                    return View(fornecedorVM);
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var fornecedor = await FornecedorVM.SelecionaFornecedorAsync(id);
            return View(fornecedor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FornecedorVM fornecedorVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var fornecedor = new Fornecedores()
                    {
                        Focnpj = fornecedorVM.CNPJ,
                        Foemail = fornecedorVM.Email,
                        FoinscricaoEstadual = fornecedorVM.InscricaoEstadual,
                        FoinscricaoMunicipal = fornecedorVM.InscricaoMunicipal,
                        Fonome = fornecedorVM.Nome
                    };

                    var endereco = new Endereco()
                    {
                        Enbairro = fornecedorVM.Bairro,
                        Encep = fornecedorVM.CEP,
                        Encidade = fornecedorVM.Cidade,
                        Encomplemento = fornecedorVM.Complemento,
                        Enestado = fornecedorVM.Estado,
                        Enlogradouro = fornecedorVM.Logradouro,
                        Ennumero = fornecedorVM.Numero
                    };

                    fornecedor.Endereco.Add(endereco);
                    await _RepositoryFornecedor.AlterarAsync(fornecedor);
                    ViewData["Mensagem"] = Mensagens.MensagemOK;
                    return View(fornecedorVM);
                }
                else
                {
                    ViewData["MensagemErro"] = Mensagens.MensagemErro;
                    return View(fornecedorVM);
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public async Task<IActionResult> List()
        {
            var list = await FornecedorVM.ListFornecedoresAsync();
            return View(list);
        }

        //public async Task<IActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        await _RepositoryProdutos.ExcluirAsync(id);
        //        return RedirectToAction("List", new { mensagem = Mensagens.MensagemExclusao });
        //    }
        //    catch (Exception ex)
        //    {
        //        return RedirectToAction("List", new { mensagem = ex.Message });
        //    }
        //}
    }
}
