namespace Vistas
{
    partial class Productos
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtCodigoProd = new System.Windows.Forms.TextBox();
            this.txtCategoriaProd = new System.Windows.Forms.TextBox();
            this.txtDescripcionProd = new System.Windows.Forms.TextBox();
            this.txtPrecioProd = new System.Windows.Forms.TextBox();
            this.dgwProductos = new System.Windows.Forms.DataGridView();
            this.btnListar = new System.Windows.Forms.Button();
            this.rbCategoria = new System.Windows.Forms.RadioButton();
            this.rbDescripcion = new System.Windows.Forms.RadioButton();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Categoría";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descripción";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Precio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(185, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Formulario de Productos";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(69, 223);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnGuardar.MouseLeave += new System.EventHandler(this.btnGuardar_MouseLeave);
            this.btnGuardar.MouseHover += new System.EventHandler(this.btnGuardar_MouseHover);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(312, 223);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtCodigoProd
            // 
            this.txtCodigoProd.Location = new System.Drawing.Point(166, 41);
            this.txtCodigoProd.Name = "txtCodigoProd";
            this.txtCodigoProd.Size = new System.Drawing.Size(185, 20);
            this.txtCodigoProd.TabIndex = 7;
            // 
            // txtCategoriaProd
            // 
            this.txtCategoriaProd.Location = new System.Drawing.Point(166, 82);
            this.txtCategoriaProd.Name = "txtCategoriaProd";
            this.txtCategoriaProd.Size = new System.Drawing.Size(185, 20);
            this.txtCategoriaProd.TabIndex = 8;
            // 
            // txtDescripcionProd
            // 
            this.txtDescripcionProd.Location = new System.Drawing.Point(166, 123);
            this.txtDescripcionProd.Name = "txtDescripcionProd";
            this.txtDescripcionProd.Size = new System.Drawing.Size(185, 20);
            this.txtDescripcionProd.TabIndex = 9;
            // 
            // txtPrecioProd
            // 
            this.txtPrecioProd.Location = new System.Drawing.Point(166, 164);
            this.txtPrecioProd.Name = "txtPrecioProd";
            this.txtPrecioProd.Size = new System.Drawing.Size(185, 20);
            this.txtPrecioProd.TabIndex = 10;
            // 
            // dgwProductos
            // 
            this.dgwProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwProductos.Location = new System.Drawing.Point(470, 12);
            this.dgwProductos.Name = "dgwProductos";
            this.dgwProductos.Size = new System.Drawing.Size(591, 221);
            this.dgwProductos.TabIndex = 11;
            this.dgwProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwProductos_CellClick);
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(470, 271);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(105, 23);
            this.btnListar.TabIndex = 12;
            this.btnListar.Text = "Listar Productos";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // rbCategoria
            // 
            this.rbCategoria.AutoSize = true;
            this.rbCategoria.Checked = true;
            this.rbCategoria.Location = new System.Drawing.Point(640, 274);
            this.rbCategoria.Name = "rbCategoria";
            this.rbCategoria.Size = new System.Drawing.Size(89, 17);
            this.rbCategoria.TabIndex = 13;
            this.rbCategoria.TabStop = true;
            this.rbCategoria.Text = "Por Categoria";
            this.rbCategoria.UseVisualStyleBackColor = true;
            // 
            // rbDescripcion
            // 
            this.rbDescripcion.AutoSize = true;
            this.rbDescripcion.Location = new System.Drawing.Point(784, 274);
            this.rbDescripcion.Name = "rbDescripcion";
            this.rbDescripcion.Size = new System.Drawing.Size(100, 17);
            this.rbDescripcion.TabIndex = 14;
            this.rbDescripcion.Text = "Por Descripcion";
            this.rbDescripcion.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(150, 223);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 15;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(231, 223);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 16;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 356);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.rbDescripcion);
            this.Controls.Add(this.rbCategoria);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.dgwProductos);
            this.Controls.Add(this.txtPrecioProd);
            this.Controls.Add(this.txtDescripcionProd);
            this.Controls.Add(this.txtCategoriaProd);
            this.Controls.Add(this.txtCodigoProd);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Productos";
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.Productos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtCodigoProd;
        private System.Windows.Forms.TextBox txtCategoriaProd;
        private System.Windows.Forms.TextBox txtDescripcionProd;
        private System.Windows.Forms.TextBox txtPrecioProd;
        private System.Windows.Forms.DataGridView dgwProductos;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.RadioButton rbCategoria;
        private System.Windows.Forms.RadioButton rbDescripcion;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
    }
}