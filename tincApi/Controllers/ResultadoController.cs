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
    public class ResultadoController : Controller
    {
        private TincContext db = new TincContext();

        // GET: Resultado
        public ActionResult Index()
        {
            return View(db.Resultado.ToList());
        }

        // GET: Resultado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultado resultado = db.Resultado.Find(id);
            if (resultado == null)
            {
                return HttpNotFound();
            }
            return View(resultado);
        }

        // GET: Resultado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resultado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Descricao,Responsavel")] Resultado resultado)
        {
            if (ModelState.IsValid)
            {
                db.Resultado.Add(resultado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resultado);
        }

        // GET: Resultado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultado resultado = db.Resultado.Find(id);
            if (resultado == null)
            {
                return HttpNotFound();
            }
            return View(resultado);
        }

        // POST: Resultado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Descricao,Responsavel")] Resultado resultado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resultado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resultado);
        }

        // GET: Resultado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultado resultado = db.Resultado.Find(id);
            if (resultado == null)
            {
                return HttpNotFound();
            }
            return View(resultado);
        }

        // POST: Resultado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resultado resultado = db.Resultado.Find(id);
            db.Resultado.Remove(resultado);
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
