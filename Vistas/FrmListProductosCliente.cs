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
    public partial class FrmListProductosCliente : Form
    {
        public FrmListProductosCliente()
        {
            InitializeComponent();
        }

        private void FrmListProductosCliente_Load(object sender, EventArgs e)
        {
            cmbClientes.DisplayMember = "NombreCompleto";
            cmbClientes.ValueMember = "Cli_DNI";
            cmbClientes.DataSource = TrabajarVenta.list_clientes();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedValue != null)
            {
                string dni = cmbClientes.SelectedValue.ToString();
                dgvProductos.DataSource = TrabajarVenta.listar_productos_x_cliente(dni);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente.");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
