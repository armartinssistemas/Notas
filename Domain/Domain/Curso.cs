using Domain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain
{
    public class Curso
    {
        public int Id { set; get; }
        public string Nome { set; get; }

        public static List<Curso> Listar(Conexao conexao)
        {
            return conexao.Cursos.ToList();
        }

        public static Curso GetById(Conexao conexao, int Id)
        {
            return conexao.Cursos.FirstOrDefault(x => x.Id.Equals(Id));
        }
    }
}
