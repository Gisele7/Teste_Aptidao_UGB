﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Teste_Aptidao_UGB.Model.Models;

public partial class Endereco
{
    public int Encodigo { get; set; }

    public string Enlogradouro { get; set; }

    public int? Encep { get; set; }

    public string Encomplemento { get; set; }

    public string Enbairro { get; set; }

    public string Encidade { get; set; }

    public string Enestado { get; set; }

    public string Ennumero { get; set; }

    public int? EncodFornecedor { get; set; }

    public virtual Fornecedores EncodFornecedorNavigation { get; set; }
}