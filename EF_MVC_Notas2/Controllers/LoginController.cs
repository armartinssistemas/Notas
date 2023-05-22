using Domain.Domain;
using Domain.EF;
using EF_MVC_Notas2.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EF_MVC_Notas2.Controllers
{
    public class LoginController : Controller
    {
        Conexao _conexao;

        public LoginController(Conexao conexao)
        {
            _conexao = conexao;
        }

    }
}
