//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CONTABILIDAD2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class auxiliarr
    {
        [Display(Name = "ID")]
        public int id { get; set; }
        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }
        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}
