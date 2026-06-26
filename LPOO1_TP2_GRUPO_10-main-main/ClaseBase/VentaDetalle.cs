using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClaseBase
{
    public class VentaDetalle
    {
        public decimal Det_Nro { get; set; }
        public int Ven_Nro { get; set; }
        public string Prod_Codigo { get; set; }
        public decimal Det_Precio { get; set; }
        public decimal Det_Cantidad { get; set; }
        public decimal Det_Total { get; set; }
        public string Cli_DNI { get; set; }
    }
}
