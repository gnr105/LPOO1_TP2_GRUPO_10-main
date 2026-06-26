using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClaseBase.Repositorio
{
    public class RolService
    {
        private static List<Rol> listRol = new List<Rol>();

        public static void CargarRoles()
        {
            listRol.Clear();
            listRol.Add(new Rol(1, "Administrador"));
            listRol.Add(new Rol(2, "Operador"));
            listRol.Add(new Rol(3, "Auditor"));
        }

        // Método extra que te servirá después para cargar ComboBoxes
        public static List<Rol> ListarRoles()
        {
            return listRol;
        }
        public static Rol ObtenerRolPorCodigo(int codigo)
        {
            return listRol.Find(r => r.Rol_Codigo == codigo);
        }
    }
}
