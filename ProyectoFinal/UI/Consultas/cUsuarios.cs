using ProyectoFinal.BLL;
using ProyectoFinal.Entidades;
using ProyectoFinal.UI.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.UI.Consultas
{
    public partial class cUsuarios : Form
    {
        List<Usuarios> listado = new List<Usuarios>();
        public cUsuarios()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> Metodos = new RepositorioBase<Usuarios>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://Todo
                        listado = Metodos.GetList(p => true);
                        break;
                    case 1://Nombre
                        listado = Metodos.GetList(p => p.Nombres.Contains(CriterioTextBox.Text));
                        break;
                    case 2://Direccion
                        listado = Metodos.GetList(p => p.Direccion.Contains(CriterioTextBox.Text));
                        break;
                }
            }
            else
            {
                listado = Metodos.GetList(p => true);
            }
            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = listado;
        }

        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            if (listado.Count == 0)
            {
                MessageBox.Show("No hay datos para imprimir");
                return;
            }

            ReporteUsuarios reporteUsuarios = new ReporteUsuarios(listado);
            reporteUsuarios.ShowDialog();
        }
    }
}
