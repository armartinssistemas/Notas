using Domain.Domain;
using Domain.EF;
using Microsoft.AspNetCore.Http;
using System;

namespace EF_MVC_Notas2.Util
{
    public class ControllSession
    {
        private HttpContext _httpContext;

        public ControllSession(HttpContext httpContext)
        {
            _httpContext = httpContext;
        }
        public void SetUsuarioLogado(Usuario usuario)
        {
            _httpContext.Session.SetString("IdUsuario", usuario.Id.ToString());
        }  
        
        public Usuario GetUsuarioLogado(Conexao conexao)
        {
            string IdUsuario = _httpContext.Session.GetString("IdUsuario");
            if (IdUsuario == null || IdUsuario.Equals(""))
            {
                return null;
            }
            else
            {
                return Usuario.GetById(conexao, Convert.ToInt32(IdUsuario));
            }
        }
    }
}
