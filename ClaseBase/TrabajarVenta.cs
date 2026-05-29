using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ClaseBase
{
    public class TrabajarVenta
    {
        public static int insertar_venta(Venta v)
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            // SCOPE_IDENTITY() nos devuelve el ID que se acaba de crear automáticamente
            SqlCommand cmd = new SqlCommand("INSERT INTO Venta(Ven_Fecha, Cli_DNI) VALUES(@fec, @dni); SELECT SCOPE_IDENTITY();", cnn);
            cmd.Parameters.AddWithValue("@fec", v.Ven_Fecha);
            cmd.Parameters.AddWithValue("@dni", v.Cli_DNI);

            cnn.Open();
            int nroVenta = Convert.ToInt32(cmd.ExecuteScalar());
            cnn.Close();
            return nroVenta;
        }

        public static void insertar_detalle(VentaDetalle d)
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO VentaDetalle(Ven_Nro, Prod_Codigo, Det_Precio, Det_Cantidad, Det_Total) VALUES(@nro, @cod, @pre, @can, @tot)", cnn);
            cmd.Parameters.AddWithValue("@nro", d.Ven_Nro);
            cmd.Parameters.AddWithValue("@cod", d.Prod_Codigo);
            cmd.Parameters.AddWithValue("@pre", d.Det_Precio);
            cmd.Parameters.AddWithValue("@can", d.Det_Cantidad);
            cmd.Parameters.AddWithValue("@tot", d.Det_Total);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
