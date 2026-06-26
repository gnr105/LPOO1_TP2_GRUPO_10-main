using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ClaseBase
{
    public class TrabajarCliente
    {

        public static void insert_cliente(Cliente client)
        {

            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Cliente(Cli_DNI, Cli_Apellido, Cli_Nombre, Cli_Direccion, OS_CUIT, Cli_NroCarnet) values(@dni, @ape, @nom, @dir, @os, @ncar)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@dni", client.Cli_DNI);
            cmd.Parameters.AddWithValue("@ape", client.Cli_Apellido);
            cmd.Parameters.AddWithValue("@nom", client.Cli_Nombre);
            cmd.Parameters.AddWithValue("@dir", client.Cli_Direccion);
            cmd.Parameters.AddWithValue("@os", client.OS_CUIT);
            cmd.Parameters.AddWithValue("@ncar", client.Cli_NroCarnet);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static DataTable list_client()
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT Cli_DNI as 'DNI', Cli_Apellido as 'Apellido', " +
                              "Cli_Nombre as 'Nombre', Cli_Direccion as 'Direccion', " +
                              "OS_CUIT as 'Obrasocial', Cli_NroCarnet as 'NroCarnet' " +
                              "FROM Cliente";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable list_clientes_ordenados()
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "listarClientesOrdenados";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public static DataTable search_clientes(string pattern)
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT Cli_DNI as 'DNI', Cli_Apellido as 'Apellido', " +
                              "Cli_Nombre as 'Nombre', Cli_Direccion as 'Direccion', " +
                              "OS_CUIT as 'Obrasocial', Cli_NroCarnet as 'NroCarnet' " +
                              "FROM Cliente WHERE Cli_DNI LIKE @pat + '%' OR Cli_Apellido LIKE @pat + '%'";

            cmd.Parameters.AddWithValue("@pat", pattern);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static void update_cliente(Cliente client)
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE Cliente SET Cli_Apellido=@ape, Cli_Nombre=@nom, " +
                              "Cli_Direccion=@dir, OS_CUIT=@os, Cli_NroCarnet=@ncar " +
                              "WHERE Cli_DNI=@dni";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@dni", client.Cli_DNI);
            cmd.Parameters.AddWithValue("@ape", client.Cli_Apellido);
            cmd.Parameters.AddWithValue("@nom", client.Cli_Nombre);
            cmd.Parameters.AddWithValue("@dir", client.Cli_Direccion);
            cmd.Parameters.AddWithValue("@os", client.OS_CUIT);
            cmd.Parameters.AddWithValue("@ncar", client.Cli_NroCarnet);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void delete_cliente(string dni)
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand("DELETE FROM Cliente WHERE Cli_DNI=@dni", cnn);
            cmd.Parameters.AddWithValue("@dni", dni);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static DataTable buscar_clientes_avanzado(string dni, string apellido, string nombre, string orden)
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "buscar_clientes";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@dni", dni);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@orden", orden);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
    }
}
