using CarritosCompras.Front.Models.ViewObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras.Front.Bussiness.Interfaces
{
    public interface IProductoRepository
    {
        Task<List<Producto>> GetProductos();
        Task<Producto> GetProductoById(int id);
        Task<bool> UpdateStock(int id, int cantidad);

    }
}
