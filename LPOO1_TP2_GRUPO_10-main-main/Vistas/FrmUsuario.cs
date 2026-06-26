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
        private Usuario usAct;

        public FrmUsuario(Usuario user)
        {
            InitializeComponent();
            usAct = user;
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

            load_usuarios(); // Esto ahora funcionará sin el error del 'as'
            limpiar_campos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtPattern.Text != "")
            {
                dgwUsuarios.DataSource = TrabajarUsuario.search_usuarios(txtPattern.Text);
            }
            else {
                load_usuarios();
            }
        }

        private void dgwUsuarios_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgwUsuarios.CurrentRow != null) {
                

                txtUsuario.Text = dgwUsuarios.CurrentRow.Cells["Usuario"].Value.ToString();
                txtContraseña.Text = dgwUsuarios.CurrentRow.Cells["Contraseña"].Value.ToString();
                txtApellidoyNombre.Text = dgwUsuarios.CurrentRow.Cells["ApellidoNombre"].Value.ToString();
                cmbRol_Codigo.SelectedValue = dgwUsuarios.CurrentRow.Cells["Rol_Codigo"].Value;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // 1. Validar que haya una fila seleccionada
            if (dgwUsuarios.CurrentRow != null)
            {
                // 2. Preguntar confirmación al usuario (opcional pero recomendado)
                DialogResult result = MessageBox.Show("¿Está seguro de modificar este usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Usuario oUser = new Usuario();
                    // IMPORTANTE: Obtenemos el ID de la fila seleccionada
                    oUser.Usu_ID = (int)dgwUsuarios.CurrentRow.Cells["Usu_ID"].Value;

                    oUser.Usu_NombreUsuario = txtUsuario.Text;
                    oUser.Usu_Contrasenia = txtContraseña.Text;
                    oUser.Usu_ApellidoNombre = txtApellidoyNombre.Text;
                    oUser.Rol_Codigo = (int)cmbRol_Codigo.SelectedValue;

                    // 3. Llamar al método de actualización
                    TrabajarUsuario.update_usuario(oUser);

                    MessageBox.Show("Usuario actualizado con éxito");

                    load_usuarios(); // Recargar la grilla
                    limpiar_campos(); // Podés crear un método para no repetir código
                }
            }
            else
            {
                MessageBox.Show("Seleccione un usuario de la lista");
            }
        }

        private void limpiar_campos()
        {
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            txtApellidoyNombre.Text = "";

            // Para el combo, generalmente volvemos al primer elemento
            if (cmbRol_Codigo.Items.Count > 0)
            {
                cmbRol_Codigo.SelectedIndex = 0;
            }

            // Opcional: Ponemos el foco de nuevo en el primer TXT
            txtUsuario.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgwUsuarios.CurrentRow != null)
            {
                int idEliminar = (int)dgwUsuarios.CurrentRow.Cells["Usu_ID"].Value;
                
                //TrabajarUsuario.delete_usuario(idEliminar);
                string validacion = TrabajarUsuario.validar_usuario(
                    idEliminar,
                    usAct.Usu_ID
                );

                if (validacion != "")
                {
                    MessageBox.Show(validacion);
                    return;
                }

                TrabajarUsuario.delete_usuario(idEliminar);

                MessageBox.Show("Usuario eliminado");
                load_usuarios();
            }
        }


    }
}
