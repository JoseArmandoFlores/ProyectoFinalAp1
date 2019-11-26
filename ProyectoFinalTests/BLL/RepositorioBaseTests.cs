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
    public class RepositorioBaseTests
    {
        [TestMethod()]
        public void RepositorioBaseTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarTest()
        {
            RepositorioBase<Usuarios> Metodos = new RepositorioBase<Usuarios>();
            Usuarios usuario = new Usuarios();
            usuario = Metodos.Buscar(3);
            Assert.IsNotNull(usuario);
        }

        [TestMethod()]
        public void DisposeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarTest()
        {
            RepositorioBase<Usuarios> Metodos = new RepositorioBase<Usuarios>();
            Assert.IsTrue(Metodos.Eliminar(3));
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Usuarios> Metodos = new RepositorioBase<Usuarios>();
            var lista = new List<Usuarios>();
            lista = Metodos.GetList(p => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void GuardarTest()
        {
            RepositorioBase<Usuarios> Metodos = new RepositorioBase<Usuarios>();

            Usuarios usuario = new Usuarios();
            usuario.UsuarioId = 0;
            usuario.NombreUsuario = "Pedro";
            usuario.Contrasena = "pedro123";
            usuario.Nombres = "Pedro William";
            usuario.Apellidos = "Ramos Then";
            usuario.Telefono = "809-290-8910";
            usuario.Celular = "829-690-2801";
            usuario.Email = "ramosthen@gmail.com";
            usuario.Direccion = "Bomba de Cenovi, SFM";

            Assert.IsTrue(Metodos.Guardar(usuario));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            RepositorioBase<Usuarios> Metodos = new RepositorioBase<Usuarios>();

            Usuarios usuario = new Usuarios();
            usuario.UsuarioId = 3;
            usuario.NombreUsuario = "Pedro";
            usuario.Contrasena = "pedro1234";
            usuario.Nombres = "Pedro William";
            usuario.Apellidos = "Ramos Then";
            usuario.Telefono = "809-290-8910";
            usuario.Celular = "829-690-2801";
            usuario.Email = "ramosthen@gmail.com";
            usuario.Direccion = "Bomba de Cenovi, SFM";

            Assert.IsTrue(Metodos.Modificar(usuario));
        }
    }
}