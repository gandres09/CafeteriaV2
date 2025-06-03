using System.Windows.Forms;
using System.ComponentModel;

namespace CafeteriaV2.Views.MenuArbol.productos
{
    partial class DetalleProducto
    {
        private IContainer components = null;

        // Campos de controles
        private Label lblCodigo;
        private TextBox txtCodigo;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblPrecio;
        private TextBox txtPrecio;
        private Label lblStock;
        private TextBox txtStock;
        private Label lblEstado;
        private TextBox txtEstado;
        private Label lblProveedor;
        private TextBox txtProveedor;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container(); // ✅ Agregado
            this.Load += new System.EventHandler(this.DetalleProducto_Load);

            // Inicializar controles
            lblCodigo = new Label();
            txtCodigo = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblPrecio = new Label();
            txtPrecio = new TextBox();
            lblStock = new Label();
            txtStock = new TextBox();
            lblEstado = new Label();
            txtEstado = new TextBox();
            lblProveedor = new Label();
            txtProveedor = new TextBox();

            // Crear campos
            CrearLabel(ref lblCodigo, "Código:", 10, 20);
            CrearTextBox(ref txtCodigo, 100, 20);

            CrearLabel(ref lblNombre, "Nombre:", 10, 60);
            CrearTextBox(ref txtNombre, 100, 60);

            CrearLabel(ref lblDescripcion, "Descripción:", 10, 100);
            CrearTextBox(ref txtDescripcion, 100, 100);

            CrearLabel(ref lblPrecio, "Precio:", 10, 140);
            CrearTextBox(ref txtPrecio, 100, 140);

            CrearLabel(ref lblStock, "Stock:", 10, 180);
            CrearTextBox(ref txtStock, 100, 180);

            CrearLabel(ref lblEstado, "Estado:", 10, 220);
            CrearTextBox(ref txtEstado, 100, 220);

            CrearLabel(ref lblProveedor, "Proveedor:", 10, 260);
            CrearTextBox(ref txtProveedor, 100, 260);

            // Formulario
            this.Text = "Detalle del Producto";
            this.ClientSize = new System.Drawing.Size(400, 320);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void CrearLabel(ref Label lbl, string texto, int x, int y)
        {
            lbl.AutoSize = true;
            lbl.Text = texto;
            lbl.Location = new System.Drawing.Point(x, y);
            this.Controls.Add(lbl);
        }

        private void CrearTextBox(ref TextBox txt, int x, int y)
        {
            txt.Location = new System.Drawing.Point(x, y);
            txt.Size = new System.Drawing.Size(250, 20);
            txt.ReadOnly = true;
            this.Controls.Add(txt);
        }
    }
}
