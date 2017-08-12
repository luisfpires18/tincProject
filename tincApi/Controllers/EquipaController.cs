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
    public class EquipaController : Controller
    {
        private TincContext db = new TincContext();

        // GET: Equipa
        public ActionResult Index()
        {
            return View(db.Equipa.ToList());
        }

        // GET: Equipa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipa equipa = db.Equipa.Find(id);
            if (equipa == null)
            {
                return HttpNotFound();
            }
            return View(equipa);
        }

        // GET: Equipa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Descricao,Responsavel")] Equipa equipa)
        {
            if (ModelState.IsValid)
            {
                db.Equipa.Add(equipa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equipa);
        }

        // GET: Equipa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipa equipa = db.Equipa.Find(id);
            if (equipa == null)
            {
                return HttpNotFound();
            }
            return View(equipa);
        }

        // POST: Equipa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Descricao,Responsavel")] Equipa equipa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equipa);
        }

        // GET: Equipa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipa equipa = db.Equipa.Find(id);
            if (equipa == null)
            {
                return HttpNotFound();
            }
            return View(equipa);
        }

        // POST: Equipa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipa equipa = db.Equipa.Find(id);
            db.Equipa.Remove(equipa);
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
