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

            // Agregué espacios al final de cada línea para evitar que se peguen las palabras
            cmd.CommandText = "SELECT ";
            cmd.CommandText += "Usu_NombreUsuario as 'Usuario', ";
            cmd.CommandText += "Usu_Contraseña as 'Contraseña', ";
            cmd.CommandText += "Usu_ApellidoNombre as 'ApellidoNombre', "; // Faltaba una coma aquí
            cmd.CommandText += "Rol_Descripcion as 'Rol', "; // Aquí la coma estaba bien, pero faltaba el espacio
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
    }
}
