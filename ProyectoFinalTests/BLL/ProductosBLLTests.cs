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
    }
}