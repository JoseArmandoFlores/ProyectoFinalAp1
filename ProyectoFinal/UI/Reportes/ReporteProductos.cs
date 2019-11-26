using ProyectoFinal.BLL;
using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.UI.Reportes
{
    public partial class ReporteProductos : Form
    {
        private List<Productos> ListaProductos;
        public ReporteProductos(List<Productos> productos)
        {
            InitializeComponent();
            ListaProductos = productos;
        }


        private void ProductosCrystalReportViewer_Load(object sender, EventArgs e)
        {

        }

        private void ReporteProductos_Load(object sender, EventArgs e)
        {
            ProductosCrystalReport lista = new ProductosCrystalReport();
            lista.SetDataSource(ListaProductos);

            ProductosCrystalReportViewer.ReportSource = lista;
            ProductosCrystalReportViewer.Refresh();
        }
    }
}
