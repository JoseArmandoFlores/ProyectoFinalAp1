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
    public partial class rUsuarios : Form
    {
        public rUsuarios()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            MyErrorProvider.Clear();
            IdNumericUpDown.Value = 0;
            UsuarioTextBox.Text = string.Empty;
            ContrasenaTextBox.Text = string.Empty;
            NombreTextBox.Text = string.Empty;
            ApellidoTextBox.Text = string.Empty;
            TelefonoMaskedTextBox.Text = string.Empty;
            CelularMaskedTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
        }

        private Usuarios LlenaClase()
        {
            Usuarios usuario = new Usuarios();
            usuario.UsuarioId = Convert.ToInt32(IdNumericUpDown.Value);
            usuario.NombreUsuario = UsuarioTextBox.Text;
            usuario.Contrasena = ContrasenaTextBox.Text;
            usuario.Nombres = NombreTextBox.Text;
            usuario.Apellidos = ApellidoTextBox.Text;
            usuario.Telefono = TelefonoMaskedTextBox.Text;
            usuario.Celular = CelularMaskedTextBox.Text;
            usuario.Email = EmailTextBox.Text;
            usuario.Direccion = DireccionTextBox.Text;

            return usuario;
        }

        private void LlenaCampo(Usuarios usuario)
        {
            IdNumericUpDown.Value = usuario.UsuarioId;
            UsuarioTextBox.Text = usuario.NombreUsuario;
            ContrasenaTextBox.Text = usuario.Contrasena;
            NombreTextBox.Text = usuario.Nombres;
            ApellidoTextBox.Text = usuario.Apellidos;
            TelefonoMaskedTextBox.Text = usuario.Telefono;
            CelularMaskedTextBox.Text = usuario.Celular;
            EmailTextBox.Text = usuario.Email;
            DireccionTextBox.Text = usuario.Direccion;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Usuarios> Metodos = new RepositorioBase<Usuarios>();
            Usuarios usuario = Metodos.Buscar((int)IdNumericUpDown.Value);
            return (usuario != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(UsuarioTextBox.Text))
            {
                MyErrorProvider.SetError(UsuarioTextBox, "El campo Usuario no puede estar vacio.");
                UsuarioTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(ContrasenaTextBox.Text))
            {
                MyErrorProvider.SetError(ContrasenaTextBox, "El campo Contraseña no puede estar vacio.");
                ContrasenaTextBox.Focus();
                paso = false;
            }

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
            RepositorioBase<Usuarios> Metodos = new RepositorioBase<Usuarios>();
            bool paso = false;
            Usuarios usuario;

            if (!Validar())
                return;
            usuario = LlenaClase();

            if (IdNumericUpDown.Value == 0)
                paso = Metodos.Guardar(usuario);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un usuario que no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = Metodos.Modificar(usuario);
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
            RepositorioBase<Usuarios> Metodos = new RepositorioBase<Usuarios>();
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
                MessageBox.Show("No se puede eliminar un usuario que no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> Metodos = new RepositorioBase<Usuarios>();
            Usuarios usuario = new Usuarios();
            int id;
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();

            usuario = Metodos.Buscar(id);
            if (usuario != null)
            {
                LlenaCampo(usuario);
            }
            else
            {
                MessageBox.Show("Usuario no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TelefonoMaskedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            rProductos.ValidarN(e);
        }

        private void CelularMaskedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            rProductos.ValidarN(e);
        }
    }
}
