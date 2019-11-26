using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal.BLL;
using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.BLL.Tests
{
    [TestClass()]
    public class ComprasBLLTests
    {
        [TestMethod()]
        public void AgregarCantidadTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ModificarTest()
        {
            ComprasBLL Metodos = new ComprasBLL();
            CompraProductos compra = new CompraProductos();
            List<CompraProductosDetalle> detalle = new List<CompraProductosDetalle>();

            compra.CompraId = 3;
            compra.ProveedorId = 1;
            compra.UsuarioId = 1;
            compra.Fecha = DateTime.Now;
            compra.Total = 500;
            compra.ProductosDetalle = detalle;

            Assert.IsTrue(Metodos.Modificar(compra));
        }

        [TestMethod()]
        public void EliminarTest()
        {
            ComprasBLL Metodos = new ComprasBLL();
            Assert.IsTrue(Metodos.Eliminar(2));
        }
    }
}