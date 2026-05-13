using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClaseBase;

namespace Vistas
{
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            load_combo_roles();
        }
        private void load_combo_roles() {
            cmbRol_Codigo.DisplayMember = "Rol_Descripcion";
            cmbRol_Codigo.ValueMember = "Rol_Codigo";
            cmbRol_Codigo.DataSource = TrabajarUsuario.list_roles();
        }
        private void load_usuarios()
        {
            dgwUsuarios.DataSource = TrabajarUsuario.list_usuarios();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario oUser = new Usuario();
            oUser.Usu_NombreUsuario = txtUsuario.Text;
            oUser.Usu_Contrasenia = txtContraseña.Text;
            oUser.Usu_ApellidoNombre = txtApellidoyNombre.Text;
            oUser.Rol_Codigo = (int)cmbRol_Codigo.SelectedValue;

            TrabajarUsuario.insert_usuario(oUser);

            MessageBox.Show("Usuario registrado con éxito"); // Feedback

            // Limpiar campos
            txtUsuario.Clear();
            txtContraseña.Clear();
            txtApellidoyNombre.Clear();

            load_usuarios(); // Esto ahora funcionará sin el error del 'as'
        }
    }
}
