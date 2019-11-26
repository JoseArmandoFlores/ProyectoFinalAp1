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

namespace ProyectoFinal.UI.Registros
{
    public partial class rProductos : Form
    {
        public static void ValidarN(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        public rProductos()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            MyErrorProvider.Clear();
            IdNumericUpDown.Value = 0;
            NombreTextBox.Text = string.Empty;
            MarcaTextBox.Text = string.Empty;
            MedidaTextBox.Text = string.Empty;
            CantidadMinimaTextBox.Text = string.Empty;
            CantidadExistenteTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            CostoTextBox.Text = string.Empty;
        }

        private Productos LlenaClase()
        {
            Productos producto = new Productos();
            producto.ProductoId = Convert.ToInt32(IdNumericUpDown.Value);
            producto.Nombre = NombreTextBox.Text;
            producto.Marca = MarcaTextBox.Text;
            producto.UnidadMedida = MedidaTextBox.Text;
            producto.CantidadMinima = Convert.ToInt32(CantidadMinimaTextBox.Text);
            producto.CantidadExistente = Convert.ToInt32(CantidadExistenteTextBox.Text);
            producto.Precio = Convert.ToDecimal(PrecioTextBox.Text);
            producto.Costo = Convert.ToDecimal(CostoTextBox.Text);

            return producto;
        }

        private void LlenaCampo(Productos producto)
        {
            IdNumericUpDown.Value = producto.ProductoId;
            NombreTextBox.Text = producto.Nombre;
            MarcaTextBox.Text = producto.Marca;
            MedidaTextBox.Text = producto.UnidadMedida;
            CantidadMinimaTextBox.Text = Convert.ToString(producto.CantidadMinima);
            CantidadExistenteTextBox.Text = Convert.ToString(producto.CantidadExistente);
            PrecioTextBox.Text = Convert.ToString(producto.Precio);
            CostoTextBox.Text = Convert.ToString(producto.Costo);
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Productos> Metodos = new RepositorioBase<Productos>();
            Productos producto = Metodos.Buscar((int)IdNumericUpDown.Value);
            return (producto != null);
        }

        private bool Validar()
        {
            bool paso = true;
            if (string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                MyErrorProvider.SetError(NombreTextBox, "El campo Nombre no puede estar vacio.");
                NombreTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(MarcaTextBox.Text))
            {
                MyErrorProvider.SetError(MarcaTextBox, "El campo Marca no puede estar vacio.");
                MarcaTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(MedidaTextBox.Text))
            {
                MyErrorProvider.SetError(MedidaTextBox, "El campo Unidad de Medida no puede estar vacio.");
                MedidaTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CantidadMinimaTextBox.Text))
            {
                MyErrorProvider.SetError(CantidadMinimaTextBox, "El campo Cantidad no puede estar vacio.");
                CantidadMinimaTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CantidadExistenteTextBox.Text) || Convert.ToInt32(CantidadExistenteTextBox.Text) < Convert.ToInt32(CantidadMinimaTextBox.Text))
            {
                MyErrorProvider.SetError(CantidadExistenteTextBox, "Campo invalido.");
                CantidadExistenteTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(PrecioTextBox.Text))
            {
                MyErrorProvider.SetError(PrecioTextBox, "El campo Precio no puede estar vacio.");
                PrecioTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CostoTextBox.Text) || Convert.ToDecimal(CostoTextBox.Text) > Convert.ToDecimal(PrecioTextBox.Text))
            {
                MyErrorProvider.SetError(CostoTextBox, "Campo invalido.");
                CostoTextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> Metodos = new RepositorioBase<Productos>();
            bool paso = false;
            Productos producto;

            if (!Validar())
                return;
            producto = LlenaClase();

            if (IdNumericUpDown.Value == 0)
                paso = Metodos.Guardar(producto);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un producto que no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = Metodos.Modificar(producto);
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
            RepositorioBase<Productos> Metodos = new RepositorioBase<Productos>();
            RepositorioBase<CompraProductosDetalle> Metodos2 = new RepositorioBase<CompraProductosDetalle>();

            var ListaCompra = Metodos2.GetList(p => true);

            int id;
            int.TryParse(IdNumericUpDown.Text, out id);
            bool paso = true;

            foreach (var item in ListaCompra)
            {
                if (item.ProductoId == id)
                {
                    paso = false;
                    break;
                }
            }

            Limpiar();
            if (Metodos.Buscar(id) != null)
            {
                if (paso==true)
                {
                    if (Metodos.Eliminar(id))
                    {
                        MessageBox.Show("Eliminado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No se puede eliminar este producto, porque esta registrado en una compra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }    
            }
            else
                MessageBox.Show("No se puede eliminar un producto que no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> Metodos = new RepositorioBase<Productos>();
            Productos producto = new Productos();
            int id;
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();

            producto = Metodos.Buscar(id);
            if (producto != null)
            {
                LlenaCampo(producto);
            }
            else
            {
                MessageBox.Show("Producto no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrecioTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarN(e);
        }

        private void CostoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarN(e);
        }

        private void CantidadMinimaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarN(e);
        }

        private void CantidadExistenteTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarN(e);
        }
    }
}
