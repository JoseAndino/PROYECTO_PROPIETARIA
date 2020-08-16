
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
    public class TipoCuentaController : Controller
    {
        private CONTABILIDAD2Entities db = new CONTABILIDAD2Entities();

        // GET: TipoCuenta
        public ActionResult Index()
        {
            return View(db.tipo_cuenta.ToList());
        }

        // GET: TipoCuenta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_cuenta tipo_cuenta = db.tipo_cuenta.Find(id);
            if (tipo_cuenta == null)
            {
                return HttpNotFound();
            }
            return View(tipo_cuenta);
        }

        // GET: TipoCuenta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoCuenta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion,origen,estado")] tipo_cuenta tipo_cuenta)
        {
            if (ModelState.IsValid)
            {
                db.tipo_cuenta.Add(tipo_cuenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_cuenta);
        }

        // GET: TipoCuenta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_cuenta tipo_cuenta = db.tipo_cuenta.Find(id);
            if (tipo_cuenta == null)
            {
                return HttpNotFound();
            }
            return View(tipo_cuenta);
        }

        // POST: TipoCuenta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion,origen,estado")] tipo_cuenta tipo_cuenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_cuenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_cuenta);
        }

        // GET: TipoCuenta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_cuenta tipo_cuenta = db.tipo_cuenta.Find(id);
            if (tipo_cuenta == null)
            {
                return HttpNotFound();
            }
            return View(tipo_cuenta);
        }

        // POST: TipoCuenta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_cuenta tipo_cuenta = db.tipo_cuenta.Find(id);
            db.tipo_cuenta.Remove(tipo_cuenta);
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
