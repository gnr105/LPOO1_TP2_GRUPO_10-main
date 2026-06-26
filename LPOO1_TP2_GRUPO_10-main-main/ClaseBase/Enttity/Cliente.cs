using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClaseBase
{
    public class Cliente
    {
        public string Cli_DNI { get; set; }

        public string Cli_Apellido { get; set; }

        public string Cli_Nombre { get; set; }

        public string Cli_Direccion { get; set; }

        public string OS_CUIT { get; set; }

        public string Cli_NroCarnet { get; set; }

        public Cliente(string dni, string apellido, string nombre, string direccion, string cuit, string carnet)
        {
            Cli_DNI = dni;
            Cli_Apellido = apellido;
            Cli_Nombre = nombre;
            Cli_Direccion = direccion;
            OS_CUIT = cuit;
            Cli_NroCarnet = carnet;
        }
        public Cliente() { }
    }
}
