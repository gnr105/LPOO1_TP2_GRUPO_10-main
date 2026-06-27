using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClaseBase
{
    public class TrabajarUsuario
    {
        public static DataTable list_roles() 
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listar_roles_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static void insert_usuario(Usuario user) 
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insertar_usuario_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@user", user.Usu_NombreUsuario);
            cmd.Parameters.AddWithValue("@pss", user.Usu_Contrasenia);
            cmd.Parameters.AddWithValue("@ape", user.Usu_ApellidoNombre);
            cmd.Parameters.AddWithValue("@rol", user.Rol_Codigo);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static DataTable list_usuarios()
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listar_usuarios_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable search_usuarios(string sPattern)
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "buscar_usuarios_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@pattern", sPattern);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static void update_usuario(Usuario user)
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "actualizar_usuario_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@user", user.Usu_NombreUsuario);
            cmd.Parameters.AddWithValue("@pss", user.Usu_Contrasenia);
            cmd.Parameters.AddWithValue("@ape", user.Usu_ApellidoNombre);
            cmd.Parameters.AddWithValue("@rol", user.Rol_Codigo);
            cmd.Parameters.AddWithValue("@id", user.Usu_ID);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void delete_usuario(int id)
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "eliminar_usuario_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@id", id);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static string validar_usuario(int idEliminar, int idLog)
        {
            if (idEliminar == idLog)
            {
                return "No puedes eliminar tu propia cuenta.";
            }
            return "";
        }

        public static Usuario validar_login(string user, string pass)
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "validar_login_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);

            cnn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Usuario oUser = null;

            if (reader.Read())
            {
                oUser = new Usuario();
                oUser.Usu_ID = (int)reader["Usu_ID"];
                oUser.Usu_NombreUsuario = (string)reader["Usu_NombreUsuario"];
                oUser.Usu_ApellidoNombre = (string)reader["Usu_ApellidoNombre"];
                oUser.Rol_Codigo = (int)reader["Rol_Codigo"];
            }

            cnn.Close();
            return oUser;
        }
    }
}
