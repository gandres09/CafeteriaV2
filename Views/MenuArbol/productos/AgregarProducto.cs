using System;
using System.Windows.Forms;
using CafeteriaV2.Models;
using CafeteriaV2.Data;

namespace CafeteriaV2.Views.MenuArbol.productos
{
    public partial class AgregarProducto : Form
    {
        public AgregarProducto()
        {
            InitializeComponent();

            cmbUnidadMedida.Items.AddRange(new object[] { "Unidad", "Peso", "Litro" });
            if (cmbUnidadMedida.Items.Count > 0) cmbUnidadMedida.SelectedIndex = 0;

            cmbEstado.Items.AddRange(Enum.GetNames(typeof(Producto.EstadoProducto)));
            if (cmbEstado.Items.Count > 0) cmbEstado.SelectedIndex = 0;

            dtpVencimiento.Format = DateTimePickerFormat.Short;
            dtpVencimiento.ShowCheckBox = true;
            dtpVencimiento.Checked = false;

            txtCategoria.Text = "General";
            txtDescripcion.Text = "";

            // Asigno código interno aleatorio y lo bloqueo para no modificarlo
            txtCodigoInterno.Text = new Random().Next(10000, 99999).ToString();
            txtCodigoInterno.ReadOnly = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese un nombre para el producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio < 0)
            {
                MessageBox.Show("Ingrese un precio válido (número positivo).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtCosto.Text, out decimal costo) || costo < 0)
            {
                MessageBox.Show("Ingrese un costo válido (número positivo).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCategoria.Text))
            {
                MessageBox.Show("Ingrese una categoría.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtProveedorId.Text, out int proveedorId) || proveedorId < 0)
            {
                MessageBox.Show("Ingrese un ID de proveedor válido (número entero positivo).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Creo el producto
            Producto nuevoProducto = new Producto
            {
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                Precio = precio,
                Costo = costo,
                Stock = (int)numStock.Value,
                UnidadMedida = cmbUnidadMedida.SelectedItem.ToString(),
                Categoria = txtCategoria.Text.Trim(),
                Estado = (Producto.EstadoProducto)Enum.Parse(typeof(Producto.EstadoProducto), cmbEstado.SelectedItem.ToString()),
                FechaAlta = DateTime.Now,
                FechaModificacion = DateTime.Now,
                Vencimiento = dtpVencimiento.Checked ? dtpVencimiento.Value.Date : (DateTime?)null,
                CodigoInterno = int.Parse(txtCodigoInterno.Text),
                ProveedorId = proveedorId
            };

            var repo = new ProductoRepository();
            bool exito = repo.AgregarProducto(nuevoProducto);

            if (exito)
            {
                MessageBox.Show("Producto agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Hubo un error al guardar el producto:" + exito, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
