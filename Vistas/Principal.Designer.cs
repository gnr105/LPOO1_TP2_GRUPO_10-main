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
            this.btnGOS = new System.Windows.Forms.Button();
            this.btnGProduct = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inquilinoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGUsuario = new System.Windows.Forms.Button();
            this.btnGVenta = new System.Windows.Forms.Button();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.btnListVentas = new System.Windows.Forms.Button();
            this.btnGCliente = new System.Windows.Forms.Button();
            this.btnListProd = new System.Windows.Forms.Button();
            this.btnListClientesOS = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGOS
            // 
            this.btnGOS.Location = new System.Drawing.Point(60, 154);
            this.btnGOS.Name = "btnGOS";
            this.btnGOS.Size = new System.Drawing.Size(180, 36);
            this.btnGOS.TabIndex = 1;
            this.btnGOS.Text = "Gestion Obra Social";
            this.btnGOS.UseVisualStyleBackColor = true;
            this.btnGOS.Click += new System.EventHandler(this.btnGOS_Click);
            // 
            // btnGProduct
            // 
            this.btnGProduct.Location = new System.Drawing.Point(280, 100);
            this.btnGProduct.Name = "btnGProduct";
            this.btnGProduct.Size = new System.Drawing.Size(180, 36);
            this.btnGProduct.TabIndex = 2;
            this.btnGProduct.Text = "Gestion Producto";
            this.btnGProduct.UseVisualStyleBackColor = true;
            this.btnGProduct.Click += new System.EventHandler(this.btnGProduct_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(160, 320);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(200, 36);
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
            this.menuStrip1.Size = new System.Drawing.Size(520, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.sistemaToolStripMenuItem.Text = "Sistema";
            this.sistemaToolStripMenuItem.Click += new System.EventHandler(this.sistemaToolStripMenuItem_Click);
            // 
            // inquilinoToolStripMenuItem
            // 
            this.inquilinoToolStripMenuItem.Name = "inquilinoToolStripMenuItem";
            this.inquilinoToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.inquilinoToolStripMenuItem.Text = "Inquilino";
            // 
            // departamentoToolStripMenuItem
            // 
            this.departamentoToolStripMenuItem.Name = "departamentoToolStripMenuItem";
            this.departamentoToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.departamentoToolStripMenuItem.Text = "Departamento";
            // 
            // btnGUsuario
            // 
            this.btnGUsuario.Location = new System.Drawing.Point(60, 208);
            this.btnGUsuario.Name = "btnGUsuario";
            this.btnGUsuario.Size = new System.Drawing.Size(180, 36);
            this.btnGUsuario.TabIndex = 5;
            this.btnGUsuario.Text = "Gestion de Usuario";
            this.btnGUsuario.UseVisualStyleBackColor = true;
            this.btnGUsuario.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGVenta
            // 
            this.btnGVenta.Location = new System.Drawing.Point(280, 154);
            this.btnGVenta.Name = "btnGVenta";
            this.btnGVenta.Size = new System.Drawing.Size(180, 36);
            this.btnGVenta.TabIndex = 6;
            this.btnGVenta.Text = "Gestion Venta";
            this.btnGVenta.UseVisualStyleBackColor = true;
            this.btnGVenta.Click += new System.EventHandler(this.btnGVenta_Click);
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = false;
            this.lblBienvenida.Location = new System.Drawing.Point(60, 40);
            this.lblBienvenida.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(400, 36);
            this.lblBienvenida.TabIndex = 7;
            this.lblBienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnListVentas
            // 
            this.btnListVentas.Location = new System.Drawing.Point(280, 208);
            this.btnListVentas.Margin = new System.Windows.Forms.Padding(2);
            this.btnListVentas.Name = "btnListVentas";
            this.btnListVentas.Size = new System.Drawing.Size(180, 36);
            this.btnListVentas.TabIndex = 7;
            this.btnListVentas.Text = "Listado de Ventas";
            this.btnListVentas.UseVisualStyleBackColor = true;
            this.btnListVentas.Click += new System.EventHandler(this.btnListVentas_Click);
            // 
            // btnGCliente
            // 
            this.btnGCliente.Location = new System.Drawing.Point(60, 100);
            this.btnGCliente.Name = "btnGCliente";
            this.btnGCliente.Size = new System.Drawing.Size(180, 36);
            this.btnGCliente.TabIndex = 8;
            this.btnGCliente.Text = "Gestion Cliente";
            this.btnGCliente.UseVisualStyleBackColor = true;
            this.btnGCliente.Click += new System.EventHandler(this.btnGCliente_Click);
            // 
            // btnListProd
            // 
            this.btnListProd.Location = new System.Drawing.Point(60, 262);
            this.btnListProd.Name = "btnListProd";
            this.btnListProd.Size = new System.Drawing.Size(180, 36);
            this.btnListProd.TabIndex = 9;
            this.btnListProd.Text = "Listado de Productos";
            this.btnListProd.UseVisualStyleBackColor = true;
            this.btnListProd.Click += new System.EventHandler(this.btnListProd_Click);
            // 
            // btnListClientesOS
            // 
            this.btnListClientesOS.Location = new System.Drawing.Point(280, 262);
            this.btnListClientesOS.Name = "btnListClientesOS";
            this.btnListClientesOS.Size = new System.Drawing.Size(180, 36);
            this.btnListClientesOS.TabIndex = 10;
            this.btnListClientesOS.Text = "Clientes x Obra Social";
            this.btnListClientesOS.UseVisualStyleBackColor = true;
            this.btnListClientesOS.Click += new System.EventHandler(this.btnListClientesOS_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 380);
            this.Controls.Add(this.btnListClientesOS);
            this.Controls.Add(this.btnListProd);
            this.Controls.Add(this.btnGCliente);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.btnListVentas);
            this.Controls.Add(this.btnGVenta);
            this.Controls.Add(this.btnGUsuario);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGProduct);
            this.Controls.Add(this.btnGOS);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.Text = "Sistema de Gestión - Óptica";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGOS;
        private System.Windows.Forms.Button btnGProduct;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inquilinoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departamentoToolStripMenuItem;
        private System.Windows.Forms.Button btnGUsuario;
        private System.Windows.Forms.Button btnGVenta;

        private System.Windows.Forms.Label lblBienvenida;

        private System.Windows.Forms.Button btnListVentas;
        private System.Windows.Forms.Button btnGCliente;
        private System.Windows.Forms.Button btnListProd;
        private System.Windows.Forms.Button btnListClientesOS;

    }
}