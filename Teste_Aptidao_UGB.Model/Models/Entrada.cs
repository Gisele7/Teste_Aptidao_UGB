﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Teste_Aptidao_UGB.Model.Models;

public partial class Entrada
{
    public int Etcodigo { get; set; }

    public string EtnotaFiscal { get; set; }

    public DateTime? Etdata { get; set; }

    public int? EtcodDeposito { get; set; }

    public int? EtcodFornecedor { get; set; }

    public int? Etquantidade { get; set; }

    public long? EtcodProduto { get; set; }

    public virtual Depositos EtcodDepositoNavigation { get; set; }

    public virtual Fornecedores EtcodFornecedorNavigation { get; set; }

    public virtual Produtos EtcodProdutoNavigation { get; set; }
}