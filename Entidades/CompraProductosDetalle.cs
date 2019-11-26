using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class CompraProductosDetalle
    {
        [Key]
        public int Id { get; set; }
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public CompraProductosDetalle()
        {
        }

        public CompraProductosDetalle(int id, int compraId, int productoId, int cantidad, decimal precio)
        {
            Id = id;
            CompraId = compraId;
            ProductoId = productoId;
            Cantidad = cantidad;
            Precio = precio;
        }
    }
}
