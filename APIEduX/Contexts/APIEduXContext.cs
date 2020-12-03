using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using APIEduX.Domains;

namespace APIEduX.Contexts
{
    public partial class APIEduXContext : DbContext
    {
        public APIEduXContext()
        {
        }

        public APIEduXContext(DbContextOptions<APIEduXContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlunoTurmas> AlunoTurmas { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<Curtidas> Curtidas { get; set; }
        public virtual DbSet<Dicas> Dicas { get; set; }
        public virtual DbSet<Instituicoes> Instituicoes { get; set; }
        public virtual DbSet<ObjetivoAlunos> ObjetivoAlunos { get; set; }
        public virtual DbSet<Objetivos> Objetivos { get; set; }
        public virtual DbSet<Perfis> Perfis { get; set; }
        public virtual DbSet<ProfessorTurmas> ProfessorTurmas { get; set; }
        public virtual DbSet<Turmas> Turmas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-HJTFSJFK\\SQLEXPRESS;Initial Catalog=EduX;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoTurmas>(entity =>
            {
                entity.HasKey(e => e.IdAlunoTurma)
                    .HasName("PK__AlunoTur__8F3223BDEA30B42C");

                entity.Property(e => e.IdAlunoTurma).ValueGeneratedNever();

                entity.Property(e => e.Matricula)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany(p => p.AlunoTurmas)
                    .HasForeignKey(d => d.IdTurma)
                    .HasConstraintName("FK__AlunoTurm__IdTur__52593CB8");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.AlunoTurmas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__AlunoTurm__IdUsu__5165187F");
            });

            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__A3C02A108919673C");

                entity.Property(e => e.IdCategoria).ValueGeneratedNever();

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cursos>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__Cursos__085F27D6C16426EA");

                entity.Property(e => e.IdCurso).ValueGeneratedNever();

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdInstituicaoNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdInstituicao)
                    .HasConstraintName("FK__Cursos__IdInstit__3C69FB99");
            });

            modelBuilder.Entity<Curtidas>(entity =>
            {
                entity.HasKey(e => e.IdCurtida)
                    .HasName("PK__Curtidas__2169583A14A7D228");

                entity.Property(e => e.IdCurtida).ValueGeneratedNever();

                entity.HasOne(d => d.IdDicaNavigation)
                    .WithMany(p => p.Curtidas)
                    .HasForeignKey(d => d.IdDica)
                    .HasConstraintName("FK__Curtidas__IdDica__48CFD27E");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Curtidas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Curtidas__IdUsua__47DBAE45");
            });

            modelBuilder.Entity<Dicas>(entity =>
            {
                entity.HasKey(e => e.IdDica)
                    .HasName("PK__Dicas__F1688516CB24DD54");

                entity.Property(e => e.IdDica).ValueGeneratedNever();

                entity.Property(e => e.Imagem)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Texto)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Dicas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Dicas__IdUsuario__44FF419A");
            });

            modelBuilder.Entity<Instituicoes>(entity =>
            {
                entity.HasKey(e => e.IdInstituicao)
                    .HasName("PK__Institui__B771C0D86C8BEB64");

                entity.Property(e => e.IdInstituicao).ValueGeneratedNever();

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .HasColumnName("UF")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ObjetivoAlunos>(entity =>
            {
                entity.HasKey(e => e.IdObjetivoAluno)
                    .HasName("PK__Objetivo__81E21D7A36923F62");

                entity.Property(e => e.IdObjetivoAluno).ValueGeneratedNever();

                entity.Property(e => e.DataEntrega).HasColumnType("datetime");

                entity.Property(e => e.Nota).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdAlunoTurmaNavigation)
                    .WithMany(p => p.ObjetivoAlunos)
                    .HasForeignKey(d => d.IdAlunoTurma)
                    .HasConstraintName("FK__ObjetivoA__IdAlu__571DF1D5");

                entity.HasOne(d => d.IdObjetivoNavigation)
                    .WithMany(p => p.ObjetivoAlunos)
                    .HasForeignKey(d => d.IdObjetivo)
                    .HasConstraintName("FK__ObjetivoA__IdObj__5629CD9C");
            });

            modelBuilder.Entity<Objetivos>(entity =>
            {
                entity.HasKey(e => e.IdObjetivo)
                    .HasName("PK__Objetivo__E210F07119436A97");

                entity.Property(e => e.IdObjetivo).ValueGeneratedNever();

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Objetivos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Objetivos__IdCat__4BAC3F29");
            });

            modelBuilder.Entity<Perfis>(entity =>
            {
                entity.HasKey(e => e.IdPerfil)
                    .HasName("PK__Perfis__C7BD5CC113B065A6");

                entity.Property(e => e.IdPerfil).ValueGeneratedNever();

                entity.Property(e => e.Permissao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProfessorTurmas>(entity =>
            {
                entity.HasKey(e => e.IdProfessorTurma)
                    .HasName("PK__Professo__D4E74F9E9BA173AC");

                entity.Property(e => e.IdProfessorTurma).ValueGeneratedNever();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany(p => p.ProfessorTurmas)
                    .HasForeignKey(d => d.IdTurma)
                    .HasConstraintName("FK__Professor__IdTur__5AEE82B9");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.ProfessorTurmas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Professor__IdUsu__59FA5E80");
            });

            modelBuilder.Entity<Turmas>(entity =>
            {
                entity.HasKey(e => e.IdTurma)
                    .HasName("PK__Turmas__C1ECFFC9306162D3");

                entity.Property(e => e.IdTurma).ValueGeneratedNever();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Turmas)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__Turmas__IdCurso__4E88ABD4");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__5B65BF97ABDE7BE1");

                entity.Property(e => e.IdUsuario).ValueGeneratedNever();

                entity.Property(e => e.DataCadastro).HasColumnType("datetime");

                entity.Property(e => e.DataUltimoAcesso).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPerfil)
                    .HasConstraintName("FK__Usuarios__IdPerf__3F466844");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
