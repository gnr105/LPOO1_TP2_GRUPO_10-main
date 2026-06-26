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
    public partial class FrmListaProductos : Form
    {
        public FrmListaProductos()
        {
            InitializeComponent();
        }

        private void FrmListaProductos_Load(object sender, EventArgs e)
        {
            load_combo_clientes();
            load_productos();
        }
        private void load_combo_clientes()
        {
            cmbClientes.DisplayMember = "NombreCompleto";
            cmbClientes.ValueMember = "Cli_DNI";
            cmbClientes.DataSource = TrabajarVenta.list_clientes();
        }


        private void load_productos()
        {
            dgwProductos.DataSource = TrabajarProducto.listarProd();
            ActualizarContadorProductos();
        }

        // Puntos 6 y 7: actualiza el label al pie de la grilla con la cantidad de productos vendidos
        private void ActualizarContadorProductos()
        {
            int cantidad = (dgwProductos.DataSource != null) ? dgwProductos.Rows.Count : 0;
            lblCantidadProductos.Text = "Cantidad de productos: " + cantidad;
        }

        private void btnBuscarFecha_Click(object sender, EventArgs e)
        {
            DateTime fi = dtpFechaInicio.Value.Date;
            DateTime ff = dtpFechaFinal.Value.Date;

            dgwProductos.DataSource = TrabajarProducto.listar_prod_por_fecha(fi, ff);
            ActualizarContadorProductos();
        }

        private void btnBuscarPorCliente_Click(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedValue != null)
            {
                string dni = cmbClientes.SelectedValue.ToString();
                DataTable dtProductos = TrabajarVenta.listar_productos_por_cliente(dni);
                if (dtProductos.Rows.Count > 0)
                {
                    dgwProductos.DataSource = dtProductos;

                }
                else
                {
                    MessageBox.Show("El cliente seleccionado no registra compras de productos.", "Información");
                    dgwProductos.DataSource = null;
                }
                ActualizarContadorProductos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente de la lista.", "Atención");
            }
        }

        

        

    

    }
}
