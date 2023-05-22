using Domain.Domain;
using Domain.EF;
using EF_MVC_Notas2.Models;
using EF_MVC_Notas2.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EF_MVC_Notas2.Controllers
{
    public class HomeController : Controller
    {
        private readonly Conexao _conexao;

        public HomeController(Conexao conexao)
        {
            _conexao = conexao;
        }
        public IActionResult Index(Usuario usuario)
        {
            return View();
        }

        public IActionResult Logar(Usuario usuarioParam)
        {
            if (usuarioParam.Login == null || usuarioParam.Login.Trim().Equals(""))
            {
                ModelState.AddModelError("Login", "Informe o Campo Login");
            }
            if (usuarioParam.Senha == null || usuarioParam.Senha.Trim().Equals(""))
            {
                ModelState.AddModelError("Senha", "Informe o Campo Senha");
            }
            if (ModelState.IsValid)
            {
                Usuario usuario = Usuario.Logar(_conexao, usuarioParam.Login, usuarioParam.Senha);
                if (usuario != null)
                {
                    Pessoa pessoa = usuario.GetPessoa(_conexao);
                    if (pessoa.Professor)
                    {
                        ControllSession cs = new ControllSession(HttpContext);
                        cs.SetUsuarioLogado(usuario);
                        return RedirectToAction("Index", "Principal");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Usuário não encontrado!");
                        return View("Index", new Usuario());
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Usuário não encontrado!");
                    return View("Index", new Usuario());
                }
            }
            else
            {
                return View("Index", new Usuario());
            }
        }
    }
}
