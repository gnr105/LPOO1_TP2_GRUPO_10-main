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
            ThemeHelper.Apply(this);
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            dgwVenta.AllowUserToAddRows = false;
            load_combo_clientes();

            load_ventas();
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
            ActualizarContadorVentas();
        }

        // Punto 4 y 5: actualiza el label al pie de la grilla con la cantidad de ventas mostradas
        private void ActualizarContadorVentas()
        {
            int cantidad = (dgwVenta.DataSource != null) ? dgwVenta.Rows.Count : 0;
            lblCantidadVentas.Text = "Cantidad de ventas: " + cantidad;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedValue != null)
            {
                string dni = cmbClientes.SelectedValue.ToString();
                DataTable dtProductos = TrabajarVenta.listar_ventas_x_cliente(dni);
                if (dtProductos.Rows.Count > 0)

                {
                    dgwVenta.DataSource = dtProductos;

                }
                else
                {
                    MessageBox.Show("El cliente seleccionado no registra ventas.", "Información");
                    dgwVenta.DataSource = null;
                }
                ActualizarContadorVentas();
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
                ActualizarContadorVentas();
            }
            else
            {
                MessageBox.Show("La fecha de inicio ('Desde') no puede ser mayor que la fecha de fin ('Hasta').", "Atención");
            }
        }

        // Punto 3: baja (eliminacion) de ventas
        private void btnEliminarVenta_Click(object sender, EventArgs e)
        {
            if (dgwVenta.CurrentRow == null || dgwVenta.DataSource == null)
            {
                MessageBox.Show("Por favor, seleccione una venta de la grilla para eliminar.", "Atención");
                return;
            }

            object valorNro;
            if (dgwVenta.Columns.Contains("Nro_Venta"))
                valorNro = dgwVenta.CurrentRow.Cells["Nro_Venta"].Value;
            else if (dgwVenta.Columns.Contains("Ven_Nro"))
                valorNro = dgwVenta.CurrentRow.Cells["Ven_Nro"].Value;
            else
            {
                MessageBox.Show("No se encontró la columna de número de venta en la grilla.", "Atención");
                return;
            }

            if (valorNro == null || valorNro == DBNull.Value)
            {
                MessageBox.Show("No se pudo determinar el número de venta seleccionado.", "Atención");
                return;
            }

            int nroVenta = Convert.ToInt32(valorNro);

            DialogResult result = MessageBox.Show(
                "¿Está seguro que desea eliminar la venta N° " + nroVenta + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    TrabajarVenta.delete_venta(nroVenta);
                    MessageBox.Show("La venta fue eliminada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_ventas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al eliminar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

  
        
       
    }
}
