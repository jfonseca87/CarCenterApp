// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace CarCenter.Domain.Models
{
    public partial class DetalleFacturas
    {
        public int DetalleFacturaId { get; set; }
        public int? ProductoId { get; set; }
        public int? Cantidad { get; set; }
        public decimal? TotalDetalle { get; set; }
        public int? FacturaId { get; set; }

        public virtual Facturas Factura { get; set; }
        public virtual Productos Producto { get; set; }
    }
}