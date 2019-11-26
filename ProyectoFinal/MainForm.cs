using ProyectoFinal.UI.Consultas;
using ProyectoFinal.UI.Registros;
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

namespace ProyectoFinal
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rProveedores proveedor = new rProveedores();
            proveedor.MdiParent = this;
            proveedor.Show();
        }

        private void ProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rProductos productos = new rProductos();
            productos.MdiParent = this;
            productos.Show();
        }

        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Login.UsuarioId != 1)
            {
                MessageBox.Show("Solo el administrador tiene derecho a registrar usuarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                rUsuarios usuarios = new rUsuarios();
                usuarios.MdiParent = this;
                usuarios.Show();
            } 
        }

        private void CompraDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rCompraProductos compraProductos = new rCompraProductos();
            compraProductos.MdiParent = this;
            compraProductos.Show();
        }

        private void UsuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Login.UsuarioId != 1)
            {
                MessageBox.Show("Solo el administrador tiene derecho a consultar usuarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                cUsuarios usuarios = new cUsuarios();
                usuarios.MdiParent = this;
                usuarios.Show();
            }
        }

        private void ProductosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cProductos productos = new cProductos();
            productos.MdiParent = this;
            productos.Show();
        }

        private void ProveedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cProveedores proveedores = new cProveedores();
            proveedores.MdiParent = this;
            proveedores.Show();
        }

        private void CompraDeProductosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cCompraProductos compraProductos = new cCompraProductos();
            compraProductos.MdiParent = this;
            compraProductos.Show();
        }
    }
}
