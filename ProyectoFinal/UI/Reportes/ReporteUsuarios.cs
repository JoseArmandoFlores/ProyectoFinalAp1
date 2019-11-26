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
    public partial class ReporteUsuarios : Form
    {
        private List<Usuarios> ListaUsuarios;
        public ReporteUsuarios(List<Usuarios> usuarios)
        {
            InitializeComponent();
            ListaUsuarios = usuarios;
        }

        private void ReporteUsuarios_Load(object sender, EventArgs e)
        {
            UsuariosCrystalReport lista = new UsuariosCrystalReport();
            lista.SetDataSource(ListaUsuarios);

            UsuariosCrystalReportViewer.ReportSource = lista;
            UsuariosCrystalReportViewer.Refresh();
        }
    }
}
