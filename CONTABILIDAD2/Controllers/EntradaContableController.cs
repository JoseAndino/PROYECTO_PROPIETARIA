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
    public class EntradaContableController : Controller
    {
        private CONTABILIDAD2Entities db = new CONTABILIDAD2Entities();

        // GET: EntradaContable
        public ActionResult Index()
        {
            return View(db.entrada_contable.ToList());
        }

        // GET: EntradaContable/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            entrada_contable entrada_contable = db.entrada_contable.Find(id);
            if (entrada_contable == null)
            {
                return HttpNotFound();
            }
            return View(entrada_contable);
        }

        // GET: EntradaContable/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EntradaContable/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion,auxiliar_id,moneda_id,estado")] entrada_contable entrada_contable)
        {
            if (ModelState.IsValid)
            {
                db.entrada_contable.Add(entrada_contable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entrada_contable);
        }

        // GET: EntradaContable/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            entrada_contable entrada_contable = db.entrada_contable.Find(id);
            if (entrada_contable == null)
            {
                return HttpNotFound();
            }
            return View(entrada_contable);
        }

        // POST: EntradaContable/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion,auxiliar_id,moneda_id,estado")] entrada_contable entrada_contable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrada_contable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entrada_contable);
        }

        // GET: EntradaContable/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            entrada_contable entrada_contable = db.entrada_contable.Find(id);
            if (entrada_contable == null)
            {
                return HttpNotFound();
            }
            return View(entrada_contable);
        }

        // POST: EntradaContable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            entrada_contable entrada_contable = db.entrada_contable.Find(id);
            db.entrada_contable.Remove(entrada_contable);
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
