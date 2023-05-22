using Domain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Professor { get; set; }
        public bool Aluno { get; set; }
        public virtual Usuario Usuario { get; set; }  
        public int? UsuarioId { get; set; }
        public static List<Pessoa> ListarAlunos(Conexao conexao)
        {
            return conexao.Pessoas.Where(x=>x.Aluno).ToList();
        }
        public static List<Pessoa> ListarProfessores(Conexao conexao)
        {
            return conexao.Pessoas.Where(x => x.Professor).ToList();
        }

        public static Pessoa GetById(Conexao conexao, int id)
        {
            return conexao.Pessoas.FirstOrDefault(x=>x.Id== id);
        }

        public void Salvar(Conexao conexao)
        {
            conexao.Pessoas.Add(this);
            conexao.SaveChanges();
        }

        public void Alterar(Conexao conexao)
        {
            conexao.Entry(this);
            conexao.SaveChanges();
        }

        public void Remover(Conexao conexao)
        {
            conexao.Pessoas.Remove(this);
            conexao.SaveChanges();
        }
    }
}
