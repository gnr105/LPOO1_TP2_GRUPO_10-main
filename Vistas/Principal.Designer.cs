namespace Vistas
{
    partial class Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGCliente = new System.Windows.Forms.Button();
            this.btnGOS = new System.Windows.Forms.Button();
            this.btnGProduct = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inquilinoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGUsuario = new System.Windows.Forms.Button();
            this.btnGVenta = new System.Windows.Forms.Button();
            this.btnListVentas = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGCliente
            // 
            this.btnGCliente.Location = new System.Drawing.Point(112, 94);
            this.btnGCliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGCliente.Name = "btnGCliente";
            this.btnGCliente.Size = new System.Drawing.Size(167, 28);
            this.btnGCliente.TabIndex = 0;
            this.btnGCliente.Text = "Gestion Cliente";
            this.btnGCliente.UseVisualStyleBackColor = true;
            this.btnGCliente.Click += new System.EventHandler(this.btnGCliente_Click);
            // 
            // btnGOS
            // 
            this.btnGOS.Location = new System.Drawing.Point(383, 134);
            this.btnGOS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGOS.Name = "btnGOS";
            this.btnGOS.Size = new System.Drawing.Size(167, 28);
            this.btnGOS.TabIndex = 1;
            this.btnGOS.Text = "Gestion Obra Social";
            this.btnGOS.UseVisualStyleBackColor = true;
            this.btnGOS.Click += new System.EventHandler(this.btnGOS_Click);
            // 
            // btnGProduct
            // 
            this.btnGProduct.Location = new System.Drawing.Point(112, 184);
            this.btnGProduct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGProduct.Name = "btnGProduct";
            this.btnGProduct.Size = new System.Drawing.Size(167, 28);
            this.btnGProduct.TabIndex = 2;
            this.btnGProduct.Text = "Gestion Producto";
            this.btnGProduct.UseVisualStyleBackColor = true;
            this.btnGProduct.Click += new System.EventHandler(this.btnGProduct_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(383, 289);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(167, 28);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Cerrar sesión";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sistemaToolStripMenuItem,
            this.inquilinoToolStripMenuItem,
            this.departamentoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(659, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.sistemaToolStripMenuItem.Text = "Sistema";
            this.sistemaToolStripMenuItem.Click += new System.EventHandler(this.sistemaToolStripMenuItem_Click);
            // 
            // inquilinoToolStripMenuItem
            // 
            this.inquilinoToolStripMenuItem.Name = "inquilinoToolStripMenuItem";
            this.inquilinoToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.inquilinoToolStripMenuItem.Text = "Inquilino";
            // 
            // departamentoToolStripMenuItem
            // 
            this.departamentoToolStripMenuItem.Name = "departamentoToolStripMenuItem";
            this.departamentoToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.departamentoToolStripMenuItem.Text = "Departamento";
            // 
            // btnGUsuario
            // 
            this.btnGUsuario.Location = new System.Drawing.Point(112, 259);
            this.btnGUsuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGUsuario.Name = "btnGUsuario";
            this.btnGUsuario.Size = new System.Drawing.Size(167, 28);
            this.btnGUsuario.TabIndex = 5;
            this.btnGUsuario.Text = "Gestion de Usuario";
            this.btnGUsuario.UseVisualStyleBackColor = true;
            this.btnGUsuario.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGVenta
            // 
            this.btnGVenta.Location = new System.Drawing.Point(383, 214);
            this.btnGVenta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGVenta.Name = "btnGVenta";
            this.btnGVenta.Size = new System.Drawing.Size(167, 28);
            this.btnGVenta.TabIndex = 6;
            this.btnGVenta.Text = "Gestion Venta";
            this.btnGVenta.UseVisualStyleBackColor = true;
            this.btnGVenta.Click += new System.EventHandler(this.btnGVenta_Click);
            // 
            // btnListVentas
            // 
            this.btnListVentas.Location = new System.Drawing.Point(371, 59);
            this.btnListVentas.Name = "btnListVentas";
            this.btnListVentas.Size = new System.Drawing.Size(188, 31);
            this.btnListVentas.TabIndex = 7;
            this.btnListVentas.Text = "Listado de Ventas";
            this.btnListVentas.UseVisualStyleBackColor = true;
            this.btnListVentas.Click += new System.EventHandler(this.btnListVentas_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 386);
            this.Controls.Add(this.btnListVentas);
            this.Controls.Add(this.btnGVenta);
            this.Controls.Add(this.btnGUsuario);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGProduct);
            this.Controls.Add(this.btnGOS);
            this.Controls.Add(this.btnGCliente);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Principal";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGCliente;
        private System.Windows.Forms.Button btnGOS;
        private System.Windows.Forms.Button btnGProduct;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inquilinoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departamentoToolStripMenuItem;
        private System.Windows.Forms.Button btnGUsuario;
        private System.Windows.Forms.Button btnGVenta;
        private System.Windows.Forms.Button btnListVentas;
    }
}