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
    public partial class ReporteProveedores : Form
    {
        private List<Proveedores> ListaProveedores;
        public ReporteProveedores(List<Proveedores> proveedores)
        {
            InitializeComponent();
            ListaProveedores = proveedores;
        }

        private void ReporteProveedores_Load(object sender, EventArgs e)
        {
            ProveedoresCrystalReport lista = new ProveedoresCrystalReport();
            lista.SetDataSource(ListaProveedores);

            ProveedoresCrystalReportViewer.ReportSource = lista;
            ProveedoresCrystalReportViewer.Refresh();
        }
    }
}
