using CarritoCompras.Front.Bussiness.Interfaces;
using CarritoCompras.Front.Bussiness.Repositories;
using CarritoCompras.Front.Models;
using CarritosCompras.Front.Models;
using CarritosCompras.Front.Models.ViewObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarritoCompras.Front.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoriaRepository _repositoryCategoria;
        private readonly IProductoRepository _repositoryProducto;
        private readonly IOptions<Settings> _setting;
        public HomeController(ILogger<HomeController> logger, ICategoriaRepository repositoryCategoria, IProductoRepository repositoryProducto, IOptions<Settings> setting)
        {
            _logger = logger;
            _repositoryCategoria = repositoryCategoria;
            _repositoryProducto = repositoryProducto;
            _setting = setting;
        }

        public async Task<IActionResult> Index()
        {
            List<Categoria> ListadoCategoria = await _repositoryCategoria.GetCategorias();
            List<Producto> ListadoProducto = await _repositoryProducto.GetProductos();
            ViewBag.ListadoCategoria = ListadoCategoria;
            ViewBag.ListadoProducto = ListadoProducto;
            ViewBag.URL = _setting.Value.URLdataAPI;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
