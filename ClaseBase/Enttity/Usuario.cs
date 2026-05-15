using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClaseBase
{
    public class Usuario
    {
        public int Usu_ID { get; set; }

        public string Usu_NombreUsuario { get; set; }

        public string Usu_Contrasenia { get; set; }

        public string Usu_ApellidoNombre { get; set; }

        public int Rol_Codigo { get; set; }

        public Usuario(int id, string usuario, string pass, string apellido, int rol)
        {
            Usu_ID = id;
            Usu_NombreUsuario = usuario;
            Usu_Contrasenia = pass;
            Usu_ApellidoNombre = apellido;
            Rol_Codigo = rol;
        }

        public Usuario()
        {
            // TODO: Complete member initialization
        }
    }
}
