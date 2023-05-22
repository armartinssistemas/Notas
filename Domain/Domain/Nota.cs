using Domain.EF;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Domain.Domain
{
    public class Nota
    {
        public Nota(){}
        
        public Nota(Matricula matricula, float nota1, float nota2)
        {
            Nota1 = nota1;
            Nota2 = nota2;
            matricula.Nota = this;
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a Nota 1")]
        public float? Nota1 { set; get; }
        [Required(ErrorMessage = "Informe a Nota 2")]
        public float? Nota2 { set; get; }

        public float Media()
        {
            return (Nota1.Value + Nota2.Value) / 2;
        }

        internal void Salvar(Conexao conexao)
        {
            conexao.Notas.Add(this);
            conexao.SaveChanges();
        }

        internal void Alterar(Conexao conexao)
        {
            conexao.Entry(this);
            conexao.SaveChanges();
        }

        internal void Remover(Conexao conexao)
        {
            conexao.Notas.Remove(this);
            conexao.SaveChanges();
        }

        internal Nota GetById(Conexao conexao, int Id)
        {
            return conexao.Notas.FirstOrDefault(x=>x.Id.Equals(Id));
        }


    }
}
