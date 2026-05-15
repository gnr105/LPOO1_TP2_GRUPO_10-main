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
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text;
            string pass = txtContraseña.Text;

            Usuario usuarioValido = TrabajarUsuario.validar_login(user, pass);

            if (usuarioValido != null)
            {
                MessageBox.Show("Bienvenido " + usuarioValido.Usu_ApellidoNombre, "Ingreso exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Principal frmPrincipal = new Principal(usuarioValido);
                this.Hide();
                frmPrincipal.ShowDialog(this);
                
                txtUsuario.Clear();
                txtContraseña.Clear();
                this.Show();

            }
            else
            {
                MessageBox.Show("Usuario o Contraseña Incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContraseña.Clear();
                txtUsuario.Clear();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var ee = MessageBox.Show("Desea Salir?", "Atencion", MessageBoxButtons.OKCancel);
            if (ee.Equals(DialogResult.OK))
            {
                Application.Exit();
            }
        
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_MouseHover(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.PaleVioletRed;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.FlatStyle = FlatStyle.Popup;
            btnCancelar.Font = new Font(btnCancelar.Font, FontStyle.Bold);
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.White;
            btnCancelar.ForeColor = Color.Black;
            btnCancelar.FlatStyle = FlatStyle.Standard;
            btnCancelar.Font = new Font(btnCancelar.Font, FontStyle.Regular);
        }

        private void btnIngresar_MouseHover(object sender, EventArgs e)
        {
            btnIngresar.BackColor = Color.MediumSeaGreen;
            btnIngresar.ForeColor = Color.White;
            btnIngresar.FlatStyle = FlatStyle.Popup;
            btnIngresar.Font = new Font(btnIngresar.Font, FontStyle.Bold);
        }

        private void btnIngresar_MouseLeave(object sender, EventArgs e)
        {
            btnIngresar.BackColor = Color.White;
            btnIngresar.ForeColor = Color.Black;
            btnIngresar.FlatStyle = FlatStyle.Standard;
            btnIngresar.Font = new Font(btnIngresar.Font, FontStyle.Regular);
        }
        

    }
}
