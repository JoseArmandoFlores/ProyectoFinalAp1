using ProyectoFinal.DAL;
using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.BLL
{
    public class ComprasBLL : RepositorioBase<CompraProductos>
    {
        public void AgregarCantidad(int cantidad, int id)
        {
            RepositorioBase<Productos> Metodos = new RepositorioBase<Productos>();

            Productos productos = Metodos.Buscar(id);
            productos.CantidadExistente += cantidad;

            Metodos.Modificar(productos);
        }

        public override bool Modificar(CompraProductos compra)
        {            
            foreach (var item in compra.ProductosDetalle)
            {
                var producto = db.Producto.Find(item.ProductoId);

                if (item.Id == 0)
                {
                    db.Entry(item).State = EntityState.Added;
                    if (producto != null)
                    {
                        producto.CantidadExistente += item.Cantidad;
                    }
                }
                else
                {
                    db.Entry(item).State = EntityState.Modified;
                }
            }
            bool paso = base.Modificar(compra);
            return paso;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<CompraProductos> Metodos = new RepositorioBase<CompraProductos>();
            try
            {
                var Anterior = Metodos.Buscar(id);
                foreach (var item in Anterior.ProductosDetalle)
                {
                    var Producto = db.Producto.Find(item.ProductoId);
                    if (Producto != null)
                        Producto.CantidadExistente -= item.Cantidad;
                }

                var eliminar = db.CompraProducto.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
    }
}
