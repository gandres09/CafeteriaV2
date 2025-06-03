namespace CafeteriaV2.Views.MenuArbol.productos
{
    partial class AgregarProducto
    {
        private System.ComponentModel.IContainer components = null;

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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.numStock = new System.Windows.Forms.NumericUpDown();
            this.cmbUnidadMedida = new System.Windows.Forms.ComboBox();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.dtpVencimiento = new System.Windows.Forms.DateTimePicker();
            this.txtCodigoInterno = new System.Windows.Forms.TextBox();
            this.txtProveedorId = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelDescripcion = new System.Windows.Forms.Label();
            this.labelPrecio = new System.Windows.Forms.Label();
            this.labelCosto = new System.Windows.Forms.Label();
            this.labelStock = new System.Windows.Forms.Label();
            this.labelUnidadMedida = new System.Windows.Forms.Label();
            this.labelCategoria = new System.Windows.Forms.Label();
            this.labelEstado = new System.Windows.Forms.Label();
            this.labelVencimiento = new System.Windows.Forms.Label();
            this.labelCodigoInterno = new System.Windows.Forms.Label();
            this.labelProveedorId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(105, 12);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(188, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(105, 37);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(188, 50);
            this.txtDescripcion.TabIndex = 1;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(105, 93);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(76, 20);
            this.txtPrecio.TabIndex = 2;
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(218, 93);
            this.txtCosto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(76, 20);
            this.txtCosto.TabIndex = 3;
            // 
            // numStock
            // 
            this.numStock.Location = new System.Drawing.Point(105, 118);
            this.numStock.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numStock.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numStock.Name = "numStock";
            this.numStock.Size = new System.Drawing.Size(75, 20);
            this.numStock.TabIndex = 4;
            // 
            // cmbUnidadMedida
            // 
            this.cmbUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnidadMedida.FormattingEnabled = true;
            this.cmbUnidadMedida.Location = new System.Drawing.Point(218, 118);
            this.cmbUnidadMedida.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbUnidadMedida.Name = "cmbUnidadMedida";
            this.cmbUnidadMedida.Size = new System.Drawing.Size(76, 21);
            this.cmbUnidadMedida.TabIndex = 5;
            // 
            // txtCategoria
            // 
            this.txtCategoria.Location = new System.Drawing.Point(105, 146);
            this.txtCategoria.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(188, 20);
            this.txtCategoria.TabIndex = 6;
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(105, 171);
            this.cmbEstado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(114, 21);
            this.cmbEstado.TabIndex = 7;
            // 
            // dtpVencimiento
            // 
            this.dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVencimiento.Location = new System.Drawing.Point(218, 171);
            this.dtpVencimiento.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpVencimiento.Name = "dtpVencimiento";
            this.dtpVencimiento.ShowCheckBox = true;
            this.dtpVencimiento.Size = new System.Drawing.Size(76, 20);
            this.dtpVencimiento.TabIndex = 8;
            // 
            // txtCodigoInterno
            // 
            this.txtCodigoInterno.Location = new System.Drawing.Point(105, 199);
            this.txtCodigoInterno.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCodigoInterno.Name = "txtCodigoInterno";
            this.txtCodigoInterno.ReadOnly = true;
            this.txtCodigoInterno.Size = new System.Drawing.Size(114, 20);
            this.txtCodigoInterno.TabIndex = 9;
            // 
            // txtProveedorId
            // 
            this.txtProveedorId.Location = new System.Drawing.Point(105, 227);
            this.txtProveedorId.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtProveedorId.Name = "txtProveedorId";
            this.txtProveedorId.Size = new System.Drawing.Size(76, 20);
            this.txtProveedorId.TabIndex = 10;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(105, 254);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 24);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(218, 254);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 24);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(15, 15);
            this.labelNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(44, 13);
            this.labelNombre.TabIndex = 100;
            this.labelNombre.Text = "Nombre";
            // 
            // labelDescripcion
            // 
            this.labelDescripcion.AutoSize = true;
            this.labelDescripcion.Location = new System.Drawing.Point(15, 39);
            this.labelDescripcion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDescripcion.Name = "labelDescripcion";
            this.labelDescripcion.Size = new System.Drawing.Size(63, 13);
            this.labelDescripcion.TabIndex = 101;
            this.labelDescripcion.Text = "Descripción";
            // 
            // labelPrecio
            // 
            this.labelPrecio.AutoSize = true;
            this.labelPrecio.Location = new System.Drawing.Point(15, 96);
            this.labelPrecio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPrecio.Name = "labelPrecio";
            this.labelPrecio.Size = new System.Drawing.Size(37, 13);
            this.labelPrecio.TabIndex = 102;
            this.labelPrecio.Text = "Precio";
            // 
            // labelCosto
            // 
            this.labelCosto.AutoSize = true;
            this.labelCosto.Location = new System.Drawing.Point(180, 96);
            this.labelCosto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCosto.Name = "labelCosto";
            this.labelCosto.Size = new System.Drawing.Size(34, 13);
            this.labelCosto.TabIndex = 103;
            this.labelCosto.Text = "Costo";
            // 
            // labelStock
            // 
            this.labelStock.AutoSize = true;
            this.labelStock.Location = new System.Drawing.Point(15, 119);
            this.labelStock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStock.Name = "labelStock";
            this.labelStock.Size = new System.Drawing.Size(35, 13);
            this.labelStock.TabIndex = 104;
            this.labelStock.Text = "Stock";
            // 
            // labelUnidadMedida
            // 
            this.labelUnidadMedida.AutoSize = true;
            this.labelUnidadMedida.Location = new System.Drawing.Point(180, 120);
            this.labelUnidadMedida.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUnidadMedida.Name = "labelUnidadMedida";
            this.labelUnidadMedida.Size = new System.Drawing.Size(79, 13);
            this.labelUnidadMedida.TabIndex = 105;
            this.labelUnidadMedida.Text = "Unidad Medida";
            // 
            // labelCategoria
            // 
            this.labelCategoria.AutoSize = true;
            this.labelCategoria.Location = new System.Drawing.Point(15, 149);
            this.labelCategoria.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCategoria.Name = "labelCategoria";
            this.labelCategoria.Size = new System.Drawing.Size(54, 13);
            this.labelCategoria.TabIndex = 106;
            this.labelCategoria.Text = "Categoría";
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(15, 173);
            this.labelEstado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(40, 13);
            this.labelEstado.TabIndex = 107;
            this.labelEstado.Text = "Estado";
            // 
            // labelVencimiento
            // 
            this.labelVencimiento.AutoSize = true;
            this.labelVencimiento.Location = new System.Drawing.Point(180, 173);
            this.labelVencimiento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVencimiento.Name = "labelVencimiento";
            this.labelVencimiento.Size = new System.Drawing.Size(65, 13);
            this.labelVencimiento.TabIndex = 108;
            this.labelVencimiento.Text = "Vencimiento";
            // 
            // labelCodigoInterno
            // 
            this.labelCodigoInterno.AutoSize = true;
            this.labelCodigoInterno.Location = new System.Drawing.Point(15, 202);
            this.labelCodigoInterno.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCodigoInterno.Name = "labelCodigoInterno";
            this.labelCodigoInterno.Size = new System.Drawing.Size(75, 13);
            this.labelCodigoInterno.TabIndex = 109;
            this.labelCodigoInterno.Text = "Código interno";
            // 
            // labelProveedorId
            // 
            this.labelProveedorId.AutoSize = true;
            this.labelProveedorId.Location = new System.Drawing.Point(15, 230);
            this.labelProveedorId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelProveedorId.Name = "labelProveedorId";
            this.labelProveedorId.Size = new System.Drawing.Size(70, 13);
            this.labelProveedorId.TabIndex = 110;
            this.labelProveedorId.Text = "ID Proveedor";
            // 
            // AgregarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 289);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.labelDescripcion);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.labelPrecio);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.labelCosto);
            this.Controls.Add(this.numStock);
            this.Controls.Add(this.labelStock);
            this.Controls.Add(this.cmbUnidadMedida);
            this.Controls.Add(this.labelUnidadMedida);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.labelCategoria);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.dtpVencimiento);
            this.Controls.Add(this.labelVencimiento);
            this.Controls.Add(this.txtCodigoInterno);
            this.Controls.Add(this.labelCodigoInterno);
            this.Controls.Add(this.txtProveedorId);
            this.Controls.Add(this.labelProveedorId);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AgregarProducto";
            this.Text = "Agregar Producto";
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Controles
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.NumericUpDown numStock;
        private System.Windows.Forms.ComboBox cmbUnidadMedida;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.DateTimePicker dtpVencimiento;
        private System.Windows.Forms.TextBox txtCodigoInterno;
        private System.Windows.Forms.TextBox txtProveedorId;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelDescripcion;
        private System.Windows.Forms.Label labelPrecio;
        private System.Windows.Forms.Label labelCosto;
        private System.Windows.Forms.Label labelStock;
        private System.Windows.Forms.Label labelUnidadMedida;
        private System.Windows.Forms.Label labelCategoria;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Label labelVencimiento;
        private System.Windows.Forms.Label labelCodigoInterno;
        private System.Windows.Forms.Label labelProveedorId;
    }
}
