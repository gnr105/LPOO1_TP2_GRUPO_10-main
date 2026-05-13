using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClaseBase.Repositorio
{
    public class UsuarioService
    {
        private static List<Usuario> listUsuarios = new List<Usuario>();

        public static void CargarUsuarios() {

            listUsuarios.Clear();
            listUsuarios.Add(new Usuario(1, "Test", "123", "Rodriguez", 1));
            listUsuarios.Add(new Usuario(2, "Marcos", "444", "Valdez", 2));
            listUsuarios.Add(new Usuario(3, "Agustin", "555", "Callata", 3));
        }

        public static Usuario ValidarUsuario(string user, string pass)
        {
            return listUsuarios.Find(u => u.Usu_NombreUsuario.Equals(user) && u.Usu_Contrasenia.Equals(pass));
        }
    }
}
