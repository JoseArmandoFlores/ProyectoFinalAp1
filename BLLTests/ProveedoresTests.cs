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
    public class ProveedoresBLLTests
    {
        [TestMethod()]
        public void RepositorioBaseTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarTest()
        {
            RepositorioBase<Proveedores> Metodos = new RepositorioBase<Proveedores>();
            Proveedores proveedor = new Proveedores();
            proveedor = Metodos.Buscar(2);
            Assert.IsNotNull(proveedor);
        }

        [TestMethod()]
        public void DisposeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarTest()
        {
            RepositorioBase<Proveedores> Metodos = new RepositorioBase<Proveedores>();
            Assert.IsTrue(Metodos.Eliminar(2));
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Proveedores> Metodos = new RepositorioBase<Proveedores>();
            var lista = new List<Proveedores>();
            lista = Metodos.GetList(p => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void GuardarTest()
        {
            RepositorioBase<Proveedores> Metodos = new RepositorioBase<Proveedores>();

            Proveedores proveedor = new Proveedores();
            proveedor.ProveedorId = 0;
            proveedor.UsuarioId = 1;
            proveedor.Nombres = "Pedro William";
            proveedor.Apellidos = "Ramos Then";
            proveedor.Telefono = "809-290-8910";
            proveedor.Celular = "829-690-2801";
            proveedor.Rnc = "809556";
            proveedor.Email = "ramosthen@gmail.com";
            proveedor.Direccion = "Bomba de Cenovi, SFM";

            Assert.IsTrue(Metodos.Guardar(proveedor));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            RepositorioBase<Proveedores> Metodos = new RepositorioBase<Proveedores>();

            Proveedores proveedor = new Proveedores();
            proveedor.ProveedorId = 2;
            proveedor.UsuarioId = 1;
            proveedor.Nombres = "Pedro William";
            proveedor.Apellidos = "Ramos Then";
            proveedor.Telefono = "809-290-8910";
            proveedor.Celular = "829-690-2801";
            proveedor.Rnc = "809556";
            proveedor.Email = "ramosthen@gmail.com";
            proveedor.Direccion = "Bomba de Cenovi, SFM";

            Assert.IsTrue(Metodos.Modificar(proveedor));
        }
    }
}