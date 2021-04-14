using CarritoCompras.Front.Bussiness.Interfaces;
using CarritosCompras.Front.Models;
using CarritosCompras.Front.Models.ViewObjects;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras.Front.Bussiness.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private IOptions<Settings> _settings;

        public ProductoRepository(IOptions<Settings> settings)
        {
            _settings = settings;
        }

        public async Task<Producto> GetProductoById(int id)
        {

            Producto producto = new Producto();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_settings.Value.URLdataAPI + "producto/" + id.ToString()))
                {
                    string respuestaAPI = await response.Content.ReadAsStringAsync();
                    producto = JsonConvert.DeserializeObject<Producto>(respuestaAPI);
                }
            }

            return producto;
        }

        public async Task<List<Producto>> GetProductos()
        {
            List<Producto> ListadoProducto = new List<Producto>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_settings.Value.URLdataAPI + "producto"))
                {
                    string respuestaAPI = await response.Content.ReadAsStringAsync();
                    ListadoProducto = JsonConvert.DeserializeObject<List<Producto>>(respuestaAPI);
                }
            }

            return ListadoProducto;
        }

        public async Task<bool> UpdateStock(int id, int cantidad)
        {
            bool resultado = false;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var content = new MultipartFormDataContent();
                    content.Add(new StringContent(id.ToString()), "producto_id");
                    content.Add(new StringContent(cantidad.ToString()), "cantidad");

                    using (var response = await httpClient.PutAsync(_settings.Value.URLdataAPI + "producto", content))
                    {
                        string respuestaAPI = await response.Content.ReadAsStringAsync();
                    }
                }

                resultado = true;

            }
            catch
            {
                throw;
            }
            return resultado;
        }
    }
}
