using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClaseBase
{
    public class Producto
    {
        public string Prod_Codigo { get; set; }

        public string Prod_Categoria { get; set; }

        public string Prod_Descripcion { get; set; }

        public decimal Prod_Precio { get; set; }

        public Producto() { }

        public Producto(string codigo, string categoria, string descripcion, decimal precio)
        {
            Prod_Codigo = codigo;
            Prod_Categoria = categoria;
            Prod_Descripcion = descripcion;
            Prod_Precio = precio;
        }

    }
}
