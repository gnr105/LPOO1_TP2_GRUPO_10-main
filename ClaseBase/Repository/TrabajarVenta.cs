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
            cmd.CommandText = "listar_ventas_sp";
            cmd.CommandType = CommandType.StoredProcedure;
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
            cmd.CommandText = "listar_clientes_combo_sp";
            cmd.CommandType = CommandType.StoredProcedure;
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
            cmd.CommandText = "listar_productos_venta_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        
        public static DataTable listar_ventas_x_cliente(string dni)
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listar_ventas_x_cliente_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@dni", dni);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable listar_ventas_por_fechas(DateTime desde, DateTime hasta)
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listar_ventas_por_fechas_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@fechaDesde", desde);
            cmd.Parameters.AddWithValue("@fechaHasta", hasta);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable listar_productos_por_cliente(string dni)
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listar_productos_por_cliente_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@cli_dni", dni);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static void delete_venta(int nroVenta)
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "eliminar_venta_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@nro", nroVenta);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void insert_venta(DateTime fecha, string dni, DataTable dtDetalles)
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            cnn.Open();
            SqlTransaction tran = cnn.BeginTransaction();

            try
            {
                // cabecera de venta
                SqlCommand cmdVenta = new SqlCommand();
                cmdVenta.CommandText = "insert_venta_sp";
                cmdVenta.CommandType = CommandType.StoredProcedure;
                cmdVenta.Connection = cnn;
                cmdVenta.Transaction = tran;

                cmdVenta.Parameters.AddWithValue("@fec", fecha);
                cmdVenta.Parameters.AddWithValue("@dni", dni);

                int nroVenta = Convert.ToInt32(cmdVenta.ExecuteScalar());

                foreach (DataRow fila in dtDetalles.Rows)
                {
                    SqlCommand cmdDet = new SqlCommand();
                    cmdDet.CommandText = "insert_detalle_venta_sp";
                    cmdDet.CommandType = CommandType.StoredProcedure;
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
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
        }
    }
}
