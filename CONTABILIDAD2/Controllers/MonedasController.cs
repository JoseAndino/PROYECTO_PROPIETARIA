using CONTABILIDAD2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CONTABILIDAD2.Controllers
{
    public class MonedasController : Controller
    {

        MonedaModel model;
        public MonedasController()
        {
            this.model = new MonedaModel();
        }

        // GET: Contacts
        [AsyncTimeout(1000)]
        public async Task<ActionResult> Index()
        {
            List<Monedas> cList = await model.GetMonedas();
            return View(cList);
        }
   
    }
}