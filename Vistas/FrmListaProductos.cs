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
    public partial class FrmListaProductos : Form
    {
        public FrmListaProductos()
        {
            InitializeComponent();
        }

        private void FrmListaProductos_Load(object sender, EventArgs e)
        {
            load_productos();
        }

        private void load_productos()
        {
            dgwProductos.DataSource = TrabajarProducto.listarProd();
        }

        private void btnBuscarFecha_Click(object sender, EventArgs e)
        {
            DateTime fi = dtpFechaInicio.Value.Date;
            DateTime ff = dtpFechaFinal.Value.Date;

            dgwProductos.DataSource = TrabajarProducto.listar_prod_por_fecha(fi, ff);
        }

    }
}
