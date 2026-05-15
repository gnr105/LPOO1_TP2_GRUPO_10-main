using System;
using System.Data;
using System.Windows.Forms;
using ClaseBase;


namespace Vistas
{
    public partial class Ventas : Form
    {
        // Usamos la ruta completa para forzar a Visual Studio a encontrar los adaptadores
        ClaseBase.opticaDataSetTableAdapters.ClienteTableAdapter adpCli = new ClaseBase.opticaDataSetTableAdapters.ClienteTableAdapter();
        ClaseBase.opticaDataSetTableAdapters.ProductoTableAdapter adpProd = new ClaseBase.opticaDataSetTableAdapters.ProductoTableAdapter();
        ClaseBase.opticaDataSetTableAdapters.VentasTableAdapter adpVenta = new ClaseBase.opticaDataSetTableAdapters.VentasTableAdapter();
        ClaseBase.opticaDataSetTableAdapters.Venta_DetalleTableAdapter adpDetalle = new ClaseBase.opticaDataSetTableAdapters.Venta_DetalleTableAdapter();

        public Ventas()
        {
            InitializeComponent();
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            try
            {
                // Llenamos los combos (Punto 7 del TP)
                cmbClientes.DataSource = adpCli.GetData();
                cmbClientes.DisplayMember = "Cli_Apellido";
                cmbClientes.ValueMember = "Cli_DNI";

                cmbProductos.DataSource = adpProd.GetData();
                cmbProductos.DisplayMember = "Prod_Descripcion";
                cmbProductos.ValueMember = "Prod_Codigo";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        // Botón para agregar productos a la grilla
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowView prod = (DataRowView)cmbProductos.SelectedItem;
                decimal precio = Convert.ToDecimal(prod["Prod_Precio"]);
                decimal cant = Convert.ToDecimal(txtCantidad.Text); // Usando txtCantidad
                decimal total = precio * cant;

                // Agregamos a la grilla: Código, Descripción, Precio, Cantidad y Total
                dgvDetalle.Rows.Add(prod["Prod_Codigo"], prod["Prod_Descripcion"], precio, cant, total);
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor, ingresá un número válido en Cantidad.");
            }
        }

        // Botón para guardar la Venta y el Detalle (Punto 7 completo)
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Reemplacé txtNroVenta por un número fijo o autoincremental si no tenés el cuadro
                // Si tenés un cuadro para el número, cambialo por el nombre que le hayas puesto
                int nroVenta = 1;
                DateTime fecha = dtpFecha.Value;
                string dni = cmbClientes.SelectedValue.ToString();

                // 1. Guardar en tabla Venta
                adpVenta.Insert(nroVenta, fecha, dni);

                // 2. Guardar cada fila de la grilla en VentaDetalle
                foreach (DataGridViewRow fila in dgvDetalle.Rows)
                {
                    if (fila.Cells[0].Value != null)
                    {
                        adpDetalle.Insert(
                            nroVenta,
                            Convert.ToInt32(fila.Cells[0].Value),
                            Convert.ToDecimal(fila.Cells[2].Value),
                            Convert.ToDecimal(fila.Cells[3].Value),
                            Convert.ToDecimal(fila.Cells[4].Value)
                        );
                    }
                }
                MessageBox.Show("Venta registrada con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message);
            }
        }
    }
}