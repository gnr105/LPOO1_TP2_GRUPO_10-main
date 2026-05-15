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
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
              
                Producto oProducto = new Producto();
           
                oProducto.Prod_Codigo = txtCodigoProd.Text;
                oProducto.Prod_Categoria = txtCategoriaProd.Text;
                oProducto.Prod_Descripcion = txtDescripcionProd.Text;

                oProducto.Prod_Precio = Convert.ToDecimal(txtPrecioProd.Text);

                string mensaje = string.Format("Producto guardado correctamente:\nCódigo: {0}\nDescripción: {1}\nPrecio: {2:C}",
                                                oProducto.Prod_Codigo,
                                                oProducto.Prod_Descripcion,
                                                oProducto.Prod_Precio);

                MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: Verifique que el precio sea un número válido. " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtCodigoProd.Clear();
            txtCategoriaProd.Clear();
            txtDescripcionProd.Clear();
            txtPrecioProd.Clear();
        }

        private void btnGuardar_MouseHover(object sender, EventArgs e)
        {
            btnGuardar.BackColor = Color.LightGreen;
            btnGuardar.Font = new Font(btnGuardar.Font, FontStyle.Bold);
        }

        private void btnGuardar_MouseLeave(object sender, EventArgs e)
        {
            btnGuardar.BackColor = DefaultBackColor;
            btnGuardar.Font = new Font(btnGuardar.Font, FontStyle.Regular);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Productos_Load(object sender, EventArgs e)
        {

        }

    }
}
