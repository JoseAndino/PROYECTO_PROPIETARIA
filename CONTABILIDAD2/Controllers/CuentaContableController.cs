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
    public class CuentaContableController : Controller
    {
        private CONTABILIDAD2Entities db = new CONTABILIDAD2Entities();

        // GET: CuentaContable
        public ActionResult Index()
        {
            var cuenta_contable = db.cuenta_contable.Include(c => c.tipo_cuenta);
            return View(cuenta_contable.ToList());
        }

        // GET: CuentaContable/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuenta_contable cuenta_contable = db.cuenta_contable.Find(id);
            if (cuenta_contable == null)
            {
                return HttpNotFound();
            }
            return View(cuenta_contable);
        }

        // GET: CuentaContable/Create
        public ActionResult Create()
        {
            ViewBag.tipo_cuenta_id = new SelectList(db.tipo_cuenta, "id", "descripcion");
            return View();
        }

        // POST: CuentaContable/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion,permite_transaccion,tipo_cuenta_id,nivel,cuenta_mayor,balance,estado")] cuenta_contable cuenta_contable)
        {
            if (ModelState.IsValid)
            {
                db.cuenta_contable.Add(cuenta_contable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tipo_cuenta_id = new SelectList(db.tipo_cuenta, "id", "descripcion", cuenta_contable.tipo_cuenta_id);
            return View(cuenta_contable);
        }

        // GET: CuentaContable/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuenta_contable cuenta_contable = db.cuenta_contable.Find(id);
            if (cuenta_contable == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipo_cuenta_id = new SelectList(db.tipo_cuenta, "id", "descripcion", cuenta_contable.tipo_cuenta_id);
            return View(cuenta_contable);
        }

        // POST: CuentaContable/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion,permite_transaccion,tipo_cuenta_id,nivel,cuenta_mayor,balance,estado")] cuenta_contable cuenta_contable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuenta_contable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tipo_cuenta_id = new SelectList(db.tipo_cuenta, "id", "descripcion", cuenta_contable.tipo_cuenta_id);
            return View(cuenta_contable);
        }

        // GET: CuentaContable/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuenta_contable cuenta_contable = db.cuenta_contable.Find(id);
            if (cuenta_contable == null)
            {
                return HttpNotFound();
            }
            return View(cuenta_contable);
        }

        // POST: CuentaContable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cuenta_contable cuenta_contable = db.cuenta_contable.Find(id);
            db.cuenta_contable.Remove(cuenta_contable);
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
