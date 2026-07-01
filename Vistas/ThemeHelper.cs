using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vistas
{
    public static class ThemeHelper
    {
        // Paleta de colores moderna (Estilo profesional, tonos neutros y acentos agradables)
        public static readonly Color ColorFondo = Color.FromArgb(248, 249, 250); // Off-white / gris muy claro
        public static readonly Color ColorPrimario = Color.FromArgb(43, 87, 151); // Azul oscuro corporativo / acero
        public static readonly Color ColorPrimarioHover = Color.FromArgb(28, 62, 115); 
        public static readonly Color ColorTexto = Color.FromArgb(33, 37, 41); // Gris casi negro
        public static readonly Color ColorTextoSecundario = Color.FromArgb(108, 117, 125); // Gris medio
        public static readonly Color ColorBorde = Color.FromArgb(206, 212, 218); // Gris de borde sutil
        public static readonly Color ColorFilaAlterna = Color.FromArgb(241, 243, 245);
        
        public static readonly Font FuenteBase = new Font("Segoe UI", 9F, FontStyle.Regular);
        public static readonly Font FuenteNegrita = new Font("Segoe UI", 9F, FontStyle.Bold);
        public static readonly Font FuenteTitulo = new Font("Segoe UI", 13.5F, FontStyle.Bold);

        /// <summary>
        /// Aplica el tema visual moderno a todo el formulario y sus controles hijos.
        /// </summary>
        public static void Apply(Form form)
        {
            form.SuspendLayout();
            
            // Estilo general del formulario
            form.BackColor = ColorFondo;
            form.Font = FuenteBase;
            form.ForeColor = ColorTexto;
            form.StartPosition = FormStartPosition.CenterScreen;

            // Recorrer los controles recursivamente
            StyleControls(form.Controls);

            form.ResumeLayout();
        }

        private static void StyleControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                // Heredar tipografía general si no tiene una personalizada específica
                if (ctrl.Font.Name == "Microsoft Sans Serif" || ctrl.Font.Name == "Tahoma" || ctrl.Font.Name == "Sans Serif")
                {
                    ctrl.Font = FuenteBase;
                }

                // Estilo según tipo de control
                if (ctrl is Button)
                {
                    Button btn = (Button)ctrl;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.Cursor = Cursors.Hand;

                    // Distinguir botón primario ("Aceptar", "Guardar", "Ingresar", "Buscar", "Nuevo") de secundario
                    string txt = btn.Text.ToLower();
                    if (txt.Contains("aceptar") || txt.Contains("guardar") || txt.Contains("ingresar") || txt.Contains("buscar") || txt.Contains("nuevo") || txt.Contains("agregar"))
                    {
                        btn.BackColor = ColorPrimario;
                        btn.ForeColor = Color.White;
                        btn.FlatAppearance.BorderColor = ColorPrimario;
                        btn.FlatAppearance.MouseOverBackColor = ColorPrimarioHover;
                    }
                    else
                    {
                        btn.BackColor = Color.White;
                        btn.ForeColor = ColorTexto;
                        btn.FlatAppearance.BorderColor = ColorBorde;
                        btn.FlatAppearance.MouseOverBackColor = ColorFilaAlterna;
                    }
                }
                else if (ctrl is TextBox)
                {
                    TextBox txt = (TextBox)ctrl;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                    txt.BackColor = Color.White;
                    txt.ForeColor = ColorTexto;
                }
                else if (ctrl is ComboBox)
                {
                    ComboBox cb = (ComboBox)ctrl;
                    cb.FlatStyle = FlatStyle.Flat;
                    cb.BackColor = Color.White;
                    cb.ForeColor = ColorTexto;
                }
                else if (ctrl is Label)
                {
                    Label lbl = (Label)ctrl;
                    // Si parece un título por su tamaño o texto
                    if (lbl.Font.Size > 11 || lbl.Text.ToLower().Contains("bienvenido") || lbl.Text.ToLower().Contains("sistema") || lbl.Text.ToLower().Contains("gestion") || lbl.Text.ToLower().Contains("óptica"))
                    {
                        lbl.Font = FuenteTitulo;
                        lbl.ForeColor = ColorPrimario;
                    }
                    else
                    {
                        lbl.ForeColor = ColorTexto;
                    }
                }
                else if (ctrl is DataGridView)
                {
                    DataGridView dgv = (DataGridView)ctrl;
                    dgv.BackgroundColor = Color.White;
                    dgv.BorderStyle = BorderStyle.None;
                    dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                    dgv.GridColor = ColorBorde;

                    dgv.EnableHeadersVisualStyles = false;
                    dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                    
                    // Cabecera
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorPrimario;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgv.ColumnHeadersDefaultCellStyle.Font = FuenteNegrita;
                    dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorPrimario;
                    dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
                    dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                    dgv.ColumnHeadersHeight = 34;
                    
                    // Filas
                    dgv.DefaultCellStyle.BackColor = Color.White;
                    dgv.DefaultCellStyle.ForeColor = ColorTexto;
                    dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 230, 241);
                    dgv.DefaultCellStyle.SelectionForeColor = ColorTexto;
                    dgv.DefaultCellStyle.Padding = new Padding(6, 2, 6, 2);
                    dgv.RowTemplate.Height = 28;
                    
                    dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorFilaAlterna;

                    dgv.RowHeadersVisible = false;
                    dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgv.AllowUserToResizeRows = false;
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                else if (ctrl is GroupBox)
                {
                    GroupBox gb = (GroupBox)ctrl;
                    gb.ForeColor = ColorPrimario;
                    gb.Font = FuenteNegrita;
                    // Recursión dentro de contenedores
                    StyleControls(gb.Controls);
                }
                else if (ctrl is Panel)
                {
                    Panel pnl = (Panel)ctrl;
                    // Recursión dentro de contenedores
                    StyleControls(pnl.Controls);
                }
                else if (ctrl is TabControl)
                {
                    TabControl tc = (TabControl)ctrl;
                    foreach (TabPage tp in tc.TabPages)
                    {
                        tp.BackColor = ColorFondo;
                        StyleControls(tp.Controls);
                    }
                }
                else if (ctrl is MenuStrip)
                {
                    StyleMenuStrip((MenuStrip)ctrl);
                }
                else if (ctrl is StatusStrip)
                {
                    StatusStrip ss = (StatusStrip)ctrl;
                    ss.BackColor = ColorPrimario;
                    ss.ForeColor = Color.White;
                    ss.Font = FuenteBase;
                    ss.SizingGrip = false;
                }
            }
        }

        /// <summary>
        /// Aplica un estilo plano y moderno a un MenuStrip y sus items.
        /// </summary>
        private static void StyleMenuStrip(MenuStrip menu)
        {
            menu.RenderMode = ToolStripRenderMode.Professional;
            menu.Renderer = new ToolStripProfessionalRenderer(new FlatMenuColorTable());
            menu.BackColor = ColorPrimario;
            menu.ForeColor = Color.White;
            menu.Font = FuenteBase;
            menu.Padding = new Padding(6, 2, 0, 2);
            StyleMenuItems(menu.Items);
        }

        private static void StyleMenuItems(ToolStripItemCollection items)
        {
            foreach (ToolStripItem item in items)
            {
                item.Font = FuenteBase;
                item.ForeColor = Color.White;
                ToolStripMenuItem menuItem = item as ToolStripMenuItem;
                if (menuItem != null && menuItem.HasDropDownItems)
                {
                    foreach (ToolStripItem sub in menuItem.DropDownItems)
                    {
                        sub.ForeColor = ColorTexto;
                        sub.Font = FuenteBase;
                    }
                    StyleMenuItems(menuItem.DropDownItems);
                }
            }
        }
    }

    /// <summary>
    /// Tabla de colores plana para menús: acento corporativo y hover sutil.
    /// </summary>
    internal class FlatMenuColorTable : ProfessionalColorTable
    {
        public override Color MenuStripGradientBegin { get { return ThemeHelper.ColorPrimario; } }
        public override Color MenuStripGradientEnd { get { return ThemeHelper.ColorPrimario; } }
        public override Color MenuItemSelected { get { return ThemeHelper.ColorPrimarioHover; } }
        public override Color MenuItemSelectedGradientBegin { get { return ThemeHelper.ColorPrimarioHover; } }
        public override Color MenuItemSelectedGradientEnd { get { return ThemeHelper.ColorPrimarioHover; } }
        public override Color MenuItemPressedGradientBegin { get { return ThemeHelper.ColorPrimario; } }
        public override Color MenuItemPressedGradientEnd { get { return ThemeHelper.ColorPrimario; } }
        public override Color MenuItemBorder { get { return ThemeHelper.ColorPrimarioHover; } }
        public override Color MenuBorder { get { return ThemeHelper.ColorBorde; } }
        public override Color ToolStripDropDownBackground { get { return Color.White; } }
        public override Color ImageMarginGradientBegin { get { return Color.White; } }
        public override Color ImageMarginGradientMiddle { get { return Color.White; } }
        public override Color ImageMarginGradientEnd { get { return Color.White; } }
    }
}
