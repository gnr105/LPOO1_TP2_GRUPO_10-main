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
        public static DataTable list_clientes()
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT ";
            cmd.CommandText += "Cli_DNI, ";
            cmd.CommandText += "Cli_Apellido + ', ' + Cli_Nombre as 'NombreCompleto' ";
            cmd.CommandText += "FROM Cliente";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static DataTable list_productos()
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM PRODUCTO";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static void insert_venta(DateTime fecha, string dni, DataTable dtDetalles)
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);

            cnn.Open();

            SqlTransaction tran = cnn.BeginTransaction();


            SqlCommand cmdVenta = new SqlCommand();
            cmdVenta.CommandText = "INSERT INTO VENTA(Ven_Fecha, Cli_DNI) ";
            cmdVenta.CommandText += "VALUES(@fec, @dni); ";
            cmdVenta.CommandText += "SELECT SCOPE_IDENTITY();";

            cmdVenta.CommandType = CommandType.Text;
            cmdVenta.Connection = cnn;
            cmdVenta.Transaction = tran;

            cmdVenta.Parameters.AddWithValue("@fec", fecha);
            cmdVenta.Parameters.AddWithValue("@dni", dni);


            int nroVenta = Convert.ToInt32(cmdVenta.ExecuteScalar());

     
            foreach (DataRow fila in dtDetalles.Rows)
            {
                SqlCommand cmdDet = new SqlCommand();
                cmdDet.CommandText = "INSERT INTO VENTADETALLE(Ven_Nro, Prod_Codigo, Det_Precio, Det_Cantidad, Det_Total) ";
                cmdDet.CommandText += "VALUES(@nro, @prod, @pre, @cant, @tot)";

                cmdDet.CommandType = CommandType.Text;
                cmdDet.Connection = cnn;
                cmdDet.Transaction = tran;

                cmdDet.Parameters.AddWithValue("@nro", nroVenta);
                cmdDet.Parameters.AddWithValue("@prod", fila["Codigo"]);
                cmdDet.Parameters.AddWithValue("@pre", fila["Precio"]);
                cmdDet.Parameters.AddWithValue("@cant", fila["Cantidad"]);
                cmdDet.Parameters.AddWithValue("@tot", fila["Total"]);

                cmdDet.ExecuteNonQuery();
            }

            tran.Commit();

            cnn.Close();
        }
    }
}
