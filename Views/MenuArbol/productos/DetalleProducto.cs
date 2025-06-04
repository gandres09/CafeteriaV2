using CafeteriaV2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CafeteriaV2.Models.Producto;

namespace CafeteriaV2.Views.MenuArbol.productos
{
    public partial class DetalleProducto : Form
    {
        private EstadoProducto estadoActual;
        private Producto productoSeleccionado; // Variable para almacenar el producto seleccionado
        public DetalleProducto(Producto productoSeleccionado)
        {
            InitializeComponent();
            txtNombre.Text = productoSeleccionado.Nombre;
            txtDescripcion.Text = productoSeleccionado.Descripcion;
            txtPrecio.Text = productoSeleccionado.Precio.ToString("C");
            txtStock.Text = productoSeleccionado.Stock.ToString();
            txtUnidad.Text = productoSeleccionado.UnidadMedida;
            txtCategoria.Text = productoSeleccionado.Categoria;
            txtCodigo.Text = productoSeleccionado.CodigoInterno.ToString();
            txtCosto.Text = productoSeleccionado.Costo.ToString("C");
            txtProveedor.Text = productoSeleccionado.Proveedor != null ? productoSeleccionado.Proveedor.Nombre : "No asignado";
            txtVencimiento.Text = productoSeleccionado.Vencimiento.HasValue ? productoSeleccionado.Vencimiento.Value.ToString("d") : "No aplica";
            txtFechaAlta.Text = productoSeleccionado.FechaAlta.ToString("d");
            txtFechaModificacion.Text = productoSeleccionado.FechaModificacion.ToString("d");
            rbtnActivo.Checked = productoSeleccionado.Estado == Producto.EstadoProducto.Activo;
            rbtnCongelado.Checked = productoSeleccionado.Estado == Producto.EstadoProducto.Congelado;

            estadoActual = productoSeleccionado.Estado; // Guardar el estado actual del producto
            this.productoSeleccionado = productoSeleccionado; // Asignar el producto seleccionado a la variable de instancia

        }
 

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Al variar el estadoActual insertar en base de datos
            EstadoProducto nuevoEstado = rbtnActivo.Checked ? EstadoProducto.Activo : EstadoProducto.Congelado;
            if (nuevoEstado != estadoActual)
            {
                // Aquí deberías implementar la lógica para actualizar el estado del producto en la base de datos
                // Por ejemplo, llamar a un método en tu repositorio de productos
                ProductoRepository.ActualizarEstado(productoSeleccionado.Id, nuevoEstado);
                MessageBox.Show($"El estado del producto ha sido actualizado a {nuevoEstado}.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // 3. Disparar el evento para notificar que el producto ha sido actualizado
                ProductoActualizado?.Invoke(this, EventArgs.Empty); // Disparar el evento
            }
            else
            {
                MessageBox.Show("No se realizaron cambios en el estado del producto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }

        // 1. Definir el delegado del evento
        public delegate void ProductoActualizadoEventHandler(object sender, EventArgs e);

        // 2. Declarar el evento
        public event ProductoActualizadoEventHandler ProductoActualizado;
    }
}
