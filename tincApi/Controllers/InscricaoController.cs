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

namespace tincApi.Controllers
{
    public class InscricaoController : Controller
    {
        private TincContext db = new TincContext();

        // GET: Inscricao
        public ActionResult Index(int? CategoriaID)
        {
            if (CategoriaID != null)
            {
                var inscricao = db.Inscricao
                    .Include(i => i.Categoria)
                    .Include(i => i.Pessoa)
                    .Where(i => i.CategoriaID == CategoriaID);

                return View(inscricao.ToList());
            }
            else
            {
                var inscricao = db.Inscricao.Include(i => i.Categoria).Include(i => i.Pessoa);
                return View(inscricao.ToList());
            }

            
        }

        // GET: Inscricao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscricao inscricao = db.Inscricao.Find(id);
            if (inscricao == null)
            {
                return HttpNotFound();
            }
            return View(inscricao);
        }

        // GET: Inscricao/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categoria, "ID", "Nome");
            ViewBag.PessoaID = new SelectList(db.Pessoa, "ID", "Nome");
            return View();
        }

        // POST: Inscricao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inscricao inscricao)
        {
            inscricao.DataInscricao = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Inscricao.Add(inscricao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categoria, "ID", "Nome", inscricao.CategoriaID);
            ViewBag.PessoaID = new SelectList(db.Pessoa, "ID", "Nome", inscricao.PessoaID);
            return View(inscricao);
        }

        // GET: Inscricao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscricao inscricao = db.Inscricao.Find(id);
            if (inscricao == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categoria, "ID", "Nome", inscricao.CategoriaID);
            ViewBag.PessoaID = new SelectList(db.Pessoa, "ID", "Nome", inscricao.PessoaID);
            return View(inscricao);
        }

        // POST: Inscricao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Tamanho,DataInscricao,RegistadoPor,Estado,Notas,CategoriaID,PessoaID")] Inscricao inscricao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscricao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categoria, "ID", "Nome", inscricao.CategoriaID);
            ViewBag.PessoaID = new SelectList(db.Pessoa, "ID", "Nome", inscricao.PessoaID);
            return View(inscricao);
        }

        // GET: Inscricao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscricao inscricao = db.Inscricao.Find(id);
            if (inscricao == null)
            {
                return HttpNotFound();
            }
            return View(inscricao);
        }

        // POST: Inscricao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inscricao inscricao = db.Inscricao.Find(id);
            db.Inscricao.Remove(inscricao);
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
