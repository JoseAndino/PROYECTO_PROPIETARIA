using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;


namespace CONTABILIDAD2.Models
{
    public class MonedaModel
    {

        private String UriApi;
        MediaTypeWithQualityHeaderValue mediaheader;

        public MonedaModel()
        {
            //this.UriApi = "https://localhost:44351/"; // Local API
            this.UriApi = "https://publicws.azurewebsites.net/"; // Azure API
            this.mediaheader = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
        }
        public async Task<List<Monedas>> GetMonedas()
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Monedas";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    List<Monedas> cList = await respuesta.Content.ReadAsAsync<List<Monedas>>();
                    return cList;
                }
                else { return null; }
            }
        }
    }
}