using System;
using System.Collections.Generic;
using System.Text;

namespace CarritosCompras.Front.Models.ViewObjects
{
    public class Producto
    {
       public int producto_id { get; set; }
       public string nombre { get; set; }
       public string stock { get; set; }
       public string descripcion { get; set; }
       public string precio { get; set; }
       public string imagen { get; set; }
       public string categoria_id { get; set; }
    }
}
