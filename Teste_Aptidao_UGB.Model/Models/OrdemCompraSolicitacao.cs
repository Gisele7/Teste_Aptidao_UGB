﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Teste_Aptidao_UGB.Model.Models;

public partial class OrdemCompraSolicitacao
{
    public int Oscodigo { get; set; }

    public int? OscodOrdemCompra { get; set; }

    public int? OscodSolicitacao { get; set; }

    public virtual OrdemCompra OscodOrdemCompraNavigation { get; set; }

    public virtual Solicitacao OscodSolicitacaoNavigation { get; set; }
}