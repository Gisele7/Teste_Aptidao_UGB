﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Teste_Aptidao_UGB.Model.Models;

public partial class Departamento
{
    public int Decodigo { get; set; }

    public string Dedescricao { get; set; }

    public virtual ICollection<Solicitacao> Solicitacao { get; set; } = new List<Solicitacao>();

    public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
}