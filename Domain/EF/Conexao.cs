using Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace Domain.EF
{
    public class Conexao:DbContext
    {
        public Conexao(DbContextOptions<Conexao> options) : base(options) { }
        internal DbSet<Curso> Cursos { get; set; }
        internal DbSet<Disciplina> Disciplinas { get; set; }
        internal DbSet<Matricula> Matriculas { get; set;}
        internal DbSet<Nota> Notas { get; set; }
        internal DbSet<Pessoa> Pessoas { get; set; }
        internal DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>(t =>
            {
                t.ToTable("Cursos");
                t.Property(t=>t.Id).HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
                t.Property(t => t.Nome).HasColumnType("varchar(50)").IsRequired();
            });

            modelBuilder.Entity<Disciplina>(t =>
            {
                t.ToTable("Disciplinas");
                t.Property(t => t.Id).HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
                t.Property(t => t.ProjetoPedagogico).HasColumnType("text").IsRequired();
                t.Property(t => t.Nome).HasColumnType("varchar(50)").IsRequired();
                t.Property(t => t.CursoId).HasColumnType("int").IsRequired();
                t.HasOne(t => t.Curso).WithMany().
                    OnDelete(DeleteBehavior.NoAction).IsRequired();
            });

            modelBuilder.Entity<Matricula>(t =>
            {
                t.ToTable("Matriculas");
                t.Property(t => t.Id).HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
                t.Property(t => t.Ano).HasColumnType("varchar(4)").IsRequired();
                t.Property(t => t.Semestre).HasColumnType("varchar(1)").IsRequired();
                t.HasOne(t => t.Nota).WithMany().
                    OnDelete(DeleteBehavior.NoAction).
                    IsRequired(false);
                t.Property(t => t.NotaId).HasColumnType("int").IsRequired(false);
                t.HasOne(t => t.Professor).WithMany().
                    OnDelete(DeleteBehavior.NoAction).
                    IsRequired();
                t.Property(t => t.ProfessorId).HasColumnType("int").IsRequired();
                t.HasOne(t => t.Disciplina).WithMany().
                    OnDelete(DeleteBehavior.NoAction).
                    IsRequired();
                t.Property(t => t.DisciplinaId).HasColumnType("int").IsRequired();
                t.HasOne(t => t.Aluno).WithMany().
                    OnDelete(DeleteBehavior.NoAction).IsRequired();
                t.Property(t => t.AlunoId).HasColumnType("int").IsRequired();
            });

            modelBuilder.Entity<Nota>(t =>
            {
                t.ToTable("Notas");
                t.Property(t => t.Id).HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
                t.Property(t => t.Nota1).HasColumnType("float").IsRequired();
                t.Property(t => t.Nota2).HasColumnType("float").IsRequired();
            });

            modelBuilder.Entity<Pessoa>(t =>
            {
                t.ToTable("Pessoas");
                t.Property(t => t.Id).HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
                t.Property(t => t.Nome).HasColumnType("varchar(50)").IsRequired();
                t.Property(t => t.Professor).HasColumnType("bit").IsRequired();
                t.Property(t => t.Aluno).HasColumnType("bit").IsRequired();
                t.HasOne(t => t.Usuario).WithMany().
                    OnDelete(DeleteBehavior.NoAction).IsRequired();
                t.Property(t => t.UsuarioId).HasColumnType("int").IsRequired();
            });

            modelBuilder.Entity<Usuario>(t =>
            {
                t.ToTable("Usuarios");
                t.Property(t => t.Id).HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
                t.Property(t => t.Login).HasColumnType("varchar(10)").IsRequired();
                t.Property(t => t.Senha).HasColumnType("varchar(10)").IsRequired();
            });
        }
    }
}
