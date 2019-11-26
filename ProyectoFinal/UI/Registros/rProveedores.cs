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
    public partial class rProveedores : Form
    {
        public rProveedores()
        {
            InitializeComponent();
            
        }

        private void Limpiar()
        {
            MyErrorProvider.Clear();
            IdNumericUpDown.Value = 0;
            NombreTextBox.Text = string.Empty;
            ApellidoTextBox.Text = string.Empty;
            TelefonoMaskedTextBox.Text = string.Empty;
            CelularMaskedTextBox.Text = string.Empty;
            RncTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty; 
            DireccionTextBox.Text = string.Empty;
            UsuarioComboBox.SelectedValue = Login.UsuarioId;
        }

        public void LlenarComboBoxUsuario()
        {
            RepositorioBase<Usuarios> Metodos = new RepositorioBase<Usuarios>();
            var Lista = Metodos.GetList(p => true);

            UsuarioComboBox.DataSource = Lista;
            UsuarioComboBox.ValueMember = "UsuarioId";
            UsuarioComboBox.DisplayMember = "NombreUsuario";
        }

        private Proveedores LlenaClase()
        {
            Proveedores proveedor = new Proveedores();
            proveedor.ProveedorId = Convert.ToInt32(IdNumericUpDown.Value);
            proveedor.UsuarioId = Login.UsuarioId;
            proveedor.Nombres = NombreTextBox.Text;
            proveedor.Apellidos = ApellidoTextBox.Text;
            proveedor.Telefono = TelefonoMaskedTextBox.Text;
            proveedor.Celular = CelularMaskedTextBox.Text;
            proveedor.Rnc = RncTextBox.Text;
            proveedor.Email = EmailTextBox.Text;
            proveedor.Direccion = DireccionTextBox.Text;

            return proveedor;
        }

        private void LlenaCampo(Proveedores proveedor)
        {
            IdNumericUpDown.Value = proveedor.ProveedorId;
            UsuarioComboBox.SelectedValue = proveedor.UsuarioId;
            NombreTextBox.Text = proveedor.Nombres;
            ApellidoTextBox.Text = proveedor.Apellidos;
            TelefonoMaskedTextBox.Text = proveedor.Telefono;
            CelularMaskedTextBox.Text = proveedor.Celular;
            RncTextBox.Text = proveedor.Rnc;
            EmailTextBox.Text = proveedor.Email;
            DireccionTextBox.Text = proveedor.Direccion;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Proveedores> Metodos = new RepositorioBase<Proveedores>();
            Proveedores proveedor = Metodos.Buscar((int)IdNumericUpDown.Value);
            return (proveedor != null);
        }

        private bool Validar()
        {
            bool paso = true;
            if (string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                MyErrorProvider.SetError(NombreTextBox, "El campo Nombres no puede estar vacio.");
                NombreTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(ApellidoTextBox.Text))
            {
                MyErrorProvider.SetError(ApellidoTextBox, "El campo Apellidos no puede estar vacio.");
                ApellidoTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(TelefonoMaskedTextBox.Text.Replace("-", "")))
            {
                MyErrorProvider.SetError(TelefonoMaskedTextBox, "El campo Telefono no puede estar vacio.");
                TelefonoMaskedTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CelularMaskedTextBox.Text.Replace("-", "")))
            {
                MyErrorProvider.SetError(CelularMaskedTextBox, "El campo Celular no puede estar vacio.");
                CelularMaskedTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(RncTextBox.Text))
            {
                MyErrorProvider.SetError(RncTextBox, "El campo Rnc no puede estar vacio.");
                RncTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                MyErrorProvider.SetError(EmailTextBox, "El campo Email no puede estar vacio.");
                EmailTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(DireccionTextBox.Text))
            {
                MyErrorProvider.SetError(DireccionTextBox, "El campo Direccion no puede estar vacio.");
                DireccionTextBox.Focus();
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
            RepositorioBase<Proveedores> Metodos = new RepositorioBase<Proveedores>();
            bool paso = false;
            Proveedores proveedor;

            if (!Validar())
                return;
            proveedor = LlenaClase();

            if (IdNumericUpDown.Value == 0)
                paso = Metodos.Guardar(proveedor);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un proveedor que no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = Metodos.Modificar(proveedor);
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
            RepositorioBase<Proveedores> Metodos = new RepositorioBase<Proveedores>();
            RepositorioBase<CompraProductos> Metodos2 = new RepositorioBase<CompraProductos>();
            int id;
            int.TryParse(IdNumericUpDown.Text, out id);

            var ListaCompra = Metodos2.GetList(p => true);
            bool paso = true;

            foreach (var item in ListaCompra)
            {
                if (item.ProveedorId == id)
                {
                    paso = false;
                    break;
                }
            }

            Limpiar();
            if (Metodos.Buscar(id) != null)
            {
                if (paso == true)
                {
                    if (Metodos.Eliminar(id))
                    {
                        MessageBox.Show("Eliminado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No se puede eliminar este proveedor, porque esta registrado en una compra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("No se puede eliminar un proveedor que no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Proveedores> Metodos = new RepositorioBase<Proveedores>();
            Proveedores proveedor = new Proveedores();
            int id;
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();

            proveedor = Metodos.Buscar(id);
            if (proveedor != null)
            {
                LlenaCampo(proveedor);
            }
            else
            {
                MessageBox.Show("Proveedor no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RProveedores_Load(object sender, EventArgs e)
        {
            LlenarComboBoxUsuario();
            UsuarioComboBox.SelectedValue = (Login.UsuarioId);
        }

        private void TelefonoMaskedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            rProductos.ValidarN(e);
        }

        private void CelularMaskedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            rProductos.ValidarN(e);
        }

        private void RncTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            rProductos.ValidarN(e);
        }
    }
}
