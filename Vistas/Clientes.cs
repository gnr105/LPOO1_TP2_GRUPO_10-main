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
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
            ThemeHelper.Apply(this);
        }

        private void load_clientes()
        {
            dgwClientes.DataSource = TrabajarCliente.list_client();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente oCliente = new Cliente();
            oCliente.Cli_DNI = txtDNI.Text;
            oCliente.Cli_Apellido = txtApellido.Text;
            oCliente.Cli_Nombre = txtNombre.Text;
            oCliente.Cli_Direccion = txtDireccion.Text;
            oCliente.OS_CUIT = txtObraSocial.Text;
            oCliente.Cli_NroCarnet = txtNroCarnet.Text;

            TrabajarCliente.insert_cliente(oCliente);

            MessageBox.Show("Cliente registrado con éxito");

            // Limpiar campos
            limpiar_campos();

            load_clientes();
        }

        private void btnGuardar_MouseHover(object sender, EventArgs e)
        {
            btnGuardar.BackColor = Color.LightGreen;
            btnGuardar.Font = new Font(btnGuardar.Font, FontStyle.Bold);
        }

        private void btnGuardar_MouseLeave(object sender, EventArgs e)
        {
            btnGuardar.BackColor = DefaultBackColor;
            btnGuardar.Font = new Font(btnGuardar.Font, FontStyle.Regular);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            load_clientes();
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtPattern.Text != "")
            {
                dgwClientes.DataSource = TrabajarCliente.search_clientes(txtPattern.Text);
            }
            else
            {
                load_clientes();
            }
        }

        private void dgwClientes_CurrentCellChanged(object sender, EventArgs e)
        {

            if (dgwClientes.CurrentRow != null && dgwClientes.CurrentRow.Cells["DNI"].Value != DBNull.Value)
            {
                txtDNI.Text = dgwClientes.CurrentRow.Cells["DNI"].Value.ToString();
                txtDNI.Enabled = false;
                txtApellido.Text = dgwClientes.CurrentRow.Cells["Apellido"].Value.ToString();
                txtNombre.Text = dgwClientes.CurrentRow.Cells["Nombre"].Value.ToString();
                txtDireccion.Text = dgwClientes.CurrentRow.Cells["Direccion"].Value.ToString();
                txtObraSocial.Text = dgwClientes.CurrentRow.Cells["Obrasocial"].Value.ToString();
                txtNroCarnet.Text = dgwClientes.CurrentRow.Cells["NroCarnet"].Value.ToString();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgwClientes.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("¿Desea guardar los cambios para este cliente?", "Modificar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Cliente oCliente = new Cliente();
                    oCliente.Cli_DNI = txtDNI.Text; // El DNI no debería cambiar si es PK
                    oCliente.Cli_Apellido = txtApellido.Text;
                    oCliente.Cli_Nombre = txtNombre.Text;
                    oCliente.Cli_Direccion = txtDireccion.Text;
                    oCliente.OS_CUIT = txtObraSocial.Text;
                    oCliente.Cli_NroCarnet = txtNroCarnet.Text;

                    TrabajarCliente.update_cliente(oCliente);
                    MessageBox.Show("Cliente actualizado correctamente");
                    load_clientes();
                    limpiar_campos();
                }
            }
        }
        private void limpiar_campos()
        {
            txtDNI.Text = "";
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtObraSocial.Text = "";
            txtNroCarnet.Text = "";
            txtDNI.Enabled = true;
            txtDNI.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgwClientes.CurrentRow != null)
            {
                string dni = dgwClientes.CurrentRow.Cells["DNI"].Value.ToString();
                string nombre = dgwClientes.CurrentRow.Cells["Apellido"].Value.ToString();

                DialogResult result = MessageBox.Show("¿Eliminar al cliente " + nombre + "?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    TrabajarCliente.delete_cliente(dni);
                    load_clientes();
                    limpiar_campos();
                }
            }
        }

        private void txtPattern_TextChanged(object sender, EventArgs e)
        {
            if (txtPattern.Text != "")
                dgwClientes.DataSource = TrabajarCliente.search_clientes(txtPattern.Text);
            else
                load_clientes();
        }

        private void btnListarOrdenado_Click(object sender, EventArgs e)
        {
            dgwClientes.DataSource = TrabajarCliente.list_clientes_ordenados();
        }


    }
}