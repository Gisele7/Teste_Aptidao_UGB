﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Teste_Aptidao_UGB.Model.Models;

public partial class SOLICITACAO_MATERIAISContext : DbContext
{
    public SOLICITACAO_MATERIAISContext()
    {
        
    }
    public SOLICITACAO_MATERIAISContext(DbContextOptions<SOLICITACAO_MATERIAISContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Departamento> Departamento { get; set; }

    public virtual DbSet<Depositos> Depositos { get; set; }

    public virtual DbSet<Endereco> Endereco { get; set; }

    public virtual DbSet<Entrada> Entrada { get; set; }

    public virtual DbSet<Fornecedores> Fornecedores { get; set; }

    public virtual DbSet<OrdemCompra> OrdemCompra { get; set; }

    public virtual DbSet<OrdemCompraSolicitacao> OrdemCompraSolicitacao { get; set; }

    public virtual DbSet<Produtos> Produtos { get; set; }

    public virtual DbSet<Saida> Saida { get; set; }

    public virtual DbSet<Servicos> Servicos { get; set; }

    public virtual DbSet<Solicitacao> Solicitacao { get; set; }

    public virtual DbSet<Unidade> Unidade { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
  => optionsbuilder.UseSqlServer("data source=localhost\\SQLEXPRESS;Initial Catalog=SOLICITACAO_MATERIAIS;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Decodigo).HasName("PK_DBO.DEPARTAMENTO");

            entity.ToTable("DEPARTAMENTO");

            entity.Property(e => e.Decodigo).HasColumnName("DECodigo");
            entity.Property(e => e.Dedescricao)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DEDescricao");
        });

        modelBuilder.Entity<Depositos>(entity =>
        {
            entity.HasKey(e => e.Decodigo).HasName("PK_DBO.DEPOSITOS");

            entity.ToTable("DEPOSITOS");

            entity.Property(e => e.Decodigo).HasColumnName("DECodigo");
            entity.Property(e => e.Dedescricao)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DEDescricao");
        });

        modelBuilder.Entity<Endereco>(entity =>
        {
            entity.HasKey(e => e.Encodigo).HasName("PK_DBO.ENDERECO");

            entity.ToTable("ENDERECO");

            entity.Property(e => e.Encodigo).HasColumnName("ENCodigo");
            entity.Property(e => e.Enbairro)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ENBairro");
            entity.Property(e => e.Encep).HasColumnName("ENCEP");
            entity.Property(e => e.Encidade)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ENCidade");
            entity.Property(e => e.EncodFornecedor).HasColumnName("ENCodFornecedor");
            entity.Property(e => e.Encomplemento)
                .IsUnicode(false)
                .HasColumnName("ENComplemento");
            entity.Property(e => e.Enestado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ENEstado");
            entity.Property(e => e.Enlogradouro)
                .IsUnicode(false)
                .HasColumnName("ENLogradouro");
            entity.Property(e => e.Ennumero)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ENNumero");

            entity.HasOne(d => d.EncodFornecedorNavigation).WithMany(p => p.Endereco)
                .HasForeignKey(d => d.EncodFornecedor)
                .HasConstraintName("FK_ENDERECO_FORNECEDORES");
        });

        modelBuilder.Entity<Entrada>(entity =>
        {
            entity.HasKey(e => e.Etcodigo).HasName("PK_DBO.ENTRADA");

            entity.ToTable("ENTRADA");

            entity.Property(e => e.Etcodigo).HasColumnName("ETCodigo");
            entity.Property(e => e.EtcodDeposito).HasColumnName("ETCodDeposito");
            entity.Property(e => e.EtcodFornecedor).HasColumnName("ETCodFornecedor");
            entity.Property(e => e.EtcodProduto).HasColumnName("ETCodProduto");
            entity.Property(e => e.Etdata)
                .HasColumnType("datetime")
                .HasColumnName("ETData");
            entity.Property(e => e.EtnotaFiscal)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ETNotaFiscal");
            entity.Property(e => e.Etquantidade).HasColumnName("ETQuantidade");

            entity.HasOne(d => d.EtcodDepositoNavigation).WithMany(p => p.Entrada)
                .HasForeignKey(d => d.EtcodDeposito)
                .HasConstraintName("FK_DBO.ENTRADA_DBO.DEPOSITOS");

            entity.HasOne(d => d.EtcodFornecedorNavigation).WithMany(p => p.Entrada)
                .HasForeignKey(d => d.EtcodFornecedor)
                .HasConstraintName("FK_DBO.ENTRADA_DBO.FORNECEDORES");

            entity.HasOne(d => d.EtcodProdutoNavigation).WithMany(p => p.Entrada)
                .HasForeignKey(d => d.EtcodProduto)
                .HasConstraintName("FK_DBO.ENTRADA_DBO.PRODUTOS");
        });

        modelBuilder.Entity<Fornecedores>(entity =>
        {
            entity.HasKey(e => e.Focodigo).HasName("PK_DBO.FORNECEDORES");

            entity.ToTable("FORNECEDORES");

            entity.Property(e => e.Focodigo).HasColumnName("FOCodigo");
            entity.Property(e => e.Focnpj)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FOCNPJ");
            entity.Property(e => e.Foemail)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("FOEmail");
            entity.Property(e => e.FoinscricaoEstadual)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FOInscricaoEstadual");
            entity.Property(e => e.FoinscricaoMunicipal)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FOInscricaoMunicipal");
            entity.Property(e => e.Fonome)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("FONome");
        });

        modelBuilder.Entity<OrdemCompra>(entity =>
        {
            entity.HasKey(e => e.Occodigo).HasName("PK_DBO.ORDEM_COMPRA");

            entity.ToTable("ORDEM_COMPRA");

            entity.Property(e => e.Occodigo).HasColumnName("OCCodigo");
            entity.Property(e => e.OccodFornecedor).HasColumnName("OCCodFornecedor");
            entity.Property(e => e.Ocdata)
                .HasColumnType("datetime")
                .HasColumnName("OCData");
            entity.Property(e => e.Ocsolicitada)
                .HasDefaultValueSql("((0))")
                .HasColumnName("OCSolicitada");
        });

        modelBuilder.Entity<OrdemCompraSolicitacao>(entity =>
        {
            entity.HasKey(e => e.Oscodigo).HasName("PK_DBO.ORDEM_COMPRA_SOLICITACAO");

            entity.ToTable("ORDEM_COMPRA_SOLICITACAO");

            entity.Property(e => e.Oscodigo).HasColumnName("OSCodigo");
            entity.Property(e => e.OscodOrdemCompra).HasColumnName("OSCodOrdemCompra");
            entity.Property(e => e.OscodSolicitacao).HasColumnName("OSCodSolicitacao");

            entity.HasOne(d => d.OscodOrdemCompraNavigation).WithMany(p => p.OrdemCompraSolicitacao)
                .HasForeignKey(d => d.OscodOrdemCompra)
                .HasConstraintName("FK_DBO.ORDEM_COMPRA_SOLICITACAO_DBO.ORDEM_COMPRA");

            entity.HasOne(d => d.OscodSolicitacaoNavigation).WithMany(p => p.OrdemCompraSolicitacao)
                .HasForeignKey(d => d.OscodSolicitacao)
                .HasConstraintName("FK_DBO.ORDEM_COMPRA_SOLICITACAO_DBO.SOLICITACAO");
        });

        modelBuilder.Entity<Produtos>(entity =>
        {
            entity.HasKey(e => e.PrcodigoEan).HasName("PK_DBO.PRODUTOS");

            entity.ToTable("PRODUTOS");

            entity.Property(e => e.PrcodigoEan)
                .ValueGeneratedNever()
                .HasColumnName("PRCodigoEAN");
            entity.Property(e => e.PrcodUnidade).HasColumnName("PRCodUnidade");
            entity.Property(e => e.PrcotaMinimaEstoque).HasColumnName("PRCotaMinimaEstoque");
            entity.Property(e => e.Prdescricao)
                .IsUnicode(false)
                .HasColumnName("PRDescricao");
            entity.Property(e => e.PrprecoUnitario)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PRPrecoUnitario");

            entity.HasOne(d => d.PrcodUnidadeNavigation).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.PrcodUnidade)
                .HasConstraintName("FK_DBO.PRODUTOS_DBO.UNIDADE");
        });

        modelBuilder.Entity<Saida>(entity =>
        {
            entity.HasKey(e => e.Sacodigo).HasName("PK_DBO.SAIDA");

            entity.ToTable("SAIDA");

            entity.Property(e => e.Sacodigo).HasColumnName("SACodigo");
            entity.Property(e => e.SacodDepartamento).HasColumnName("SACodDepartamento");
            entity.Property(e => e.SacodProduto).HasColumnName("SACodProduto");
            entity.Property(e => e.SacodUsuario).HasColumnName("SACodUsuario");
            entity.Property(e => e.Sadata)
                .HasColumnType("datetime")
                .HasColumnName("SAData");
            entity.Property(e => e.Saquantidade).HasColumnName("SAQuantidade");

            entity.HasOne(d => d.SacodDepartamentoNavigation).WithMany(p => p.Saida)
                .HasForeignKey(d => d.SacodDepartamento)
                .HasConstraintName("FK_SAIDA_DEPARTAMENTO");

            entity.HasOne(d => d.SacodProdutoNavigation).WithMany(p => p.Saida)
                .HasForeignKey(d => d.SacodProduto)
                .HasConstraintName("FK_SAIDA_PRODUTOS");

            entity.HasOne(d => d.SacodUsuarioNavigation).WithMany(p => p.Saida)
                .HasForeignKey(d => d.SacodUsuario)
                .HasConstraintName("FK_SAIDA_USUARIOS");
        });

        modelBuilder.Entity<Servicos>(entity =>
        {
            entity.HasKey(e => e.Secodigo).HasName("PK_DBO.SERVICOS");

            entity.ToTable("SERVICOS");

            entity.Property(e => e.Secodigo).HasColumnName("SECodigo");
            entity.Property(e => e.SecodFornecedor).HasColumnName("SECodFornecedor");
            entity.Property(e => e.Sedescricao)
                .IsUnicode(false)
                .HasColumnName("SEDescricao");
            entity.Property(e => e.Senome)
                .IsUnicode(false)
                .HasColumnName("SENome");
            entity.Property(e => e.SeprazoEntrega)
                .HasColumnType("datetime")
                .HasColumnName("SEPrazoEntrega");

            entity.HasOne(d => d.SecodFornecedorNavigation).WithMany(p => p.Servicos)
                .HasForeignKey(d => d.SecodFornecedor)
                .HasConstraintName("FK_DBO.SERVICOS_DBO.FORNECEDORES");
        });

        modelBuilder.Entity<Solicitacao>(entity =>
        {
            entity.HasKey(e => e.Socodigo).HasName("PK_DBO.SOLICITACAO");

            entity.ToTable("SOLICITACAO");

            entity.Property(e => e.Socodigo).HasColumnName("SOCodigo");
            entity.Property(e => e.SocodDepartamento).HasColumnName("SOCodDepartamento");
            entity.Property(e => e.SocodFornecedor).HasColumnName("SOCodFornecedor");
            entity.Property(e => e.SocodProduto).HasColumnName("SOCodProduto");
            entity.Property(e => e.SocodServico).HasColumnName("SOCodServico");
            entity.Property(e => e.SocodUsuario).HasColumnName("SOCodUsuario");
            entity.Property(e => e.Soconcluida)
                .HasDefaultValueSql("((0))")
                .HasColumnName("SOConcluida");
            entity.Property(e => e.Sodata)
                .HasColumnType("datetime")
                .HasColumnName("SOData");
            entity.Property(e => e.Soobservacao)
                .IsUnicode(false)
                .HasColumnName("SOObservacao");
            entity.Property(e => e.Soquantidade).HasColumnName("SOQuantidade");

            entity.HasOne(d => d.SocodDepartamentoNavigation).WithMany(p => p.Solicitacao)
                .HasForeignKey(d => d.SocodDepartamento)
                .HasConstraintName("FK_DBO.SOLICITACAO_DBO.DEPARTAMENTO");

            entity.HasOne(d => d.SocodFornecedorNavigation).WithMany(p => p.Solicitacao)
                .HasForeignKey(d => d.SocodFornecedor)
                .HasConstraintName("FK_DBO.SOLICITACAO_DBO.FORNECEDORES");

            entity.HasOne(d => d.SocodProdutoNavigation).WithMany(p => p.Solicitacao)
                .HasForeignKey(d => d.SocodProduto)
                .HasConstraintName("FK_DBO.SOLICITACAO_DBO.PRODUTOS");

            entity.HasOne(d => d.SocodServicoNavigation).WithMany(p => p.Solicitacao)
                .HasForeignKey(d => d.SocodServico)
                .HasConstraintName("FK_DBO.SOLICITACAO_DBO.SERVICOS");

            entity.HasOne(d => d.SocodUsuarioNavigation).WithMany(p => p.Solicitacao)
                .HasForeignKey(d => d.SocodUsuario)
                .HasConstraintName("FK_DBO.SOLICITACAO_DBO.USUARIOS");
        });

        modelBuilder.Entity<Unidade>(entity =>
        {
            entity.HasKey(e => e.Uncodigo).HasName("PK_DBO.UNIDADE");

            entity.ToTable("UNIDADE");

            entity.Property(e => e.Uncodigo).HasColumnName("UNCodigo");
            entity.Property(e => e.Undescricao)
                .IsUnicode(false)
                .HasColumnName("UNDescricao");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.Usmatricula).HasName("PK_DBO.USUARIOS");

            entity.ToTable("USUARIOS");

            entity.Property(e => e.Usmatricula)
                .ValueGeneratedNever()
                .HasColumnName("USMatricula");
            entity.Property(e => e.UscodDepartamento).HasColumnName("USCodDepartamento");
            entity.Property(e => e.Usnome)
                .IsUnicode(false)
                .HasColumnName("USNome");

            entity.HasOne(d => d.UscodDepartamentoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.UscodDepartamento)
                .HasConstraintName("FK_DBO.USUARIOS_DBO.DEPARTAMENTO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}