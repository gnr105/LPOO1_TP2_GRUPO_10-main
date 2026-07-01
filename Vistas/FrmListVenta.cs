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
            }
            else
            {
                MessageBox.Show("La fecha de inicio ('Desde') no puede ser mayor que la fecha de fin ('Hasta').", "Atención");
            }
        }

        private void btnEliminarVenta_Click(object sender, EventArgs e)
        {
            // 1. Validar que el usuario haya seleccionado una fila en tu grilla real 'dgwVenta'
            if (dgwVenta.CurrentRow != null)
            {
                // 2. Pedir confirmación al usuario antes del borrado
                DialogResult result = MessageBox.Show(
                    "¿Está seguro de que desea eliminar la venta seleccionada?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // 3. Capturar el ID usando tu grilla 'dgwVenta' y la columna 'Ven_Nro'
                        int ventaId = Convert.ToInt32(dgwVenta.CurrentRow.Cells["Nro_Venta"].Value);

                        // 4. Llamar al método de tu clase estática 'TrabajarVenta'
                        TrabajarVenta.EliminarVenta(ventaId);

                        // 5. El mensaje informativo que te pide la consigna 📢
                        MessageBox.Show(
                            "La venta ha sido eliminada correctamente de los registros.",
                            "Venta Eliminada",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        // 6. Refrescar la grilla llamando a tu método real
                        load_ventas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error al intentar eliminar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una venta de la lista para poder eliminarla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
