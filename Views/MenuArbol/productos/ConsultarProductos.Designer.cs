using System.Windows.Forms;

namespace CafeteriaV2.Views.MenuArbol.productos
{
    partial class ConsultaProducto
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvResultados = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.SuspendLayout();

            // ComboBox filtro
            this.cmbFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbFiltro.Items.AddRange(new object[] { "Código", "Nombre", "Proveedor" });
            this.cmbFiltro.Location = new System.Drawing.Point(20, 20);
            this.cmbFiltro.Size = new System.Drawing.Size(120, 23);

            // TextBox búsqueda
            this.txtBusqueda.Location = new System.Drawing.Point(150, 20);
            this.txtBusqueda.Size = new System.Drawing.Size(200, 23);

            // Botón buscar
            this.btnBuscar.Location = new System.Drawing.Point(360, 20);
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            // DataGridView resultados
            this.dgvResultados.Location = new System.Drawing.Point(20, 60);
            this.dgvResultados.Size = new System.Drawing.Size(500, 300);
            this.dgvResultados.ReadOnly = true;
            this.dgvResultados.AllowUserToAddRows = false;
            this.dgvResultados.AllowUserToDeleteRows = false;
            this.dgvResultados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvResultados.DoubleClick += new System.EventHandler(this.dgvResultados_DoubleClick);

            // Columnas (se pueden asignar también dinámicamente si prefieres)
            this.dgvResultados.Columns.Add("CodigoInterno", "Código");
            this.dgvResultados.Columns.Add("Nombre", "Nombre");
            this.dgvResultados.Columns.Add("Precio", "Precio");
            this.dgvResultados.Columns.Add("Stock", "Stock");

            // Form
            this.ClientSize = new System.Drawing.Size(550, 380);
            this.Controls.Add(this.cmbFiltro);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvResultados);
            this.Name = "ConsultaProducto";
            this.Text = "Consulta de Productos";

            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox cmbFiltro;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvResultados;
    }
}
