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
    public class ProductosBLLTests
    {
        [TestMethod()]
        public void GetProductosEnReordenTest()
        {
            var lista = new List<Productos>();
            lista = ProductosBLL.GetProductosEnReorden();
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            RepositorioBase<Productos> Metodos = new RepositorioBase<Productos>();
            Productos producto = new Productos();
            producto = Metodos.Buscar(1);
            Assert.IsNotNull(producto);
        }

        [TestMethod()]
        public void DisposeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarTest()
        {
            RepositorioBase<Productos> Metodos = new RepositorioBase<Productos>();
            Assert.IsTrue(Metodos.Eliminar(1));
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Productos> Metodos = new RepositorioBase<Productos>();
            var lista = new List<Productos>();
            lista = Metodos.GetList(p => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void GuardarTest()
        {
            RepositorioBase<Productos> Metodos = new RepositorioBase<Productos>();

            Productos producto = new Productos();
            producto.ProductoId = 0;
            producto.Nombre = "Arroz";
            producto.Marca = "Yocahu";
            producto.UnidadMedida = "Saco 100 Lbs";
            producto.CantidadMinima = 20;
            producto.CantidadExistente = 60;
            producto.Precio = 400;
            producto.Costo = 380;

            Assert.IsTrue(Metodos.Guardar(producto));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            RepositorioBase<Productos> Metodos = new RepositorioBase<Productos>();

            Productos producto = new Productos();
            producto.ProductoId = 1;
            producto.Nombre = "Arroz";
            producto.Marca = "Yocahu";
            producto.UnidadMedida = "Saco 100 Lbs";
            producto.CantidadMinima = 20;
            producto.CantidadExistente = 65;
            producto.Precio = 400;
            producto.Costo = 380;

            Assert.IsTrue(Metodos.Modificar(producto));
        }
    }
}