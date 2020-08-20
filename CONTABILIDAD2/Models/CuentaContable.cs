using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CONTABILIDAD2.Models
{
    public class DetalleEntradaContable
    {
        public int cuentaContableId { get; set; }
        public string descripcion { get; set; }
        public string tipoMovimiento { get; set; }
        public double monto { get; set; }
    }
    public class CuentaContable
    {
       
        [DisplayName ("ID")]
        public int auxiliarId { get; set; }
        [DisplayName ("Descripcion")]
        public string descripcion { get; set; }
        [DisplayName("ID de la Moneda")]
        public int monedaId { get; set; }
        [DisplayName("Monto")]
        public double monto { get; set; }
        public List<DetalleEntradaContable> detalleEntradaContable { get; set; }
    }
}