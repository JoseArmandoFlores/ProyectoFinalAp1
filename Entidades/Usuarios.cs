using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class Usuarios
    {
       [Key]
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }

        public Usuarios()
        {
        }

        public Usuarios(int usuarioId, string nombreUsuario, string contrasena, string nombres, string apellidos, string telefono, string celular, string email, string direccion)
        {
            UsuarioId = usuarioId;
            NombreUsuario = nombreUsuario;
            Contrasena = contrasena;
            Nombres = nombres;
            Apellidos = apellidos;
            Telefono = telefono;
            Celular = celular;
            Email = email;
            Direccion = direccion;
        }
    }
}
