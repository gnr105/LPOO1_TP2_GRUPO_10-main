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
    public partial class FrmVentas : Form
    {
        public FrmVentas()
        {
            InitializeComponent();
            ThemeHelper.Apply(this);
        }
        private void FrmVentas_Load_1(object sender, EventArgs e)
        {
            load_combo_productos();
            configurar_grilla();
        }
       

        private void load_combo_productos()
        {
            cmbProductos.DisplayMember = "Prod_Descripcion";
            cmbProductos.ValueMember = "Prod_Codigo";
            cmbProductos.DataSource = TrabajarVenta.list_productos();
        }

        private void cmbProductos_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedItem != null)
            {
                DataRowView prod = (DataRowView)cmbProductos.SelectedItem;
                txtPrecio.Text = prod["Prod_Precio"].ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "" && txtPrecio.Text != "")
            {
                decimal precio = Convert.ToDecimal(txtPrecio.Text);
                decimal cantidad = Convert.ToDecimal(txtCantidad.Text);
                decimal total = precio * cantidad;

                dgvDetalle.Rows.Add(cmbProductos.SelectedValue, cmbProductos.Text, precio, cantidad, total);

                txtCantidad.Text = "1";
            }
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Validamos que hayan buscado un cliente primero
            if (string.IsNullOrWhiteSpace(txtDniCliente.Text))
            {
                MessageBox.Show("Por favor, busque y seleccione un cliente.");
                return;
            }

            if (dgvDetalle.Rows.Count > 0)
            {
                DateTime fecha = dtpFecha.Value;

                // Ahora leemos el DNI desde el TextBox en lugar del ComboBox
                string dni = txtDniCliente.Text;

                DataTable dtDetalles = new DataTable();
                dtDetalles.Columns.Add("Codigo", typeof(string));
                dtDetalles.Columns.Add("Precio", typeof(decimal));
                dtDetalles.Columns.Add("Cantidad", typeof(decimal));
                dtDetalles.Columns.Add("Total", typeof(decimal));

                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        dtDetalles.Rows.Add(
                            row.Cells["Codigo"].Value,
                            row.Cells["Precio"].Value,
                            row.Cells["Cantidad"].Value,
                            row.Cells["Total"].Value
                        );
                    }
                }

                TrabajarVenta.insert_venta(fecha, dni, dtDetalles);

                MessageBox.Show("Venta registrada con éxito");
                limpiar_campos();
            }
            else
            {
                MessageBox.Show("Debe agregar al menos un producto.");
            }
        }
        

        private void configurar_grilla()
        {
            dgvDetalle.Columns.Add("Codigo", "Cód. Prod");
            dgvDetalle.Columns.Add("Descripcion", "Producto");
            dgvDetalle.Columns.Add("Precio", "Precio");
            dgvDetalle.Columns.Add("Cantidad", "Cant");
            dgvDetalle.Columns.Add("Total", "Subtotal");
        }

        private void limpiar_campos()
        {
            dgvDetalle.Rows.Clear();
            txtCantidad.Text = "1";
            txtPrecio.Text = "";
            dtpFecha.Value = DateTime.Now;

            // Limpiamos los datos del cliente
            txtDniCliente.Text = "";
            txtNombreCliente.Text = "";

            if (cmbProductos.Items.Count > 0) cmbProductos.SelectedIndex = 0;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmBuscarClientes buscarClientes = new FrmBuscarClientes();

            if (buscarClientes.ShowDialog() == DialogResult.OK)
            {
                txtDniCliente.Text = buscarClientes.DniSeleccionado;

                txtNombreCliente.Text = buscarClientes.ClienteSeleccionado;
            }
        }
        
    }
}
