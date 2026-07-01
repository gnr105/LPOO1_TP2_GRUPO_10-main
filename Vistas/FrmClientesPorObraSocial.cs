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
    public partial class FrmClientesPorObraSocial : Form
    {
        public FrmClientesPorObraSocial()
        {
            InitializeComponent();
            ThemeHelper.Apply(this);
        }

        private void FrmClientesPorObraSocial_Load(object sender, EventArgs e)
        {
            dgvClientes.AllowUserToAddRows = false;
            load_combo_obrasocial();
        }

        private void load_combo_obrasocial()
        {
            cmbObraSocial.DisplayMember = "RazonSocial";
            cmbObraSocial.ValueMember = "CUIT";
            cmbObraSocial.DataSource = TrabajarObraSocial.list_obrasociales();
        }

        // Punto 8: lista los clientes afiliados a la obra social seleccionada
        // y muestra al pie de la grilla la cantidad de clientes encontrados.
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbObraSocial.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione una obra social de la lista.", "Atención");
                return;
            }

            string cuit = cmbObraSocial.SelectedValue.ToString();
            DataTable dtClientes = TrabajarObraSocial.list_clientes_por_obrasocial(cuit);

            if (dtClientes.Rows.Count > 0)
            {
                dgvClientes.DataSource = dtClientes;
            }
            else
            {
                MessageBox.Show("No hay clientes afiliados a la obra social seleccionada.", "Información");
                dgvClientes.DataSource = null;
            }

            ActualizarContadorClientes();
        }

        private void ActualizarContadorClientes()
        {
            int cantidad = (dgvClientes.DataSource != null) ? dgvClientes.Rows.Count : 0;
            lblCantidadClientes.Text = "Cantidad de clientes: " + cantidad;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
