using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class Proveedores
    {
        [Key]
        public int ProveedorId { get; set; }
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Rnc { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }

        public Proveedores()
        {
        }

        public Proveedores(int proveedorId, int usuarioId, string nombres, string apellidos, string telefono, string celular, string rnc, string email, string direccion)
        {
            ProveedorId = proveedorId;
            UsuarioId = usuarioId;
            Nombres = nombres;
            Apellidos = apellidos;
            Telefono = telefono;
            Celular = celular;
            Rnc = rnc;
            Email = email;
            Direccion = direccion;
        }
    }
}
