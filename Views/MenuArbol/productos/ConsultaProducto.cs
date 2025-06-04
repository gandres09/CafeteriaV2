using CafeteriaV2.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CafeteriaV2.Views.MenuArbol.productos
{
    public partial class ConsultaProducto : Form
    {
        // Aquí podrías definir un método para obtener los productos de la base de datos
        private ProductoRepository productoRepository;
        public ConsultaProducto()
        {
            InitializeComponent();
            // Inicializar el repositorio de productos
            productoRepository = new ProductoRepository(); // Instancia de ProductoRepository
        }

        private void ConsultaProducto_Load(object sender, EventArgs e)
        {
            // Aquí podrías cargar los datos en el DataGridView
            // Por ejemplo, dgvResultadoConsulta.DataSource = ObtenerProductos();
            dgvResultadoConsulta.DataSource = productoRepository.ObtenerTodos();
            //ocultar columnas innecesarias
            foreach (DataGridViewColumn column in dgvResultadoConsulta.Columns)
            {
                if (column.Name != "CodigoInterno" && column.Name != "Nombre" && column.Name != "Precio" && column.Name != "Stock")
                {
                    column.Visible = false; // Ocultar columnas no deseadas
                }
            }


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Buscar productos por proveedor y/o nombre y/o código interno para mostrar en el DataGridView
            string proveedor = txtProveedor.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string codigoInterno = txtCodigoInterno.Text.Trim();
            List<Producto> productos = productoRepository.ObtenerTodos(proveedor, nombre, codigoInterno);

            // Asignar la lista de productos al DataGridView
            if (productos.Count > 0)
            {
                dgvResultadoConsulta.DataSource = productos;
                // Ocultar otras columnas si es necesario
                foreach (DataGridViewColumn column in dgvResultadoConsulta.Columns)
                {
                    if (column.Name != "CodigoInterno" && column.Name != "Nombre" && column.Name != "Precio" && column.Name != "Stock")
                    {
                        column.Visible = false; // Ocultar columnas no deseadas
                    }
                }

            }
            else
            {
                MessageBox.Show("No se encontraron productos con los criterios especificados.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvResultadoConsulta.DataSource = null; // Limpiar el DataGridView si no hay resultados
            }


        }
    }
}