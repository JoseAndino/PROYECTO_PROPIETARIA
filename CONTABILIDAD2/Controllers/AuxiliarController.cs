using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CONTABILIDAD2;

namespace CONTABILIDAD2.Controllers
{
    public class AuxiliarController : Controller
    {
        private CONTABILIDAD2Entities db = new CONTABILIDAD2Entities();

        // GET: Auxiliar
        public ActionResult Index()
        {
            return View(db.auxiliarr.ToList());
        }
    
        // GET: Auxiliar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auxiliarr auxiliarr = db.auxiliarr.Find(id);
            if (auxiliarr == null)
            {
                return HttpNotFound();
            }
            return View(auxiliarr);
        }

        // GET: Auxiliar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auxiliar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion,estado")] auxiliarr auxiliarr)
        {
            if (ModelState.IsValid)
            {
                db.auxiliarr.Add(auxiliarr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(auxiliarr);
        }

        // GET: Auxiliar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auxiliarr auxiliarr = db.auxiliarr.Find(id);
            if (auxiliarr == null)
            {
                return HttpNotFound();
            }
            return View(auxiliarr);
        }

        // POST: Auxiliar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion,estado")] auxiliarr auxiliarr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auxiliarr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auxiliarr);
        }

        // GET: Auxiliar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auxiliarr auxiliarr = db.auxiliarr.Find(id);
            if (auxiliarr == null)
            {
                return HttpNotFound();
            }
            return View(auxiliarr);
        }

        // POST: Auxiliar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            auxiliarr auxiliarr = db.auxiliarr.Find(id);
            db.auxiliarr.Remove(auxiliarr);
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
