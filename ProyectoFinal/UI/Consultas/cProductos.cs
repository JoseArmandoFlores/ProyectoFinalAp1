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
    public partial class cProductos : Form
    {
        List<Productos> listado = new List<Productos>();
        public cProductos()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> Metodos = new RepositorioBase<Productos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://Todo
                        listado = Metodos.GetList(p => true);
                        break;
                    case 1://Nombre
                        listado = Metodos.GetList(p => p.Nombre.Contains(CriterioTextBox.Text));
                        break;
                    case 2://Marca
                        listado = Metodos.GetList(p => p.Marca.Contains(CriterioTextBox.Text));
                        break;
                }
            }
            else
            {
                listado = Metodos.GetList(p => true);
            }
            if (FiltroComboBox.SelectedIndex == 3)
            {
                listado = ProductosBLL.GetProductosEnReorden();
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

            ReporteProductos productosReportViewer = new ReporteProductos(listado);
            productosReportViewer.ShowDialog();
        }

       
    }
}
