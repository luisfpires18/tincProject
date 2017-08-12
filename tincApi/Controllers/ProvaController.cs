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
    public class ProvaController : Controller
    {
        private TincContext db = new TincContext();

        // GET: Prova
        public ActionResult Index()
        {
            return View(db.Prova.ToList());
        }

        // GET: Prova/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prova prova = db.Prova.Find(id);
            if (prova == null)
            {
                return HttpNotFound();
            }
            return View(prova);
        }

        // GET: Prova/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prova/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Distancia,Preco,Nome,Descricao,Responsavel")] Prova prova)
        {
            if (ModelState.IsValid)
            {
                db.Prova.Add(prova);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prova);
        }

        // GET: Prova/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prova prova = db.Prova.Find(id);
            if (prova == null)
            {
                return HttpNotFound();
            }
            return View(prova);
        }

        // POST: Prova/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Distancia,Preco,Nome,Descricao,Responsavel")] Prova prova)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prova).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prova);
        }

        // GET: Prova/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prova prova = db.Prova.Find(id);
            if (prova == null)
            {
                return HttpNotFound();
            }
            return View(prova);
        }

        // POST: Prova/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prova prova = db.Prova.Find(id);
            db.Prova.Remove(prova);
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
