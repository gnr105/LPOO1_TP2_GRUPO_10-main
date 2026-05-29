using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ClaseBase
{
    public class TrabajarProducto
    {
        public static void insert_producto(Producto prod)
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "InsertarProducto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@codigo", prod.Prod_Codigo);
            cmd.Parameters.AddWithValue("@categoria", prod.Prod_Categoria);
            cmd.Parameters.AddWithValue("@descripcion", prod.Prod_Descripcion);
            cmd.Parameters.AddWithValue("@precio", prod.Prod_Precio);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static DataTable list_productos_ordered(string orden)
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "ListarProductosOrdenados";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@Orden", orden);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        
        public static void update_producto(Producto prod)
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "ActualizarProducto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@codigo", prod.Prod_Codigo);
            cmd.Parameters.AddWithValue("@categoria", prod.Prod_Categoria);
            cmd.Parameters.AddWithValue("@descripcion", prod.Prod_Descripcion);
            cmd.Parameters.AddWithValue("@precio", prod.Prod_Precio);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        
        public static void delete_producto(string codigo)
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "EliminarProducto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@codigo", codigo);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
