using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ClaseBase
{
    public class TrabajarObraSocial
    {
        public static void insert_obrasocial(ObraSocial os)
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO ObraSocial(OS_CUIT, OS_RazonSocial, OS_Direccion, OS_Telefono) " +
                              "VALUES(@cuit, @razon, @dir, @tel)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@cuit", os.OS_CUIT);
            cmd.Parameters.AddWithValue("@razon", os.OS_RazonSocial);
            cmd.Parameters.AddWithValue("@dir", os.OS_Direccion);
            cmd.Parameters.AddWithValue("@tel", os.OS_Telefono);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        // Devuelve todas las obras sociales usando stored procedure
        public static DataTable list_obrasociales()
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "listar_obrasociales_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Devuelve los clientes afiliados usando stored procedure
        public static DataTable list_clientes_por_obrasocial(string cuit)
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "listar_clientes_por_obrasocial_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@cuit", cuit);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
