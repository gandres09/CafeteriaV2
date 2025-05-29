using System.Windows.Forms;

namespace CafeteriaV2.Views.Forms
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtUsuario;
        private TextBox txtContrasena;
        private TextBox txtConfirmarContrasena;
        private ComboBox cmbRol;
        private Button btnLogin;
        private Button btnCancelar;
        private Button btnCambiarModo;
        private Label lblUsuario;
        private Label lblContrasena;
        private Label lblConfirmarContrasena;
        private Label lblRol;
        private Label lblTitulo;

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
            this.txtUsuario = new TextBox();
            this.txtContrasena = new TextBox();
            this.txtConfirmarContrasena = new TextBox();
            this.cmbRol = new ComboBox();
            this.btnLogin = new Button();
            this.btnCancelar = new Button();
            this.btnCambiarModo = new Button();
            this.lblUsuario = new Label();
            this.lblContrasena = new Label();
            this.lblConfirmarContrasena = new Label();
            this.lblRol = new Label();
            this.lblTitulo = new Label();
            this.SuspendLayout();

            // lblTitulo  
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(80, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(140, 26);
            this.lblTitulo.Text = "Iniciar Sesión";

            // lblUsuario  
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(30, 60);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.Text = "Usuario:";

            // txtUsuario  
            this.txtUsuario.Location = new System.Drawing.Point(30, 80);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(240, 20);

            // lblContrasena  
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Location = new System.Drawing.Point(30, 110);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(64, 13);
            this.lblContrasena.Text = "Contraseña:";

            // txtContrasena  
            this.txtContrasena.Location = new System.Drawing.Point(30, 130);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '*';
            this.txtContrasena.Size = new System.Drawing.Size(240, 20);

            // lblConfirmarContrasena  
            this.lblConfirmarContrasena.AutoSize = true;
            this.lblConfirmarContrasena.Location = new System.Drawing.Point(30, 160);
            this.lblConfirmarContrasena.Name = "lblConfirmarContrasena";
            this.lblConfirmarContrasena.Size = new System.Drawing.Size(108, 13);
            this.lblConfirmarContrasena.Text = "Confirmar Contraseña:";
            this.lblConfirmarContrasena.Visible = false;

            // txtConfirmarContrasena  
            this.txtConfirmarContrasena.Location = new System.Drawing.Point(30, 180);
            this.txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            this.txtConfirmarContrasena.PasswordChar = '*';
            this.txtConfirmarContrasena.Size = new System.Drawing.Size(240, 20);
            this.txtConfirmarContrasena.Visible = false;

            // lblRol  
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(30, 210);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(26, 13);
            this.lblRol.Text = "Rol:";
            this.lblRol.Visible = false;

            // cmbRol  
            this.cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Items.AddRange(new object[] { "Admin", "Cajero" });
            this.cmbRol.Location = new System.Drawing.Point(30, 230);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(240, 21);
            this.cmbRol.SelectedIndex = 0;
            this.cmbRol.Visible = false;

            // btnLogin  
            this.btnLogin.Location = new System.Drawing.Point(30, 270);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.Text = "Ingresar";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // btnCancelar  
            this.btnCancelar.Location = new System.Drawing.Point(195, 270);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // btnCambiarModo  
            this.btnCambiarModo.Location = new System.Drawing.Point(30, 300);
            this.btnCambiarModo.Name = "btnCambiarModo";
            this.btnCambiarModo.Size = new System.Drawing.Size(240, 23);
            this.btnCambiarModo.Text = "¿No tienes cuenta? Regístrate";
            this.btnCambiarModo.UseVisualStyleBackColor = true;
            this.btnCambiarModo.Click += new System.EventHandler(this.btnCambiarModo_Click);

            // FormLogin  
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;

            this.ClientSize = new System.Drawing.Size(300, 350);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblContrasena);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.lblConfirmarContrasena);
            this.Controls.Add(this.txtConfirmarContrasena);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCambiarModo);
            this.Name = "FormLogin";
            this.Text = "Cafetería - Login";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}