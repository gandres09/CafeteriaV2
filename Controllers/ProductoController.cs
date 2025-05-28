using CafeteriaV2.Models;
using System.Collections.Generic;

public class ProductoController
{
    private ProductoRepository repo = new ProductoRepository();

    public List<Producto> ObtenerProductos()
    {
        return repo.ObtenerTodos();
    }

    // Otros métodos: AgregarProducto, EditarProducto, EliminarProducto, etc.
}