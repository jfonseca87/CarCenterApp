// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace CarCenter.Domain.Models
{
    public partial class Facturas
    {
        public Facturas()
        {
            DetalleFacturas = new HashSet<DetalleFacturas>();
        }

        public int FacturaId { get; set; }
        public DateTime? FechaFactura { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? ValorIva { get; set; }
        public decimal? Total { get; set; }
        public int? ClienteId { get; set; }
        public int? SedeId { get; set; }

        public virtual Clientes Cliente { get; set; }
        public virtual Sedes Sede { get; set; }
        public virtual ICollection<DetalleFacturas> DetalleFacturas { get; set; }
    }
}