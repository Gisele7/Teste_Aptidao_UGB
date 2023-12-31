﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teste_Aptidao_UGB.Helpers;
using Teste_Aptidao_UGB.Model.Models;
using Teste_Aptidao_UGB.Model.Repositories;
using Teste_Aptidao_UGB.ViewModel;

namespace Teste_Aptidao_UGB.Controllers
{
    public class SolicitacaoController : Controller
    {
        RepositoryProdutos _RepositoryProdutos = new RepositoryProdutos();
        RepositoryDepartamento _RepositoryDepartamento = new RepositoryDepartamento();
        RepositoryUsuario _RepositoryUsuario = new RepositoryUsuario();
        RepositoryServico _RepositoryServico = new RepositoryServico();
        RepositoryFornecedor _RepositoryFornecedor = new RepositoryFornecedor();
        RepositorySolicitacao _RepositorySolicitacao = new RepositorySolicitacao();

        /// <summary>
        /// Preenche a lista dos selects, para utilizar no selectList das telas de create e edit
        /// </summary>
        public void CarregaViewBag()
        {
            ViewData["SocodProduto"] = new SelectList(_RepositoryProdutos.SelecionarTodos(), "PrcodigoEan", "Prdescricao");
            ViewData["SocodDepartamento"] = new SelectList(_RepositoryDepartamento.SelecionarTodos(), "Decodigo", "Dedescricao");
            ViewData["SocodUsuario"] = new SelectList(_RepositoryUsuario.SelecionarTodos(), "Usmatricula", "Usnome");
            ViewData["SocodServico"] = new SelectList(_RepositoryServico.SelecionarTodos(), "Secodigo", "Senome");
            ViewData["SocodFornecedor"] = new SelectList(_RepositoryFornecedor.SelecionarTodos(), "Focodigo", "Fonome");
        }
        public IActionResult Create()
        {
            CarregaViewBag();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Solicitacao solicitacao)
        {
            try
            {
                CarregaViewBag();
                if (ModelState.IsValid)
                {
                    await _RepositorySolicitacao.IncluirAsync(solicitacao);
                    ViewData["Mensagem"] = Mensagens.MensagemOK;
                    return View(solicitacao);
                }
                else
                {
                    ViewData["MensagemErro"] = Mensagens.MensagemErro;
                    return View(solicitacao);
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            CarregaViewBag();
            var solicitacao = await _RepositorySolicitacao.SelecionarPkAsync(id);
            ViewBag.fornecedor = _RepositoryFornecedor.SelecionarPk(solicitacao.SocodFornecedor).Fonome;
            //como o typeahead nao seta o valor e mostra o label utilizo a viewbag para mostrar o nome do produto
            if (solicitacao.SocodProduto != null)
                ViewBag.produto = _RepositoryProdutos.SelecionarPk(solicitacao.SocodProduto).Prdescricao;
            return View(solicitacao);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Solicitacao solicitacao)
        {
            try
            {
                CarregaViewBag();
                if (ModelState.IsValid)
                {
                    await _RepositorySolicitacao.AlterarAsync(solicitacao);
                    ViewBag.fornecedor = _RepositoryFornecedor.SelecionarPk(solicitacao.SocodFornecedor).Fonome;
                    ViewData["Mensagem"] = Mensagens.MensagemOK;
                    if (solicitacao.SocodProduto != null)
                        ViewBag.produto = _RepositoryProdutos.SelecionarPk(solicitacao.SocodProduto).Prdescricao;
                    return View(solicitacao);
                }
                else
                {
                    ViewBag.fornecedor = _RepositoryFornecedor.SelecionarPk(solicitacao.SocodFornecedor).Fonome;
                    if (solicitacao.SocodProduto != null)
                        ViewBag.produto = _RepositoryProdutos.SelecionarPk(solicitacao.SocodProduto).Prdescricao;
                    ViewData["MensagemErro"] = Mensagens.MensagemErro;
                    return View(solicitacao);
                }
            }
            catch (Exception ex)
            {
                ViewBag.fornecedor = _RepositoryFornecedor.SelecionarPk(solicitacao.SocodFornecedor).Fonome;
                if (solicitacao.SocodProduto != null)
                    ViewBag.produto = _RepositoryProdutos.SelecionarPk(solicitacao.SocodProduto).Prdescricao;
                ViewData["MensagemErro"] = ex.Message;
                return View(solicitacao);
            }
        }

        public IActionResult List()
        {
            var list = SolicitacaoVM.ListSolicitacoesAsync();
            return View(list);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _RepositoryServico.ExcluirAsync(id);
                return RedirectToAction("List", new { mensagem = Mensagens.MensagemExclusao });
            }
            catch (Exception ex)
            {
                return RedirectToAction("List", new { mensagem = ex.Message });
            }
        }
    }
}
