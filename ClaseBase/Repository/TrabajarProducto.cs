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

        public static DataTable listarProd()
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "ListarProductos";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static DataTable listar_prod_por_fecha(DateTime fechainicio, DateTime fechafin)
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "ListarProductosPorFecha";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@fechaIni", fechainicio);
            cmd.Parameters.AddWithValue("@fechaFin", fechafin);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static int contar_prod_por_fecha(DateTime fechainicio, DateTime fechafin)
        {
            int cant_prod_vendidos;
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "ContProdVenPorFecha";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@fechaIni", fechainicio);
            cmd.Parameters.AddWithValue("@fechaFin", fechafin);

            cmd.Parameters.Add("@num", SqlDbType.Int);
            cmd.Parameters["@num"].Direction = ParameterDirection.Output;

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

            cant_prod_vendidos = (int)cmd.Parameters["@num"].Value;

            return cant_prod_vendidos;
        }
    }
}
