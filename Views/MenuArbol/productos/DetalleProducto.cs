using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using CafeteriaV2.Data;

namespace CafeteriaV2.Views.MenuArbol.productos
{
    public partial class DetalleProducto : Form
    {
        private int codigoInterno;

        // Constructor con código del producto
        public DetalleProducto(int codigo)
        {
            InitializeComponent();
            codigoInterno = codigo;

            // Suscribir el evento Load aquí, si no lo hiciste desde el diseñador
            this.Load += DetalleProducto_Load;
        }

        // Evento Load del formulario
        private void DetalleProducto_Load(object sender, EventArgs e)
        {
            CargarDatosProducto();
        }

        private void CargarDatosProducto()
        {
            string query = @"
                SELECT p.CodigoInterno, p.Nombre, p.Descripcion, p.Precio, p.Stock, p.Estado, pr.Nombre AS NombreProveedor
                FROM Productos p
                LEFT JOIN Proveedores pr ON p.ProveedorId = pr.Id
                WHERE p.CodigoInterno = @codigo;
            ";

            using (var conn = new SqliteConnection(BaseDatos.ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@codigo", codigoInterno);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtCodigo.Text = reader["CodigoInterno"]?.ToString();
                                txtNombre.Text = reader["Nombre"]?.ToString();
                                txtDescripcion.Text = reader["Descripcion"]?.ToString();
                                txtPrecio.Text = Convert.ToDecimal(reader["Precio"]).ToString("N2");
                                txtStock.Text = reader["Stock"]?.ToString();
                                txtEstado.Text = reader["Estado"]?.ToString();
                                txtProveedor.Text = reader["NombreProveedor"]?.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Producto no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
