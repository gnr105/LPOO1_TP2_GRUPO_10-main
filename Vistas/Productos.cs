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

        private void Productos_Load(object sender, EventArgs e)
        {

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Producto oProducto = new Producto();

            oProducto.Prod_Codigo = txtCodigoProd.Text;
            oProducto.Prod_Categoria = txtCategoriaProd.Text;
            oProducto.Prod_Descripcion = txtDescripcionProd.Text;
            oProducto.Prod_Precio = Convert.ToDecimal(txtPrecioProd.Text);

            TrabajarProducto.insert_producto(oProducto);

            string mensaje = string.Format("Producto guardado correctamente:\nCódigo: {0}\nDescripción: {1}\nPrecio: {2:C}",
                                            oProducto.Prod_Codigo,
                                            oProducto.Prod_Descripcion,
                                            oProducto.Prod_Precio);

            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarCampos();


            // btnListar_Click(null, null); 
        }
        
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtCodigoProd.Text == "")
            {
                MessageBox.Show("Debe seleccionar un producto.");
                return;
            }

            decimal precio;

            if (!decimal.TryParse(txtPrecioProd.Text, out precio))
            {
                MessageBox.Show("El precio ingresado no es válido.");
                return;
            }

            Producto oProducto = new Producto();

            oProducto.Prod_Codigo = txtCodigoProd.Text;
            oProducto.Prod_Categoria = txtCategoriaProd.Text;
            oProducto.Prod_Descripcion = txtDescripcionProd.Text;
            oProducto.Prod_Precio = precio;

            TrabajarProducto.update_producto(oProducto);

            MessageBox.Show("Producto actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarCampos();
            btnListar_Click(null, null);
        }
        
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCodigoProd.Text == "")
            {
                MessageBox.Show("Debe seleccionar un producto.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro que desea eliminar este producto?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                TrabajarProducto.delete_producto(txtCodigoProd.Text);

                MessageBox.Show("Producto eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
                btnListar_Click(null, null);
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

        private void btnListar_Click(object sender, EventArgs e)
        {
            string orden = "";

            if (rbCategoria.Checked)
            {
                orden = "Categoria";
            }
            else if (rbDescripcion.Checked)
            {
                orden = "Descripcion";
            }

            dgwProductos.DataSource = TrabajarProducto.list_productos_ordered(orden);
        }
        
        private void dgwProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCodigoProd.Text = dgwProductos.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
                txtCategoriaProd.Text = dgwProductos.Rows[e.RowIndex].Cells["Categoria"].Value.ToString();
                txtDescripcionProd.Text = dgwProductos.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
                txtPrecioProd.Text = dgwProductos.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
            }
        }
    }
}