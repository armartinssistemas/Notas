using Domain.Domain;

namespace Domain.EF
{
    public class DBInitializer
    {
        public static void Initialize(Conexao context)
        {
            if (context.Database.EnsureCreated())
            {
                Curso gti = new Domain.Curso { Nome = "Gestão de Tecnologia da Informação" };
                context.Cursos.Add(gti);

                Disciplina disciplina = new Disciplina
                {
                    Nome = "Programação para Internet",
                    ProjetoPedagogico = "Disciplina voltada a programação de back-end e front-end",
                    Curso = gti
                };
                context.Disciplinas.Add(disciplina);

                Usuario usuario = new Usuario
                {
                    Login = "admin",
                    Senha = "123"
                };

                Pessoa professor = new Pessoa
                {
                    Nome = "Ronaldo",
                    Professor = true,
                    Aluno = false,
                    Usuario = usuario
                };
                context.Pessoas.Add(professor);


                Usuario usuarioa1 = new Usuario
                {
                    Login = "joao",
                    Senha = "123"
                };
                Pessoa aluno1 = new Pessoa
                {
                    Nome = "João da Silva",
                    Professor = false,
                    Aluno = true,
                    Usuario = usuarioa1
                };
                context.Pessoas.Add(aluno1);

                Usuario usuarioa2 = new Usuario
                {
                    Login = "maria",
                    Senha = "123"
                };
                Pessoa aluno2 = new Pessoa
                {
                    Nome = "Maria Tereza",
                    Professor = false,
                    Aluno = true,
                    Usuario = usuarioa1
                };
                context.Pessoas.Add(aluno2);

                Matricula m1 = new Matricula
                {
                    Aluno = aluno1,
                    Professor = professor,
                    Ano = 2023,
                    Semestre = 1,
                    Disciplina = disciplina
                };
                Matricula m2 = new Matricula
                {
                    Aluno = aluno2,
                    Professor = professor,
                    Ano = 2023,
                    Semestre = 1,
                    Disciplina = disciplina
                };
                context.Matriculas.Add(m1);
                context.Matriculas.Add(m2);

                context.SaveChanges();
            }
        }
    }
}
