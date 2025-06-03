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
            cmbFiltro.Items.AddRange(new[] { "Código", "Nombre", "Proveedor" });
            cmbFiltro.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarProductos();
        }

        private void BuscarProductos()
        {
            string filtro = cmbFiltro.SelectedItem?.ToString();
            string textoBusqueda = txtBusqueda.Text.Trim();

            if (string.IsNullOrWhiteSpace(textoBusqueda))
            {
                MessageBox.Show("Ingrese un texto de búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string campoBusqueda = ObtenerCampoFiltro(filtro);
            string condicionWhere;

            if (campoBusqueda == "p.CodigoInterno")
                condicionWhere = $"{campoBusqueda} = @texto"; // Búsqueda exacta para código
            else
                condicionWhere = $"LOWER({campoBusqueda}) LIKE @texto"; // Parcial para nombre o proveedor

            string query = $@"
                SELECT p.CodigoInterno, p.Nombre, p.Precio, p.Stock
                FROM Productos p
                JOIN Proveedores pr ON pr.Id = p.ProveedorId
                WHERE {condicionWhere};
            ";

            using (var conn = new SqliteConnection(BaseDatos.ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        if (campoBusqueda == "p.CodigoInterno")
                            cmd.Parameters.AddWithValue("@texto", Convert.ToInt32(textoBusqueda));
                        else
                            cmd.Parameters.AddWithValue("@texto", $"%{textoBusqueda.ToLower()}%");

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
            switch (filtro)
            {
                case "Código":
                    return "p.CodigoInterno";
                case "Nombre":
                    return "p.Nombre";
                case "Proveedor":
                    return "pr.Nombre";
                default:
                    return "p.Nombre";
            }
        }

        private void dgvResultados_DoubleClick(object sender, EventArgs e)
        {
            if (dgvResultados.CurrentRow != null && dgvResultados.CurrentRow.Cells["CodigoInterno"].Value != null)
            {
                int codigo = Convert.ToInt32(dgvResultados.CurrentRow.Cells["CodigoInterno"].Value);
                DetalleProducto formDetalle = new DetalleProducto(codigo);
                formDetalle.ShowDialog();
            }
        }
    }
}
