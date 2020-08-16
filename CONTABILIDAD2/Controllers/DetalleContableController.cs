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
    public class DetalleContableController : Controller
    {
        private CONTABILIDAD2Entities db = new CONTABILIDAD2Entities();

        // GET: DetalleContable
        public ActionResult Index()
        {
            var detalle_entrada_contable = db.detalle_entrada_contable.Include(d => d.cuenta_contable).Include(d => d.entrada_contable);
            return View(detalle_entrada_contable.ToList());
        }

        // GET: DetalleContable/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_entrada_contable detalle_entrada_contable = db.detalle_entrada_contable.Find(id);
            if (detalle_entrada_contable == null)
            {
                return HttpNotFound();
            }
            return View(detalle_entrada_contable);
        }

        // GET: DetalleContable/Create
        public ActionResult Create()
        {
            ViewBag.cuenta_contable_id = new SelectList(db.cuenta_contable, "id", "descripcion");
            ViewBag.entrada_contable_id = new SelectList(db.entrada_contable, "id", "descripcion");
            return View();
        }

        // POST: DetalleContable/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,entrada_contable_id,cuenta_contable_id,tipo_movimiento,monto,estado")] detalle_entrada_contable detalle_entrada_contable)
        {
            if (ModelState.IsValid)
            {
                db.detalle_entrada_contable.Add(detalle_entrada_contable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cuenta_contable_id = new SelectList(db.cuenta_contable, "id", "descripcion", detalle_entrada_contable.cuenta_contable_id);
            ViewBag.entrada_contable_id = new SelectList(db.entrada_contable, "id", "descripcion", detalle_entrada_contable.entrada_contable_id);
            return View(detalle_entrada_contable);
        }

        // GET: DetalleContable/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_entrada_contable detalle_entrada_contable = db.detalle_entrada_contable.Find(id);
            if (detalle_entrada_contable == null)
            {
                return HttpNotFound();
            }
            ViewBag.cuenta_contable_id = new SelectList(db.cuenta_contable, "id", "descripcion", detalle_entrada_contable.cuenta_contable_id);
            ViewBag.entrada_contable_id = new SelectList(db.entrada_contable, "id", "descripcion", detalle_entrada_contable.entrada_contable_id);
            return View(detalle_entrada_contable);
        }

        // POST: DetalleContable/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,entrada_contable_id,cuenta_contable_id,tipo_movimiento,monto,estado")] detalle_entrada_contable detalle_entrada_contable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_entrada_contable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cuenta_contable_id = new SelectList(db.cuenta_contable, "id", "descripcion", detalle_entrada_contable.cuenta_contable_id);
            ViewBag.entrada_contable_id = new SelectList(db.entrada_contable, "id", "descripcion", detalle_entrada_contable.entrada_contable_id);
            return View(detalle_entrada_contable);
        }

        // GET: DetalleContable/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_entrada_contable detalle_entrada_contable = db.detalle_entrada_contable.Find(id);
            if (detalle_entrada_contable == null)
            {
                return HttpNotFound();
            }
            return View(detalle_entrada_contable);
        }

        // POST: DetalleContable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            detalle_entrada_contable detalle_entrada_contable = db.detalle_entrada_contable.Find(id);
            db.detalle_entrada_contable.Remove(detalle_entrada_contable);
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
