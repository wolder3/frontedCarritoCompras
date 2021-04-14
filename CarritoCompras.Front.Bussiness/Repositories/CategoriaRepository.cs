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
    public class CategoriaRepository : ICategoriaRepository
    {
        private IOptions<Settings> _settings;
        public CategoriaRepository(IOptions<Settings> settings)
        {
            _settings = settings;
        }
          
        public async Task<List<Categoria>> GetCategorias()
        {
            List<Categoria> ListadoCategoria = new List<Categoria>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_settings.Value.URLdataAPI + "categoria"))
                {
                    string respuestaAPI = await response.Content.ReadAsStringAsync();
                    ListadoCategoria = JsonConvert.DeserializeObject<List<Categoria>>(respuestaAPI);
                }
            }

            return ListadoCategoria;
        }
    }
}
