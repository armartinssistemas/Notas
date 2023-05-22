using Domain.Domain;
using Domain.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EF_MVC_Notas2.Controllers
{
    public class DisciplinaController : Controller
    {
        private readonly Conexao _conexao;
        public DisciplinaController(Conexao conexao)
        {
            this._conexao= conexao;
        }

        // GET: DisciplinaController
        public ActionResult Index()
        {
            List<Disciplina> disciplinas = Disciplina.Listar(_conexao);
            return View(disciplinas);
        }

        // GET: DisciplinaController/Details/5
        public ActionResult Details(int id)
        {
            Disciplina disciplina = Disciplina.GetById(_conexao,id);
            return View(disciplina);
        }

        // GET: DisciplinaController/Create
        public ActionResult Create()
        {
            ViewBag.Cursos = new SelectList(Curso.Listar(_conexao),"Id","Nome");
            return View(new Disciplina());
        }

        // POST: DisciplinaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Disciplina disciplina)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    disciplina.Salvar(_conexao);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: DisciplinaController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Cursos = new SelectList(Curso.Listar(_conexao), "Id", "Nome");
            
            Disciplina disciplina = Disciplina.GetById(_conexao, id);
            return View(disciplina);
        }

        // POST: DisciplinaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Disciplina disciplina, int IdCurso)
        {
            try
            {
                disciplina.Curso = Curso.GetById(_conexao, IdCurso);
                if (ModelState.IsValid)
                {
                    disciplina.Alterar(_conexao);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: DisciplinaController/Delete/5

        public ActionResult Delete(int Id)
        {
            Disciplina disciplina = Disciplina.GetById(_conexao,Id);
            return View(disciplina);
        }

        // POST: DisciplinaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Disciplina disciplina = Disciplina.GetById(_conexao, Id);
                    disciplina.Remover(_conexao);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }
    }
}
