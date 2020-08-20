using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CONTABILIDAD2.Models
{
    public class Monedas
    {
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("CODIGO ISO")]
        public string codigoISO { get; set; }
        [DisplayName("Fecha de Vigencia")]
        public DateTime fechaVigencia { get; set; }
        [DisplayName("Tasa de Cambio")]
        public double tasaCambio { get; set; }
    }
}