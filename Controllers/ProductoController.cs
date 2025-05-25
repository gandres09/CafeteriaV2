using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeteriaV2.Models;

public class ProductoController
{
    private ProductoRepository repo = new ProductoRepository();

    public List<Producto> ObtenerProductos()
    {
        return repo.ObtenerTodos();
    }

    // Otros métodos: AgregarProducto, EditarProducto, EliminarProducto, etc.
}