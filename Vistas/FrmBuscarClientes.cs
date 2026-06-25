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
    public partial class FrmBuscarClientes : Form
    {
        public string DniSeleccionado { get; private set; }
        public string ClienteSeleccionado { get; private set; }
        public FrmBuscarClientes()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();

        }

        private void ActualizarGrilla()
        {
            string dni = txtDNI.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string nombre = txtNombre.Text.Trim();

            string orden = "Apellido";

            if (cmbOrden.SelectedItem != null)
            {
                orden = cmbOrden.SelectedItem.ToString();
            }
            dgvClientes.DataSource = TrabajarCliente.buscar_clientes_avanzado(dni, apellido, nombre, orden);
        }

        private void dgvClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DniSeleccionado = dgvClientes.Rows[e.RowIndex].Cells[0].Value.ToString();

                ClienteSeleccionado = dgvClientes.Rows[e.RowIndex].Cells["Apellido"].Value.ToString() + ", " +
                                      dgvClientes.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void FrmBuscarClientes_Load(object sender, EventArgs e)
        {
            cmbOrden.Items.Add("Apellido");
            cmbOrden.Items.Add("Nombre");
            cmbOrden.Items.Add("DNI");

            //ordena por apellido si no elije otro
            cmbOrden.SelectedIndex = 0;

            // si queremos mostrar todos los clientes apenas carfa el form, descomentamos esta linea
            //ActualizarGrilla();
        }


        


    }
}
