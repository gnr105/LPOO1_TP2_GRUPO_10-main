using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using ClaseBase;
using System.Text;
using System.Windows.Forms;

namespace Vistas
{
    public partial class FrmListVenta : Form
    {
        public FrmListVenta()
        {
            InitializeComponent();
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            load_combo_clientes();
        }
        private void load_combo_clientes()
        {
            cmbClientes.DisplayMember = "NombreCompleto";
            cmbClientes.ValueMember = "Cli_DNI";
            cmbClientes.DataSource = TrabajarVenta.list_clientes();        
        }

        private void load_ventas()
        {
            dgwVenta.DataSource = TrabajarVenta.list_venta();
        }
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedValue != null)
            {
                string dni = cmbClientes.SelectedValue.ToString();
                dgwVenta.DataSource = TrabajarVenta.listar_ventas_x_cliente(dni);
            }
            else
            {
                MessageBox.Show("Seleccione un cliente.");
            }
        }


        private void btnSalir_MouseHover(object sender, EventArgs e)
        {
            btnSalir.BackColor = Color.PaleVioletRed;
            btnSalir.ForeColor = Color.White;
            btnSalir.FlatStyle = FlatStyle.Popup;
            btnSalir.Font = new Font(btnSalir.Font, FontStyle.Bold);
        }


        private void btnSalir_MouseLeave(object sender, EventArgs e)
        {
            btnSalir.BackColor = Color.White;
            btnSalir.ForeColor = Color.Black;
            btnSalir.FlatStyle = FlatStyle.Standard;
            btnSalir.Font = new Font(btnSalir.Font, FontStyle.Regular);
        }
        
        

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        
       
    }
}
