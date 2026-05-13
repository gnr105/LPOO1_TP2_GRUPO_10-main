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
                // 1. Instanciar la clase Producto
                Producto oProducto = new Producto();

                // 2. Cargar los datos desde los TextBox
                oProducto.Prod_Codigo = txtCodigoProd.Text;
                oProducto.Prod_Categoria = txtCategoriaProd.Text;
                oProducto.Prod_Descripcion = txtDescripcionProd.Text;

                // 3. Convertir el texto a decimal (Cuidado con la coma/punto según tu región)
                oProducto.Prod_Precio = Convert.ToDecimal(txtPrecioProd.Text);

                // 4. Mostrar mensaje de confirmación (Punto 8 del PDF)
                string mensaje = string.Format("Producto guardado correctamente:\nCódigo: {0}\nDescripción: {1}\nPrecio: {2:C}",
                                                oProducto.Prod_Codigo,
                                                oProducto.Prod_Descripcion,
                                                oProducto.Prod_Precio);

                MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Opcional: Limpiar los campos después de guardar
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
