using Domain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public static Usuario Logar(Conexao context, string login, string senha)
        {
            Usuario usuario =
            context.Usuarios.Where(linha =>
                linha.Login.Equals(login) && linha.Senha.Equals(senha)).
                FirstOrDefault();
            
            return usuario;
        }

        public static Usuario GetById(Conexao conexao, int id)
        {
            return conexao.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public Pessoa GetPessoa(Conexao conexao)
        {
            return conexao.Pessoas.FirstOrDefault(x=>x.Usuario.Id.Equals(Id));
        }
    }
}
