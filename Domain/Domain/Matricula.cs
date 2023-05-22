using Domain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain
{
    public class Matricula
    {
        public int Id { set; get; }
        public int Ano { set; get; }
        public int Semestre { set; get; }
        public virtual Nota Nota { set; get; }

        public int? NotaId { set; get; }
        public virtual Pessoa Professor { set; get; }
        public int? ProfessorId { set; get; }
        public virtual Pessoa Aluno { set; get; }
        public int? AlunoId { set; get; }
        public virtual Disciplina Disciplina { set; get; }
        public int? DisciplinaId { set; get; }

        public void SetNota(Conexao conexao, float nota1, float nota2)
        {
            if (Nota == null)
            {
                Nota nota = new Nota(this, nota1, nota2);
                nota.Salvar(conexao);
            }
            else
            {
                Nota.Nota1 = nota1;
                Nota.Nota2 = nota2;
                Nota.Alterar(conexao);
            }
            conexao.SaveChanges();
        }

        public static List<Matricula> Listar(Conexao conexao, int ano, int semestre, int IdDisciplina)
        {
            return conexao.Matriculas.
                Where(x => x.Ano.Equals(ano) && 
                           x.Semestre.Equals(semestre) && 
                           x.Disciplina.Id.Equals(IdDisciplina)).ToList();
        }

        public static Matricula GetById(Conexao conexao, int id)
        {
            return conexao.Matriculas.FirstOrDefault(x => x.Id.Equals(id));
        }
    }
}
