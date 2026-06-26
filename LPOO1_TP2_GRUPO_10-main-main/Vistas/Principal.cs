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
        public Principal(Usuario user)
        {
            InitializeComponent();
            this.usuarioLogueado = user;
            aplicar_restricciones();
        }

        private void aplicar_restricciones()
        {


            if (usuarioLogueado.Rol_Codigo == 1)
            {
                btnGUsuario.Enabled = true;
                btnGProduct.Enabled = true;
                btnListProd.Enabled = true;
                btnGCliente.Enabled = false;
                btnGCliente.Enabled = false; 
                btnGVenta.Enabled = false;
            }
            else if (usuarioLogueado.Rol_Codigo == 2)
            {
                btnGUsuario.Enabled = false;
                btnGProduct.Enabled = false;
                btnGCliente.Enabled = true;
                btnGVenta.Enabled = true;
                btnListProd.Enabled = false;
                btnListVentas.Enabled = true;
            }
            else if (usuarioLogueado.Rol_Codigo == 3) 
            {
                btnGUsuario.Enabled = true;
                btnGProduct.Enabled = true;
                btnGCliente.Enabled = true;
                btnGVenta.Enabled = true;
                btnGOS.Enabled = true;
                btnListProd.Enabled = true;
                btnListVentas.Enabled = true;
            }
        }

        private void sistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }


        private void Principal_Load(object sender, EventArgs e)
        {
            Rol rolUsuario = RolService.ObtenerRolPorCodigo(usuarioLogueado.Rol_Codigo);

            if (rolUsuario != null)
            {
                
                this.Text = "Principal - Usuario: " + usuarioLogueado.Usu_ApellidoNombre + " - Rol: " + rolUsuario.Rol_Descripcion;

                lblBienvenida.Text = "Bienvenido! " + usuarioLogueado.Usu_ApellidoNombre + " - " + rolUsuario.Rol_Descripcion;
            }
            else
            {
                this.Text = "Principal - Usuario: " + usuarioLogueado.Usu_ApellidoNombre;

                
                lblBienvenida.Text = "Bienvenido! " + usuarioLogueado.Usu_ApellidoNombre;
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
            FrmUsuario frmUsuario = new FrmUsuario(usuarioLogueado);
            frmUsuario.Show();
        }

        private void btnGCliente_Click(object sender, EventArgs e)
        {
            Clientes frmCliente = new Clientes();
            frmCliente.Show();
        }

        private void btnGProduct_Click(object sender, EventArgs e)
        {
            Productos frmProductos = new Productos();
            frmProductos.Show();
        }

        private void btnGOS_Click(object sender, EventArgs e)
        {
            ObrasSociales frmObraSocial = new ObrasSociales();
            frmObraSocial.Show();
        }

        private void btnGVenta_Click(object sender, EventArgs e)
        {
            FrmVentas frmVenta = new FrmVentas();
            frmVenta.Show();
        }

        private void btnListVentas_Click(object sender, EventArgs e)
        {
            FrmListVenta frmListVentas = new FrmListVenta();
            frmListVentas.Show();
        }

        private void btnListProd_Click(object sender, EventArgs e)
        {
            FrmListaProductos frmListaProductos = new FrmListaProductos();
            frmListaProductos.Show();
        }

        private void btnListClientesOS_Click(object sender, EventArgs e)
        {
            FrmClientesPorObraSocial frmClientesOS = new FrmClientesPorObraSocial();
            frmClientesOS.Show();
        }
    }
}
