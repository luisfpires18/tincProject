using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using tincApi.DAL;
using tincApi.Models;
using tincApi.ViewModels;

namespace tincApi.Controllers
{
    public class EventoController : Controller
    {
        private TincContext db = new TincContext();

        public ActionResult Index(int? id, int? provaID, int? categoriaID)
        {
            var viewModel = new EventoData();
            viewModel.Eventos = db.Evento
                .Include(e => e.Provas)
                .OrderBy(e => e.Nome).ToList();

            if (id != null)
            {
                ViewBag.EventoID = id.Value;

                viewModel.Provas = viewModel.Eventos
                                            .Single(e => e.ID == id.Value).Provas;
            }
            if (provaID != null)
            {
                ViewBag.ProvaID = provaID.Value;
                viewModel.Categorias = viewModel.Provas
                                                .Single(p => p.ID == provaID.Value).Categorias;
            }
            if (categoriaID != null)
            {
                ViewBag.CategoriaID = categoriaID.Value;
                viewModel.Inscricoes = viewModel.Categorias
                                                .Single(c => c.ID == categoriaID.Value).Inscricoes;
            }
            return View(viewModel);
        }

        // GET: Evento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Evento.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // GET: Evento/Create
        public ActionResult Create()
        {
            ViewBag.DesportoID = new SelectList(db.Desporto.ToList(), "ID", "Nome");
            return View();
        }

        // POST: Evento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Evento.Add(evento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(evento);
        }

        // GET: Evento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Evento.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            ViewBag.DesportoID = new SelectList(db.Desporto.ToList(), "ID", "Nome");
            return View(evento);
        }

        // POST: Evento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Local,Website,DataEvento,Foto,Ficheiro,Inscricoes,Nome,Descricao,Responsavel")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(evento);
        }

        // GET: Evento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Evento.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: Evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evento evento = db.Evento.Find(id);
            db.Evento.Remove(evento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
