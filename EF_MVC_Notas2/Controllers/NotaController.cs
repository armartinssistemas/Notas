using Domain.Domain;
using Domain.EF;
using EF_MVC_Notas2.Util;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EF_MVC_Notas2.Controllers
{
    public class NotaController : Controller
    {
        private Conexao _conexao;

        public NotaController(Conexao conexao)
        {
            _conexao = conexao;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ControllSession cs = new ControllSession(HttpContext);
            ViewBag.Professor = cs.GetUsuarioLogado(_conexao).GetPessoa(_conexao);
            ViewBag.Disciplinas = Disciplina.Listar(_conexao);
            return View("Disciplina");
        }

        [HttpPost]
        public IActionResult Alunos(int IdDisciplina)
        {
            ViewBag.IdDisciplina = IdDisciplina;
            ViewBag.NomeDisciplina = Disciplina.GetById(_conexao, IdDisciplina).Nome;

            ControllSession cs = new ControllSession(HttpContext);
            ViewBag.Professor = cs.GetUsuarioLogado(_conexao).GetPessoa(_conexao);

            int ano = DateTime.Now.Year;
            int semestre = (DateTime.Now.Month <= 6 ? 1 : 2);
            ViewBag.Matriculas = Matricula.Listar(_conexao, ano, semestre, IdDisciplina);

            return View();
        }

        [HttpGet]
        public IActionResult Nota(int IdMatricula)
        {
            ViewBag.Matricula = Matricula.GetById(_conexao,IdMatricula);
            return View();
        }

        [HttpPost]
        public IActionResult Salvar(int IdProfessor, int IdMatricula, float? Nota1, float? Nota2)
        {
            if (Nota1 == null)
            {
                ModelState.AddModelError("Nota1", "Informe a Nota 1");
            }
            if (Nota2 == null)
            {
                ModelState.AddModelError("Nota2", "Informe a Nota 2");
            }
            if (ModelState.IsValid)
            {
                Pessoa professor = Pessoa.GetById(_conexao, IdProfessor);
                Matricula matricula = Matricula.GetById(_conexao, IdMatricula);
                matricula.SetNota(_conexao, Nota1.Value, Nota2.Value);

                ViewBag.IdDisciplina = matricula.Disciplina.Id;
                ViewBag.NomeDisciplina = Disciplina.GetById(_conexao, matricula.Disciplina.Id).Nome;

                ControllSession cs = new ControllSession(HttpContext);
                ViewBag.Professor = cs.GetUsuarioLogado(_conexao).GetPessoa(_conexao);

                int ano = DateTime.Now.Year;
                int semestre = (DateTime.Now.Month <= 6 ? 1 : 2);
                ViewBag.Matriculas = Matricula.Listar(_conexao, ano, semestre, matricula.Disciplina.Id);
                return View("Alunos");
            }
            else
            {
                ViewBag.Matricula = Matricula.GetById(_conexao, IdMatricula);
                return View("Nota");
            }

            
        }
    }
}
