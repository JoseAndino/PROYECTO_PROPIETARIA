using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace CONTABILIDAD2.Models
{
    public class CuentaContableModel
    {
        private String UriApi;
        MediaTypeWithQualityHeaderValue mediaheader;

        public CuentaContableModel()
        {
            //this.UriApi = "https://localhost:44376/"; // Local API
            this.UriApi = "http://intcontabilidad.azurewebsites.net/"; // Azure API
            this.mediaheader = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
        }
        public async Task<CuentaContable> GetEntradaContables()
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/EntradaContables/dummy";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    CuentaContable cuenta = await respuesta.Content.ReadAsAsync <CuentaContable> ();
                    return cuenta;
                }
                else { return null; }
            }
        }
    }
}