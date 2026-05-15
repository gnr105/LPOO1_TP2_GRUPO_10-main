using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ClaseBase
{
    public class TrabajarVenta
    {
        public static DataTable list_venta()
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT Ven_Nro as 'Nro_Venta', Ven_Fecha as 'Fecha', " +
                              "V.Cli_DNI as 'DNI', "+
                              "Cli_Apellido as 'Apellido', Cli_Nombre as 'Nombre' "+ 
                              "FROM Venta as V "+
                              "LEFT JOIN Cliente as C ON (C.Cli_DNI=V.Cli_DNI)";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
