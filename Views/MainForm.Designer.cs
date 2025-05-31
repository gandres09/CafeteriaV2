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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Agregar producto");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Consultar producto");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Agregar promocion");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Consultar promocion");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Promociones", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Productos", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Agregar proveedor");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Consultar proveedor");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Proveedores", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Agregar usuario");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Consultar usuario");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Usuarios", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Agregar Cliente");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Consultar cliente");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Clientes", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Menu", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode9,
            treeNode12,
            treeNode15});
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
            treeNode1.Name = "NodoAgregarProducto";
            treeNode1.Text = "Agregar producto";
            treeNode2.Name = "NodoConsultarProducto";
            treeNode2.Text = "Consultar producto";
            treeNode3.Name = "NodoAgregarPromocion";
            treeNode3.Text = "Agregar promocion";
            treeNode4.Name = "NodoConsultarPromocion";
            treeNode4.Text = "Consultar promocion";
            treeNode5.Name = "NodoPromociones";
            treeNode5.Text = "Promociones";
            treeNode6.Name = "NodoProductos";
            treeNode6.Text = "Productos";
            treeNode7.Name = "NodoAgregarProveedor";
            treeNode7.Text = "Agregar proveedor";
            treeNode8.Name = "NodoConsultarProveedor";
            treeNode8.Text = "Consultar proveedor";
            treeNode9.Name = "NodoProveedores";
            treeNode9.Text = "Proveedores";
            treeNode10.Name = "NodoAgregarUsuario";
            treeNode10.Text = "Agregar usuario";
            treeNode11.Name = "NodoConsultarUsuario";
            treeNode11.Text = "Consultar usuario";
            treeNode12.Name = "NodoUsuarios";
            treeNode12.Text = "Usuarios";
            treeNode13.Name = "NodoAgregarCliente";
            treeNode13.Text = "Agregar Cliente";
            treeNode14.Name = "NodoConsultarCliente";
            treeNode14.Text = "Consultar cliente";
            treeNode15.Name = "NodoClientes";
            treeNode15.Text = "Clientes";
            treeNode16.Name = "NodoMenu";
            treeNode16.Text = "Menu";
            this.MenuArbol.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode16});
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

