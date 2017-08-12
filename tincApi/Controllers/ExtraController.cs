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
    public class ExtraController : Controller
    {
        private TincContext db = new TincContext();

        // GET: Extra
        public ActionResult Index()
        {
            return View(db.Extra.ToList());
        }

        // GET: Extra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Extra extra = db.Extra.Find(id);
            if (extra == null)
            {
                return HttpNotFound();
            }
            return View(extra);
        }

        // GET: Extra/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Extra/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Preco,Nome,Descricao,Responsavel")] Extra extra)
        {
            if (ModelState.IsValid)
            {
                db.Extra.Add(extra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(extra);
        }

        // GET: Extra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Extra extra = db.Extra.Find(id);
            if (extra == null)
            {
                return HttpNotFound();
            }
            return View(extra);
        }

        // POST: Extra/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Preco,Nome,Descricao,Responsavel")] Extra extra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(extra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(extra);
        }

        // GET: Extra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Extra extra = db.Extra.Find(id);
            if (extra == null)
            {
                return HttpNotFound();
            }
            return View(extra);
        }

        // POST: Extra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Extra extra = db.Extra.Find(id);
            db.Extra.Remove(extra);
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
