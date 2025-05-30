namespace CafeteriaV2
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Agregar producto");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Consultar producto");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Agregar promocion");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Consultar promocion");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Promociones", new System.Windows.Forms.TreeNode[] {
            treeNode35,
            treeNode36});
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Productos", new System.Windows.Forms.TreeNode[] {
            treeNode33,
            treeNode34,
            treeNode37});
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("Agregar proveedor");
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("Consultar proveedor");
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("Proveedores", new System.Windows.Forms.TreeNode[] {
            treeNode39,
            treeNode40});
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("Agregar usuario");
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("Consultar usuario");
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("Usuarios", new System.Windows.Forms.TreeNode[] {
            treeNode42,
            treeNode43});
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("Agregar Cliente");
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("Consultar cliente");
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("Clientes", new System.Windows.Forms.TreeNode[] {
            treeNode45,
            treeNode46});
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("Menu", new System.Windows.Forms.TreeNode[] {
            treeNode38,
            treeNode41,
            treeNode44,
            treeNode47});
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MenuArbol = new System.Windows.Forms.TreeView();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(172, 161);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MenuArbol
            // 
            this.MenuArbol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(234)))), ((int)(((byte)(208)))));
            this.MenuArbol.Font = new System.Drawing.Font("PMingLiU-ExtB", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuArbol.ItemHeight = 20;
            this.MenuArbol.Location = new System.Drawing.Point(13, 227);
            this.MenuArbol.Name = "MenuArbol";
            treeNode33.Name = "NodoAgregarProducto";
            treeNode33.Text = "Agregar producto";
            treeNode34.Name = "NodoConsultarProducto";
            treeNode34.Text = "Consultar producto";
            treeNode35.Name = "NodoAgregarPromocion";
            treeNode35.Text = "Agregar promocion";
            treeNode36.Name = "NodoConsultarPromocion";
            treeNode36.Text = "Consultar promocion";
            treeNode37.Name = "NodoPromociones";
            treeNode37.Text = "Promociones";
            treeNode38.Name = "NodoProductos";
            treeNode38.Text = "Productos";
            treeNode39.Name = "NodoAgregarProveedor";
            treeNode39.Text = "Agregar proveedor";
            treeNode40.Name = "NodoConsultarProveedor";
            treeNode40.Text = "Consultar proveedor";
            treeNode41.Name = "NodoProveedores";
            treeNode41.Text = "Proveedores";
            treeNode42.Name = "NodoAgregarUsuario";
            treeNode42.Text = "Agregar usuario";
            treeNode43.Name = "NodoConsultarUsuario";
            treeNode43.Text = "Consultar usuario";
            treeNode44.Name = "NodoUsuarios";
            treeNode44.Text = "Usuarios";
            treeNode45.Name = "NodoAgregarCliente";
            treeNode45.Text = "Agregar Cliente";
            treeNode46.Name = "NodoConsultarCliente";
            treeNode46.Text = "Consultar cliente";
            treeNode47.Name = "NodoClientes";
            treeNode47.Text = "Clientes";
            treeNode48.Checked = true;
            treeNode48.Name = "NodoMenu";
            treeNode48.Text = "Menu";
            this.MenuArbol.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode48});
            this.MenuArbol.Size = new System.Drawing.Size(392, 280);
            this.MenuArbol.TabIndex = 1;
            this.MenuArbol.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MenuArbol_AfterSelect);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(688, 526);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(84, 23);
            this.btnCerrarSesion.TabIndex = 2;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(241)))), ((int)(((byte)(223)))));
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.MenuArbol);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TreeView MenuArbol;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}

