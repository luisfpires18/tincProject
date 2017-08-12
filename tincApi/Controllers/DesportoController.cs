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
    public class DesportoController : Controller
    {
        private TincContext db = new TincContext();

        // GET: Desporto
        public ActionResult Index()
        {
            return View(db.Desporto.ToList());
        }

        // GET: Desporto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desporto desporto = db.Desporto.Find(id);
            if (desporto == null)
            {
                return HttpNotFound();
            }
            return View(desporto);
        }

        // GET: Desporto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Desporto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Descricao,Responsavel")] Desporto desporto)
        {
            if (ModelState.IsValid)
            {
                db.Desporto.Add(desporto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(desporto);
        }

        // GET: Desporto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desporto desporto = db.Desporto.Find(id);
            if (desporto == null)
            {
                return HttpNotFound();
            }
            return View(desporto);
        }

        // POST: Desporto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Descricao,Responsavel")] Desporto desporto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(desporto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(desporto);
        }

        // GET: Desporto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desporto desporto = db.Desporto.Find(id);
            if (desporto == null)
            {
                return HttpNotFound();
            }
            return View(desporto);
        }

        // POST: Desporto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Desporto desporto = db.Desporto.Find(id);
            db.Desporto.Remove(desporto);
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
