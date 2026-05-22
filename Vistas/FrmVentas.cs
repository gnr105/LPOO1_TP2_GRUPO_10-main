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
        }
        private void FrmVentas_Load_1(object sender, EventArgs e)
        {
            load_combo_clientes();
            load_combo_productos();
            configurar_grilla();
        }
       

        private void load_combo_clientes()
        {
            cmbClientes.DisplayMember = "NombreCompleto";
            cmbClientes.ValueMember = "Cli_DNI";
            cmbClientes.DataSource = TrabajarVenta.list_clientes();
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
            if (dgvDetalle.Rows.Count > 0)
            {
                DateTime fecha = dtpFecha.Value;
                string dni = cmbClientes.SelectedValue.ToString();

                // 1. Creamos un DataTable con la misma estructura que necesita la BD
                DataTable dtDetalles = new DataTable();
                dtDetalles.Columns.Add("Codigo", typeof(string));
                dtDetalles.Columns.Add("Precio", typeof(decimal));
                dtDetalles.Columns.Add("Cantidad", typeof(decimal));
                dtDetalles.Columns.Add("Total", typeof(decimal));

                // 2. Recorremos la grilla visual y copiamos los datos al DataTable
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    if (!row.IsNewRow) // Ignoramos la fila vacía del final
                    {
                        dtDetalles.Rows.Add(
                            row.Cells["Codigo"].Value,
                            row.Cells["Precio"].Value,
                            row.Cells["Cantidad"].Value,
                            row.Cells["Total"].Value
                        );
                    }
                }

                // 3. Llamamos al método de ClaseBase pasándole el DataTable puro
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

            if (cmbClientes.Items.Count > 0) cmbClientes.SelectedIndex = 0;
            if (cmbProductos.Items.Count > 0) cmbProductos.SelectedIndex = 0;
        }
        
    }
}
