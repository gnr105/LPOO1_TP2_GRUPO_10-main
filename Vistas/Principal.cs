using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClaseBase;
using ClaseBase.Repositorio;

namespace Vistas
{
    public partial class Principal : Form
    {
        private Usuario usuarioLogueado;
        public Principal(Usuario usuario )
        {
            InitializeComponent();
            usuarioLogueado = usuario; 
        }

        private void sistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Hacer lo mismo que el boton aceptar para redirigir al formulario Sistema
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            Clientes frmCliente = new Clientes();
            frmCliente.Show();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            Productos frmProductos = new Productos();
            frmProductos.Show();
        }

        private void btnAddOS_Click(object sender, EventArgs e)
        {
            ObrasSociales frmObraSocial = new ObrasSociales();
            frmObraSocial.Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            Rol rolUsuario = RolService.ObtenerRolPorCodigo(usuarioLogueado.Rol_Codigo);

            if (rolUsuario != null)
            {
                this.Text = "Principal - Usuario: " + usuarioLogueado.Usu_ApellidoNombre + " - Rol: " + rolUsuario.Rol_Descripcion;
            }
            else
            {
                this.Text = "Principal - Usuario: " + usuarioLogueado.Usu_ApellidoNombre;
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            var ee = MessageBox.Show("Desea cerrar sesión?", "Atencion", MessageBoxButtons.OKCancel);
            
            if (ee.Equals(DialogResult.OK))
            {
                this.Close();
                
            }
            
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmUsuario frmUsuario = new FrmUsuario();
            frmUsuario.Show();
        }
    }
}
