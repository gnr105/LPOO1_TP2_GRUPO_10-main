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
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente oCliente = new Cliente();

            oCliente.Cli_DNI = txtDNI.Text;
            oCliente.Cli_Apellido = txtApellido.Text;
            oCliente.Cli_Nombre = txtNombre.Text;
            oCliente.Direccion = txtDireccion.Text;
            oCliente.OS_CUIT = txtObraSocial.Text;
            oCliente.Cli_NroCarnet = txtNroCarnet.Text;

            string mensaje = string.Format("Confirme los datos:\nDNI: {0}\nApellido: {1}\nNombre: {2}\nDireccion: {3}\nObra Social: {4}\nNro Carnet: {5:C}",
                                            oCliente.Cli_DNI,
                                            oCliente.Cli_Apellido,
                                            oCliente.Cli_Nombre,
                                            oCliente.Direccion,
                                            oCliente.OS_CUIT,
                                            oCliente.Cli_NroCarnet);

            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
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

        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
