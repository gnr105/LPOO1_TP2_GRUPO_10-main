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
        public static DataTable list_roles() {

            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM roles";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static void insert_usuario(Usuario user) {

            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Usuario(Usu_NombreUsuario, Usu_Contraseña, Usu_ApellidoNombre, Rol_Codigo) values(@user, @pss, @ape, @rol)";
            cmd.CommandType = CommandType.Text;
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

            cmd.CommandText = "SELECT ";
            cmd.CommandText += "Usu_NombreUsuario as 'Usuario', ";
            cmd.CommandText += "Usu_Contraseña as 'Contraseña', ";
            cmd.CommandText += "Usu_ApellidoNombre as 'ApellidoNombre', "; 
            cmd.CommandText += "Rol_Descripcion as 'Rol', "; 
            cmd.CommandText += "Usu_ID, U.Rol_Codigo ";
            cmd.CommandText += "FROM Usuario as U ";
            cmd.CommandText += "LEFT JOIN Roles as R ON (R.Rol_Codigo=U.Rol_Codigo)";

            cmd.CommandType = CommandType.Text;
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
            cmd.CommandText = "SELECT ";
            cmd.CommandText += "Usu_NombreUsuario as 'Usuario', ";
            cmd.CommandText += "Usu_Contraseña as 'Contraseña', ";
            cmd.CommandText += "Usu_ApellidoNombre as 'ApellidoNombre', "; 
            cmd.CommandText += "Rol_Descripcion as 'Rol', "; 
            cmd.CommandText += "Usu_ID, U.Rol_Codigo ";
            cmd.CommandText += "FROM Usuario as U ";
            cmd.CommandText += "LEFT JOIN Roles as R ON (R.Rol_Codigo=U.Rol_Codigo)";

            cmd.CommandText += "WHERE ";
            cmd.CommandText += "Usu_ApellidoNombre LIKE @pattern";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@pattern", "%"+sPattern+"%");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static void update_usuario(Usuario user)
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Usuario SET Usu_NombreUsuario=@user, Usu_Contraseña=@pss, Usu_ApellidoNombre=@ape, Rol_Codigo=@rol WHERE Usu_ID=@id";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            // Pasamos todos los parámetros, incluyendo el ID para el WHERE
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
            SqlCommand cmd = new SqlCommand("DELETE FROM Usuario WHERE Usu_ID=@id", cnn);
            cmd.Parameters.AddWithValue("@id", id);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static string validar_usuario(int idEliminar, int idLog)
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);
            cnn.Open();

            if (idEliminar == idLog)
            {
                cnn.Close();
                return "No puedes eliminar tu propia cuenta.";
            }

            cnn.Close();
            return "";
        }

        public static Usuario validar_login(string user, string pass)
        {
            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.opticaConnectionString);

            SqlCommand cmd = new SqlCommand();
            // Buscamos el usuario que coincida exactamente con ambos campos
            cmd.CommandText = "SELECT * FROM Usuario WHERE Usu_NombreUsuario=@user AND Usu_Contraseña=@pass";
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);

            cmd.Connection = cnn;
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
                // No es necesario guardar la contraseña en el objeto por seguridad
            }

            cnn.Close();
            return oUser; // Si no lo encuentra, devuelve null
        }
       
    }
}
