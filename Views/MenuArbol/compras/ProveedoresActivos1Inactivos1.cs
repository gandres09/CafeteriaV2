using CafeteriaV2.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CafeteriaV2.Views.MenuArbol.compras
{
    public partial class ProveedoresActivos1Inactivos1 : Form
    {
        private ProveedorRepository proveedorRepository = new ProveedorRepository();

        public ProveedoresActivos1Inactivos1()
        {
            InitializeComponent();
            CargarProveedores();
        }

        private void CargarProveedores()
        {
            List<Proveedor> proveedores = proveedorRepository.ObtenerTodos();
            dgvProveedores.DataSource = null;
            dgvProveedores.DataSource = proveedores;
        }

        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            var form = new AgregarProveedorForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                CargarProveedores(); // Refresca la grilla si se agregó un nuevo proveedor
            }
        }
    }
}
