using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Windows.Forms;
using CafeteriaV2.Data;
using CafeteriaV2.Models;


namespace CafeteriaV2.Views.MenuArbol.productos
{
    public partial class ConsultaProducto : Form
    {
        public ConsultaProducto()
        {
            InitializeComponent();
            cmbFiltro.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarProductos();
        }

        private void BuscarProductos()
        {
            string filtro = cmbFiltro.SelectedItem?.ToString();
            string textoBusqueda = txtBusqueda.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(textoBusqueda))
            {
                MessageBox.Show("Ingrese un texto de búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string campoBusqueda = ObtenerCampoFiltro(filtro);

            string query = $@"
                SELECT p.CodigoInterno, p.Nombre, p.Precio, p.Stock
                FROM Productos p
                JOIN Proveedores pr ON pr.Id = p.ProveedorId
                WHERE LOWER({campoBusqueda}) LIKE @texto;
            ";

            using (var conn = new SqliteConnection(BaseDatos.ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@texto", $"%{textoBusqueda}%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            DataTable tabla = new DataTable();
                            tabla.Load(reader);
                            dgvResultados.DataSource = tabla;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string ObtenerCampoFiltro(string filtro)
        {
            if (filtro == "Código")
                return "p.CodigoInterno";
            else if (filtro == "Nombre")
                return "p.Nombre";
            else if (filtro == "Proveedor")
                return "pr.Nombre";
            else
                return "p.Nombre";
        }

        private void dgvResultados_DoubleClick(object sender, EventArgs e)
        {
            if (dgvResultados.CurrentRow != null)
            {
                int codigo = Convert.ToInt32(dgvResultados.CurrentRow.Cells["CodigoInterno"].Value);

                DetalleProducto formDetalle = new DetalleProducto(codigo);
                formDetalle.ShowDialog();
            }
        }
    }
}
