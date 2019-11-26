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
    public partial class ReporteCompraProductos : Form
    {
        private List<CompraProductos> ListaProductos;
        public ReporteCompraProductos(List<CompraProductos> compras)
        {
            InitializeComponent();
            ListaProductos = compras;
        }

        private void ReporteCompraProductos_Load(object sender, EventArgs e)
        {
            CompraProductosCrystalReport lista = new CompraProductosCrystalReport();
            lista.SetDataSource(ListaProductos);

            ComprasProductosCrystalReportViewer.ReportSource = lista;
            ComprasProductosCrystalReportViewer.Refresh();
        }
    }
}
