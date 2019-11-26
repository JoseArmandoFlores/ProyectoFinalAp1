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

namespace ProyectoFinal.UI.Registros
{
    public partial class rCompraProductos : Form
    {
        public List<CompraProductosDetalle> Detalle { get; set; }
        public rCompraProductos()
        {
            InitializeComponent();
            this.Detalle = new List<CompraProductosDetalle>();
        }
        public void LlenarComboBoxUsuario()
        {
            RepositorioBase<Usuarios> Metodos = new RepositorioBase<Usuarios>();
            var Lista = Metodos.GetList(p => true);

            UsuarioComboBox.DataSource = Lista;
            UsuarioComboBox.ValueMember = "UsuarioId";
            UsuarioComboBox.DisplayMember = "NombreUsuario";
        }

        public void LlenarComboBoxProveedor()
        {
            RepositorioBase<Proveedores> Metodos = new RepositorioBase<Proveedores>();
            var Lista = Metodos.GetList(p => true);

            ProveedorComboBox.DataSource = Lista;
            ProveedorComboBox.ValueMember = "ProveedorId";
            ProveedorComboBox.DisplayMember = "Nombres";
        }

        public void LlenarComboBoxProducto()
        {
            RepositorioBase<Productos> Metodos = new RepositorioBase<Productos>();
            var Lista = Metodos.GetList(p => true);

            ProductoComboBox.DataSource = Lista;
            ProductoComboBox.ValueMember = "ProductoId";
            ProductoComboBox.DisplayMember = "Nombre";
        }

        public void CargarGrid()
        {
            RepositorioBase<Productos> Metodos = new RepositorioBase<Productos>();
            DetalleDataGridView.Rows.Clear();
            foreach (var item in this.Detalle)
            {
                Productos producto = Metodos.Buscar(item.ProductoId);
                DetalleDataGridView.Rows.Add(producto.ProductoId, producto.Nombre ,producto.Marca, producto.UnidadMedida, item.Cantidad, producto.Costo, item.Cantidad * producto.Costo);
            }

        }

        private void Limpiar()
        {
            MyErrorProvider.Clear();
            IdNumericUpDown.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            ProveedorComboBox.Text = string.Empty;
            ProductoComboBox.Text = string.Empty;
            MarcaTextBox.Text = string.Empty;
            UnidadTextBox.Text = string.Empty;
            CantidadNumericUpDown.Value = 0;
            CostoTextBox.Text = string.Empty;
            ImporteTextBox.Text = string.Empty;
            UsuarioComboBox.SelectedValue = Login.UsuarioId;
            TotalTextBox.Text = "0.00";

            this.Detalle = new List<CompraProductosDetalle>();
            CargarGrid();
        }

        private CompraProductos LlenaClase()
        {
            CompraProductos compra = new CompraProductos();
            compra.CompraId = Convert.ToInt32(IdNumericUpDown.Value);
            compra.ProveedorId = Convert.ToInt32(ProveedorComboBox.SelectedValue.ToString());
            compra.UsuarioId = Login.UsuarioId;
            compra.Fecha = FechaDateTimePicker.Value;
            compra.Total = Convert.ToDecimal(TotalTextBox.Text);

            compra.ProductosDetalle = this.Detalle;
            return compra;
        }

        private void LlenaCampo(CompraProductos compra)
        {
            IdNumericUpDown.Value = compra.CompraId;
            FechaDateTimePicker.Value = compra.Fecha;
            ProveedorComboBox.SelectedValue = compra.ProveedorId;
            UsuarioComboBox.SelectedValue = compra.UsuarioId;
            TotalTextBox.Text = Convert.ToString(compra.Total);

            this.Detalle = compra.ProductosDetalle;
            CargarGrid();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<CompraProductos> Metodos = new RepositorioBase<CompraProductos>();
            CompraProductos compra = Metodos.Buscar((int)IdNumericUpDown.Value);
            return (compra != null);
        }

        private bool Validar()
        {
            bool paso = true;
            if (string.IsNullOrWhiteSpace(ProductoComboBox.Text))
            {
                MyErrorProvider.SetError(ProductoComboBox, "El campo Producto no puede estar vacio.");
                ProductoComboBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(ProveedorComboBox.Text))
            {
                MyErrorProvider.SetError(ProveedorComboBox, "El campo Proveedor no puede estar vacio.");
                ProveedorComboBox.Focus();
                paso = false;
            }

            if (this.Detalle.Count == 0)
            {
                MyErrorProvider.SetError(AgregarDetalleButton, "El Detalle no puede estar vacio.");
                AgregarDetalleButton.Focus();
                paso = false;
            }

            return paso;
        }

        private bool ValidarDetalle()
        {
            bool paso = true;
            if (string.IsNullOrWhiteSpace(MarcaTextBox.Text))
            {
                MyErrorProvider.SetError(MarcaTextBox, "El campo Marca no puede estar vacio.");
                MarcaTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(UnidadTextBox.Text))
            {
                MyErrorProvider.SetError(UnidadTextBox, "El campo Unidad de Medida no puede estar vacio.");
                UnidadTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CostoTextBox.Text))
            {
                MyErrorProvider.SetError(CostoTextBox, "El campo Costo no puede estar vacio.");
                CostoTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(ImporteTextBox.Text))
            {
                MyErrorProvider.SetError(ImporteTextBox, "El campo Importe no puede estar vacio.");
                ImporteTextBox.Focus();
                paso = false;
            }

