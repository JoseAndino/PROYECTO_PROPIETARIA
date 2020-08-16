using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CONTABILIDAD2.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CONTABILIDAD2.Controllers
{

    public class EntradaContablesController : Controller
    {

        string Baseurl = "http://intcontabilidad.azurewebsites.net/";
        // GET: EntradaContables
        public async Task<ActionResult> Index()
        {
            List<EntradaContable> EntradaContables = new List<EntradaContable>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //llamada todos las entradas contables usando el HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/EntradaContables/dummy");
                if (Res.IsSuccessStatusCode)
                {
                    //Si Res= true entra y asigna los datos
                    var EntradaResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializar el api y almacena los datos

                     EntradaContables = JsonConvert.DeserializeObject<List<EntradaContable>>(EntradaResponse);

                }
                //Muestra la lista de todos las entradas contables

            }
            return View(EntradaContables);


           
        }
    }
}