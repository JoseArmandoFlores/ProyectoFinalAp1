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

namespace ProyectoFinal
{
    public partial class Login : Form
    {
        RepositorioBase<Usuarios> Metodos = new RepositorioBase<Usuarios>();
        List<Usuarios> lista = new List<Usuarios>();
        public static int UsuarioId;
        public Login()
        {
            InitializeComponent();
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
                MyErrorProvider.SetError(ContrasenaTextBox, "El campo Contrasena no puede estar vacio.");
                ContrasenaTextBox.Focus();
                paso = false;
            }
            return paso;
        }

        private void IngresarButton_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            if (!Validar())
                return;
            lista = Metodos.GetList(p => true);
            bool paso = false;
            foreach (var item in lista)
            {
                if ((item.NombreUsuario == UsuarioTextBox.Text) && (item.Contrasena == ContrasenaTextBox.Text))
                {
                    UsuarioId = item.UsuarioId;
                    main.Show();
                    paso = true;
                    break;
                }
            }
            if (paso == false)
            {
                MessageBox.Show("Usuario o Contraseña incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UsuarioTextBox.Text = string.Empty;
                UsuarioTextBox.Focus();
                ContrasenaTextBox.Text = string.Empty;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> Metodos = new RepositorioBase<Usuarios>();
            lista = Metodos.GetList(p => true);
            ContrasenaTextBox.UseSystemPasswordChar = true;
            if (lista.Count==0)
            {
                Usuarios usuario = new Usuarios();
                usuario.UsuarioId = 1;
                usuario.NombreUsuario = "Admin";
                usuario.Contrasena = "admin123";
                usuario.Nombres = "Jose Armando";
                usuario.Apellidos = "Flores Baldera";
                usuario.Telefono = "809-290-8910";
                usuario.Celular = "829-690-2801";
                usuario.Email = "floresbaldera@gmail.com";
                usuario.Direccion = "Bomba de Cenovi, SFM";

                Metodos.Guardar(usuario);
            }
        }
    }
}
