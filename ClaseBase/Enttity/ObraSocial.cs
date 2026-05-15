using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClaseBase
{
    public class ObraSocial
    {
        public string OS_CUIT { get; set; }

        public string OS_RazonSocial { get; set; }

        public string OS_Direccion { get; set; }

        public string OS_Telefono { get; set; }

        public ObraSocial() { }

        public ObraSocial(string cuit, string razonsoc, string dire, string telefono)
        {
            OS_CUIT = cuit;
            OS_RazonSocial = razonsoc;
            OS_Direccion = dire;
            OS_Telefono = telefono;
        }
    }
}