            if (CantidadNumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(CantidadNumericUpDown, "La cantidad no puede ser 0");
                CantidadNumericUpDown.Focus();
                paso = false;
            }

            return paso;
        }


        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void RCompraProductos_Load(object sender, EventArgs e)
        {
            TotalTextBox.Text = "0.00";
            LlenarComboBoxProducto();
            LlenarComboBoxProveedor();
            LlenarComboBoxUsuario();
            UsuarioComboBox.SelectedValue = Login.UsuarioId;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<CompraProductos> Metodos = new RepositorioBase<CompraProductos>();
            ComprasBLL Metodos2 = new ComprasBLL();

            bool paso = false;
            CompraProductos compra;

            if (!Validar())
                return;
            compra = LlenaClase();

            if (IdNumericUpDown.Value == 0)
            {
                paso = Metodos.Guardar(compra);
                foreach (var item in this.Detalle)
                {
                    Metodos2.AgregarCantidad(item.Cantidad, item.ProductoId);
                }
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una compra que no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = Metodos2.Modificar(compra);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            ComprasBLL Metodos = new ComprasBLL();
            int id;
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();
            if (Metodos.Buscar(id) != null)
            {
                if (Metodos.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No se puede eliminar una compra que no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<CompraProductos> Metodos = new RepositorioBase<CompraProductos>();
            CompraProductos compra = new CompraProductos();
            int id;
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();

            compra = Metodos.Buscar(id);
            if (compra != null)
            {
                LlenaCampo(compra);
            }
            else
            {
                MessageBox.Show("Compra no encontrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarDetalleButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> Metodos = new RepositorioBase<Productos>();

            if (DetalleDataGridView.DataSource != null)
                this.Detalle = (List<CompraProductosDetalle>)DetalleDataGridView.DataSource;

            if (!ValidarDetalle())
                return;

            string Id = ProductoComboBox.SelectedValue.ToString();

            this.Detalle.Add(
                new CompraProductosDetalle(
                    id: 0,
                    compraId: (int)IdNumericUpDown.Value,
                    productoId: Convert.ToInt32(Id),
                    cantidad: Convert.ToInt32(CantidadNumericUpDown.Value),
                    precio: Convert.ToDecimal(CostoTextBox.Text)
                    )
                );
            
            decimal Total = 0;
            foreach (var item in this.Detalle)
            {
                Productos producto = Metodos.Buscar(item.ProductoId);
                Total += (producto.Costo * item.Cantidad);
            }
            TotalTextBox.Text = Convert.ToString(Total);
            CargarGrid();

            ProductoComboBox.Focus();
            CantidadNumericUpDown.Value = 0;
            MyErrorProvider.Clear();
            MarcaTextBox.Text = string.Empty;
            UnidadTextBox.Text = string.Empty;
            CostoTextBox.Text = string.Empty;
            ImporteTextBox.Text = string.Empty;
        }

        private void RemoverButton_Click(object sender, EventArgs e)
        {
            ComprasBLL Metodos = new ComprasBLL();
            decimal importe = Convert.ToDecimal(DetalleDataGridView.CurrentRow.Cells[6].Value);
            int cantidad = Convert.ToInt32(DetalleDataGridView.CurrentRow.Cells[4].Value);
            string Id = ProductoComboBox.SelectedValue.ToString();

            if (DetalleDataGridView.Rows.Count > 0 && DetalleDataGridView.CurrentRow != null)
            {
                Detalle.RemoveAt(DetalleDataGridView.CurrentRow.Index);
                Metodos.AgregarCantidad(cantidad*(-1), Convert.ToInt32(Id));
                TotalTextBox.Text = Convert.ToString(Convert.ToDecimal(TotalTextBox.Text) - importe);
                CargarGrid();

            }
        }

        private void AgregarProductoButton_Click(object sender, EventArgs e)
        {
            rProductos productos = new rProductos();
            productos.ShowDialog();
            LlenarComboBoxProducto();
        }

        private void CantidadNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            RepositorioBase<Productos> Metodos = new RepositorioBase<Productos>();


            string Id = ProductoComboBox.SelectedValue.ToString();

            Productos producto = Metodos.Buscar(Convert.ToInt32(Id));


            MarcaTextBox.Text = producto.Marca.ToString();
            CostoTextBox.Text = producto.Costo.ToString();
            UnidadTextBox.Text = producto.UnidadMedida.ToString();

            ImporteTextBox.Text = (producto.Costo * Convert.ToInt32(CantidadNumericUpDown.Value)).ToString();
        }

        private void AgregarProveedorButton_Click(object sender, EventArgs e)
        {
            rProveedores proveedor = new rProveedores();
            proveedor.ShowDialog();
            LlenarComboBoxProveedor();
        }

        private void ProductoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CantidadNumericUpDown.Value = 0;
            MarcaTextBox.Text = string.Empty;
            UnidadTextBox.Text = string.Empty;
            CostoTextBox.Text = string.Empty;
            ImporteTextBox.Text = string.Empty;
        }

        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            if (this.Detalle.Count == 0)
            {
                MessageBox.Show("No hay datos para imprimir");
                return;
            }

            ReporteCompraProductosDetalle compraProductosReportViewer = new ReporteCompraProductosDetalle(this.Detalle);
            compraProductosReportViewer.ShowDialog();
        }
    }
}
