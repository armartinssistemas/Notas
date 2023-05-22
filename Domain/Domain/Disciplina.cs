using Domain.EF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Domain.Domain
{
    public class Disciplina
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Projeto Pedagógico é obrigatório")]
        [DisplayName("Projeto Pedagógico")]
        public string ProjetoPedagogico { get; set; }

        [Required(ErrorMessage = "O campo Nome é óbrigatório")]
        public string Nome { get; set; }

        public virtual Curso Curso { get; set; }

        [Required(ErrorMessage = "O campo Curso é obrigatório")]
        [DisplayName("Curso")]
        public int? CursoId { get; set; }

        public static List<Disciplina> Listar(Conexao conexao)
        {
            return conexao.Disciplinas.ToList();
        }

        public static Disciplina GetById(Conexao conexao, int Id)
        {
            return conexao.Disciplinas.FirstOrDefault(x => x.Id.Equals(Id));
        }

        public void Salvar(Conexao conexao)
        {
            conexao.Disciplinas.Add(this);
            conexao.SaveChanges();
        }

        public void Alterar(Conexao conexao)
        {
            conexao.Entry(this);
            conexao.SaveChanges();
        }

        public void Remover(Conexao conexao)
        {
            conexao.Remove(this);
            conexao.SaveChanges();
        }
    }
}
