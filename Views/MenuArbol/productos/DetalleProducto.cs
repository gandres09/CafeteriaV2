using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using CafeteriaV2.Data;

namespace CafeteriaV2.Views.MenuArbol.productos
{
    public partial class DetalleProducto : Form
    {
        private int codigoInterno;
        private Dictionary<string, Label> labels = new Dictionary<string, Label>();
        private Dictionary<string, Control> campos = new Dictionary<string, Control>();

        // Lista de campos y si son editables
        private readonly List<(string clave, string label, bool editable)> camposDefinidos = new List<(string, string, bool)>
        {
            ("Codigo", "Código:", false),
            ("Nombre", "Nombre:", false),
            ("Descripcion", "Descripción:", false),
            ("Precio", "Precio:", false),
            ("Costo", "Costo:", false),
            ("Stock", "Stock:", false),
            ("UnidadMedida", "Unidad:", false),
            ("Categoria", "Categoría:", false),
            ("Estado", "Estado:", true), // Editable
            ("FechaAlta", "Fecha Alta:", false),
            ("FechaModificacion", "Modificado:", false),
            ("Vencimiento", "Vencimiento:", false),
            ("Proveedor", "Proveedor:", false)
        };

        public DetalleProducto(int codigo)
        {
            codigoInterno = codigo;
            InitializeComponent();
            Load += DetalleProducto_Load;
        }

        private void DetalleProducto_Load(object sender, EventArgs e)
        {
            CargarDatosProducto();
        }

        private void CargarDatosProducto()
        {
            string query = @"
                SELECT 
                    p.CodigoInterno, p.Nombre, p.Descripcion, p.Precio, p.Costo, p.Stock,
                    p.UnidadMedida, p.Categoria, p.Estado,
                    p.FechaAlta, p.FechaModificacion, p.Vencimiento,
                    pr.Nombre AS NombreProveedor
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
                                SetCampo("Codigo", reader["CodigoInterno"]?.ToString());
                                SetCampo("Nombre", reader["Nombre"]?.ToString());
                                SetCampo("Descripcion", reader["Descripcion"]?.ToString());
                                SetCampo("Precio", reader["Precio"] != DBNull.Value ? Convert.ToDecimal(reader["Precio"]).ToString("N2") : "");
                                SetCampo("Costo", reader["Costo"] != DBNull.Value ? Convert.ToDecimal(reader["Costo"]).ToString("N2") : "");
                                SetCampo("Stock", reader["Stock"]?.ToString());
                                SetCampo("UnidadMedida", reader["UnidadMedida"]?.ToString());
                                SetCampo("Categoria", reader["Categoria"]?.ToString());
                                if (campos["Estado"] is ComboBox cmbEstado)
                                {
                                    string estado = reader["Estado"]?.ToString();
                                    if (!string.IsNullOrEmpty(estado))
                                        cmbEstado.SelectedItem = estado;
                                }
                                SetCampo("FechaAlta", reader["FechaAlta"]?.ToString());
                                SetCampo("FechaModificacion", reader["FechaModificacion"]?.ToString());
                                SetCampo("Vencimiento", reader["Vencimiento"]?.ToString());
                                SetCampo("Proveedor", reader["NombreProveedor"]?.ToString());
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

        private void SetCampo(string clave, string valor)
        {
            if (campos.TryGetValue(clave, out Control control))
            {
                if (control is TextBox txt)
                {
                    txt.Text = valor;
                }
                else if (control is ComboBox cmb)
                {
                    cmb.SelectedItem = valor;
                }
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


            private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nuevoEstado = ((ComboBox)campos["Estado"]).SelectedItem?.ToString();

                if (string.IsNullOrEmpty(nuevoEstado))
                {
                    MessageBox.Show("Seleccione un estado válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var conn = new SqliteConnection(BaseDatos.ConnectionString))
                {
                    conn.Open();
                    string updateQuery = "UPDATE Productos SET Estado = @estado, FechaModificacion = CURRENT_TIMESTAMP WHERE CodigoInterno = @codigo";

                    using (var cmd = new SqliteCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                        cmd.Parameters.AddWithValue("@codigo", codigoInterno);
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Estado actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            campos["FechaModificacion"].Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el estado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cambios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
