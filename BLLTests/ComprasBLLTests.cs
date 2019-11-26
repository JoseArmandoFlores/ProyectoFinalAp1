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
        }

        [TestMethod()]
        public void EliminarTest()
        {
            ComprasBLL Metodos = new ComprasBLL();
            Assert.IsTrue(Metodos.Eliminar(1));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            RepositorioBase<CompraProductos> Metodos = new RepositorioBase<CompraProductos>();
            CompraProductos compra = new CompraProductos();
            compra = Metodos.Buscar(1);
            Assert.IsNotNull(compra);
        }

        [TestMethod()]
        public void DisposeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<CompraProductos> Metodos = new RepositorioBase<CompraProductos>();
            var lista = new List<CompraProductos>();
            lista = Metodos.GetList(p => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void GuardarTest()
        {
            ComprasBLL Metodos = new ComprasBLL();
            CompraProductos compra = new CompraProductos();
            List<CompraProductosDetalle> detalle = new List<CompraProductosDetalle>();

            compra.CompraId = 0;
            compra.ProveedorId = 1;
            compra.UsuarioId = 1;
            compra.Fecha = DateTime.Now;
            compra.Total = 600;
            compra.ProductosDetalle = detalle;

            Assert.IsTrue(Metodos.Guardar(compra));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            ComprasBLL Metodos = new ComprasBLL();
            CompraProductos compra = new CompraProductos();
            List<CompraProductosDetalle> detalle = new List<CompraProductosDetalle>();

            compra.CompraId = 1;
            compra.ProveedorId = 1;
            compra.UsuarioId = 1;
            compra.Fecha = DateTime.Now;
            compra.Total = 600;
            compra.ProductosDetalle = detalle;

            Assert.IsTrue(Metodos.Modificar(compra));
        }
    }
}