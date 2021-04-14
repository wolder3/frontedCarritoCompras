using CarritoCompras.Front.Bussiness.Interfaces;
using CarritosCompras.Front.Models;
using CarritosCompras.Front.Models.ViewObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarritoCompras.Front.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly IProductoRepository _repositoryProducto;
        private readonly IOptions<Settings> _setting;

        public ProductoController(ILogger<ProductoController> logger,   IProductoRepository repositoryProducto, IOptions<Settings> setting)
        {
            _logger = logger;
             
            _repositoryProducto = repositoryProducto;
            _setting = setting;
        }


        // GET: ProductoController
        public async Task<ActionResult> Index(int id)
        {
            Producto producto = await _repositoryProducto.GetProductoById(id);
            ViewBag.URL = _setting.Value.URLdataAPI;
            return View(producto);
        }
    }
}
