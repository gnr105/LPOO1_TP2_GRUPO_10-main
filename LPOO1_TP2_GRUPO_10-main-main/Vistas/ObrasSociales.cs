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
    public partial class ObrasSociales : Form
    {
        public ObrasSociales()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ObraSocial oObraSoc = new ObraSocial();

            oObraSoc.OS_CUIT = txtCuit.Text;
            oObraSoc.OS_RazonSocial = txtRazonSocial.Text;
            oObraSoc.OS_Direccion = txtDireccion.Text;
            oObraSoc.OS_Telefono = txtTelefono.Text;

            string mensaje = string.Format("Confirme los datos:\nCUIT: {0}\nRazon Social: {1}\nDireccion: {2}\nTelefono: {3:C}",
                                            oObraSoc.OS_CUIT,
                                            oObraSoc.OS_RazonSocial,
                                            oObraSoc.OS_Direccion,
                                            oObraSoc.OS_Telefono);

            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
