using ProyectoFinal.DAL;
using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.BLL
{
    public class ProductosBLL
    {
        public static List<Productos> GetProductosEnReorden()
        {
            Contexto db = new Contexto();
            List<Productos> Lista = new List<Productos>();

            Lista = db.Producto.AsNoTracking().Where(p => p.CantidadExistente == p.CantidadMinima).ToList();
            return Lista;
        }
    }
}
