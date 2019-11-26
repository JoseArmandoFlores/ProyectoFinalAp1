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
    public partial class ReporteCompraProductosDetalle : Form
    {
        private List<CompraProductosDetalle> ListaCompraProductosDetalle;
        public ReporteCompraProductosDetalle(List<CompraProductosDetalle> productosDetalle)
        {
            InitializeComponent();
            ListaCompraProductosDetalle = productosDetalle;
        }

        private void ReporteCompraProductosDetalle_Load(object sender, EventArgs e)
        {
            CompraProductosDetalleCrystalReport lista = new CompraProductosDetalleCrystalReport();
            lista.SetDataSource(ListaCompraProductosDetalle);

            ProductosCrystalReportViewer.ReportSource = lista;
            ProductosCrystalReportViewer.Refresh();
        }
    }
}
