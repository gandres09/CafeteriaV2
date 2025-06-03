using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CafeteriaV2.Views.MenuArbol.productos
{
    partial class DetalleProducto
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();

            int leftX1 = 10, leftX2 = 400;
            int topStart = 20, spacingY = 30;

            int columna = 0;
            int fila = 0;

            foreach (var (clave, etiqueta, editable) in camposDefinidos)
            {
                int x = columna == 0 ? leftX1 : leftX2;
                int y = topStart + spacingY * fila;

                var lbl = new Label
                {
                    AutoSize = true,
                    Text = etiqueta,
                    Location = new Point(x, y + 3)
                };
                this.Controls.Add(lbl);
                labels[clave] = lbl;

                Control campo;

                if (clave == "Estado")
                {
                    var cmb = new ComboBox
                    {
                        DropDownStyle = ComboBoxStyle.DropDownList,
                        Location = new Point(x + 100, y),
                        Size = new Size(200, 20)
                    };
                    cmb.Items.AddRange(new object[] { "Activo", "Congelado" });
                    campo = cmb;
                }
                else
                {
                    campo = new TextBox
                    {
                        Location = new Point(x + 100, y),
                        Size = new Size(200, 20),
                        ReadOnly = !editable
                    };
                }

                this.Controls.Add(campo);
                campos[clave] = campo;

                fila++;
                if (fila >= 6)
                {
                    fila = 0;
                    columna++;
                }
            }

            // Botón cerrar
            var btnCerrar = new Button
            {
                Text = "Cerrar",
                Location = new Point(this.ClientSize.Width - 100, this.ClientSize.Height - 40),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right
            };
            btnCerrar.Click += BtnCerrar_Click;
            this.Controls.Add(btnCerrar);

            // Botón guardar
            var btnGuardar = new Button
            {
                Text = "Guardar",
                Location = new Point(this.ClientSize.Width - 200, this.ClientSize.Height - 40),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right
            };
            btnGuardar.Click += BtnGuardar_Click;
            this.Controls.Add(btnGuardar);

            // Configuraciones del formulario
            this.Text = "Detalle del Producto";
            this.ClientSize = new Size(800, 280);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
        }
    }
}
