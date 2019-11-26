using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class CompraProductos
    {
        [Key]
        public int CompraId { get; set; }
        public int ProveedorId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public virtual List<CompraProductosDetalle> ProductosDetalle { get; set; }

        public CompraProductos()
        {
            CompraId = 0;
            Fecha = DateTime.Now;
            ProveedorId = 0;
            UsuarioId = 0;
            Total = 0;
            ProductosDetalle = new List<CompraProductosDetalle>();
        }

        public CompraProductos(int compraId, int proveedorId, int usuarioId, DateTime fecha, decimal total, List<CompraProductosDetalle> productosDetalle)
        {
            CompraId = compraId;
            ProveedorId = proveedorId;
            UsuarioId = usuarioId;
            Fecha = fecha;
            Total = total;
            ProductosDetalle = productosDetalle;
        }
    }
}
