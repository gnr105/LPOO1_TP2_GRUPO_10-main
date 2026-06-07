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
                DataTable dtProductos = TrabajarVenta.listar_productos_por_cliente(dni);
                if (dtProductos.Rows.Count > 0)
                {
                    dgwVenta.DataSource = dtProductos;
                }
                else
                {
                    MessageBox.Show("El cliente seleccionado no registra compras de productos.", "Información");
                    dgwVenta.DataSource = null;
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente de la lista.", "Atención");
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

        private void btnBuscarPorFechas_Click(object sender, EventArgs e)
        {
            DateTime fechaDesde = dtpFechaDesde.Value;
            DateTime fechaHasta = dtpFechaHasta.Value;
            if (fechaDesde <= fechaHasta)
            {
                
                DataTable dtVentasFechas = TrabajarVenta.listar_ventas_por_fechas(fechaDesde, fechaHasta);

                if (dtVentasFechas.Rows.Count > 0)
                {
                    dgwVenta.DataSource = dtVentasFechas;
                }
                else
                {
                    MessageBox.Show("No se encontraron ventas registradas en ese rango de fechas.", "Información");
                    dgwVenta.DataSource = null; 
                }
            }
            else
            {
                MessageBox.Show("La fecha de inicio ('Desde') no puede ser mayor que la fecha de fin ('Hasta').", "Atención");
            }
        }
        
       
    }
}
