using System;
using System.Collections.Generic;
using APIWorkshop.Domains;
using Microsoft.EntityFrameworkCore;

namespace APIWorkshop.Contexts;

public partial class WorkshopContext : DbContext
{
    public WorkshopContext()
    {
    }

    public WorkshopContext(DbContextOptions<WorkshopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cidade> Cidades { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Estoque> Estoques { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<Loja> Lojas { get; set; }

    public virtual DbSet<Participante> Participantes { get; set; }

    public virtual DbSet<ParticipantesEvento> ParticipantesEventos { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Regiao> Regiaos { get; set; }

    public virtual DbSet<TipoEvento> TipoEventos { get; set; }

    public virtual DbSet<Venda> Vendas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MobileAL;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cidade>(entity =>
        {
            entity.ToTable("cidade");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Cidade1)
                .HasMaxLength(255)
                .HasColumnName("Cidade");

            entity.HasOne(d => d.Estado).WithMany(p => p.Cidades)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK_cidade_estado");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.ToTable("estado");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Estado1)
                .HasMaxLength(255)
                .HasColumnName("Estado");
            entity.Property(e => e.Sigla).HasMaxLength(255);

            entity.HasOne(d => d.Regiao).WithMany(p => p.Estados)
                .HasForeignKey(d => d.RegiaoId)
                .HasConstraintName("FK_estado_regiao");
        });

        modelBuilder.Entity<Estoque>(entity =>
        {
            entity.ToTable("estoque");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.LojaId).HasColumnName("lojaId");
            entity.Property(e => e.ProdutoId).HasColumnName("produtoId");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");

            entity.HasOne(d => d.Loja).WithMany(p => p.Estoques)
                .HasForeignKey(d => d.LojaId)
                .HasConstraintName("FK_estoque_loja");

            entity.HasOne(d => d.Produto).WithMany(p => p.Estoques)
                .HasForeignKey(d => d.ProdutoId)
                .HasConstraintName("FK_estoque_produto");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.ToTable("evento");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Evento1)
                .HasMaxLength(255)
                .HasColumnName("evento");
            entity.Property(e => e.TipoId).HasColumnName("tipoId");

            entity.HasOne(d => d.Tipo).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.TipoId)
                .HasConstraintName("FK_evento_tipo_evento");
        });

        modelBuilder.Entity<Loja>(entity =>
        {
            entity.ToTable("loja");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Loja1)
                .HasMaxLength(255)
                .HasColumnName("loja");
        });

        modelBuilder.Entity<Participante>(entity =>
        {
            entity.ToTable("participante");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CidadeId).HasColumnName("cidadeId");
            entity.Property(e => e.Genero)
                .HasMaxLength(255)
                .HasColumnName("genero");
            entity.Property(e => e.Idade).HasColumnName("idade");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .HasColumnName("nome");

            entity.HasOne(d => d.Cidade).WithMany(p => p.Participantes)
                .HasForeignKey(d => d.CidadeId)
                .HasConstraintName("FK_participante_cidade");
        });

        modelBuilder.Entity<ParticipantesEvento>(entity =>
        {
            entity.ToTable("participantes_evento");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.EventoId).HasColumnName("eventoId");
            entity.Property(e => e.ParticipanteId).HasColumnName("participanteId");

            entity.HasOne(d => d.Evento).WithMany(p => p.ParticipantesEventos)
                .HasForeignKey(d => d.EventoId)
                .HasConstraintName("FK_participantes_evento_evento");

            entity.HasOne(d => d.Participante).WithMany(p => p.ParticipantesEventos)
                .HasForeignKey(d => d.ParticipanteId)
                .HasConstraintName("FK_participantes_evento_participante");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.ToTable("produto");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Produto1)
                .HasMaxLength(255)
                .HasColumnName("produto");
            entity.Property(e => e.Valor).HasColumnName("valor");
        });

        modelBuilder.Entity<Regiao>(entity =>
        {
            entity.ToTable("regiao");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Regiao1)
                .HasMaxLength(255)
                .HasColumnName("regiao");
        });

        modelBuilder.Entity<TipoEvento>(entity =>
        {
            entity.ToTable("tipo_evento");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.TipoEvento1)
                .HasMaxLength(255)
                .HasColumnName("tipo_evento");
        });

        modelBuilder.Entity<Venda>(entity =>
        {
            entity.ToTable("vendas");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("datetime")
                .HasColumnName("data");
            entity.Property(e => e.Hora)
                .HasColumnType("datetime")
                .HasColumnName("hora");
            entity.Property(e => e.LojaId).HasColumnName("lojaId");
            entity.Property(e => e.ParticipanteId).HasColumnName("participanteId");
            entity.Property(e => e.ProdutoId).HasColumnName("produtoId");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");
            entity.Property(e => e.Transacao)
                .HasMaxLength(255)
                .HasColumnName("transacao");

            entity.HasOne(d => d.Evento).WithMany(p => p.Venda)
                .HasForeignKey(d => d.EventoId)
                .HasConstraintName("FK_vendas_evento");

            entity.HasOne(d => d.Loja).WithMany(p => p.Venda)
                .HasForeignKey(d => d.LojaId)
                .HasConstraintName("FK_vendas_loja");

            entity.HasOne(d => d.Participante).WithMany(p => p.Venda)
                .HasForeignKey(d => d.ParticipanteId)
                .HasConstraintName("FK_vendas_participante");

            entity.HasOne(d => d.Produto).WithMany(p => p.Venda)
                .HasForeignKey(d => d.ProdutoId)
                .HasConstraintName("FK_vendas_produto");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
