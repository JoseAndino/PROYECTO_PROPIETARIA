using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CONTABILIDAD2.Models
{
    public class EntradaContable
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }
        public double monto { get; set; }
        public int auxiliarId { get; set; }
        public int monedaId { get; set; }
        public bool estado { get; set; }
    }
}