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
    public class MonedaController : Controller
    {
        private CONTABILIDAD2Entities db = new CONTABILIDAD2Entities();

        // GET: Moneda
        public ActionResult Index()
        {
            return View(db.monedaa.ToList());
        }

        // GET: Moneda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            monedaa monedaa = db.monedaa.Find(id);
            if (monedaa == null)
            {
                return HttpNotFound();
            }
            return View(monedaa);
        }

        // GET: Moneda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Moneda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion,tasa,estado")] monedaa monedaa)
        {
            if (ModelState.IsValid)
            {
                db.monedaa.Add(monedaa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(monedaa);
        }

        // GET: Moneda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            monedaa monedaa = db.monedaa.Find(id);
            if (monedaa == null)
            {
                return HttpNotFound();
            }
            return View(monedaa);
        }

        // POST: Moneda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion,tasa,estado")] monedaa monedaa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monedaa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monedaa);
        }

        // GET: Moneda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            monedaa monedaa = db.monedaa.Find(id);
            if (monedaa == null)
            {
                return HttpNotFound();
            }
            return View(monedaa);
        }

        // POST: Moneda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            monedaa monedaa = db.monedaa.Find(id);
            db.monedaa.Remove(monedaa);
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
