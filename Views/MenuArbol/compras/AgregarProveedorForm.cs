using CafeteriaV2.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Windows.Forms;

namespace CafeteriaV2.Views.MenuArbol.compras
{
    public partial class AgregarProveedorForm : Form
    {
        public AgregarProveedorForm()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtRUT.Text))
            {
                MessageBox.Show("Los campos Nombre y RUT son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new SqliteConnection("Data Source=miCafeteria.db"))
                {
                    conn.Open();
                    string insertQuery = @"INSERT INTO Proveedores 
                        (Nombre, RUT, Telefono, Email, Direccion, FechaAlta, FechaModificacion) 
                        VALUES (@Nombre, @RUT, @Telefono, @Email, @Direccion, @FechaAlta, @FechaModificacion)";
                    using (var cmd = new SqliteCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@RUT", txtRUT.Text.Trim());
                        cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text.Trim());
                        cmd.Parameters.AddWithValue("@FechaAlta", DateTime.Now);
                        cmd.Parameters.AddWithValue("@FechaModificacion", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Proveedor guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
