using CONTABILIDAD2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CONTABILIDAD2.Controllers
{
    public class CuentasContablesController : Controller
    {
        // GET: CuentasContables
        CuentaContableModel model;
        public CuentasContablesController()
        {
            this.model = new CuentaContableModel();
        }

        // GET: Contacts
        [AsyncTimeout(1000)]
        public async Task<ActionResult> Index()
        {
            CuentaContable cuenta = await model.GetEntradaContables();
            return View(cuenta);
        }

       
    }
}