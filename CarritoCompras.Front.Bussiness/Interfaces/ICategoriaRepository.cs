using CarritosCompras.Front.Models.ViewObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras.Front.Bussiness.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> GetCategorias();
    }
}
