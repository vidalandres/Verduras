using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Datos;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Verduras.Models;


namespace Verduras.Controllers
{
    [Route("api/producto")]
    [ApiController]
    public class ProductoController: ControllerBase
    {
        private readonly ProductoService _productoService;
        
        public ProductoController(GeneralContext _context)
        {
            _productoService = new ProductoService(_context);
        }
        // GET: api/Producto
        [HttpGet]
        public IEnumerable<ProductoViewModel> Gets()
        {
            var productos = _productoService.ConsultarTodos().Select(p=> new ProductoViewModel(p));
            return productos;
        }

        // POST: api/Producto
        [HttpPost]
        public ActionResult<ProductoViewModel> Post(ProductoInputModel productoInput)
        {
            Producto producto = MapearProducto(productoInput);
            var response = _productoService.Guardar(producto);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Producto);
        }

        [HttpPut]
        public ActionResult<ProductoViewModel> Put(Producto producto)
        {
            var response = _productoService.Actualizar(producto);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Producto);
            
        }

        private Producto MapearProducto(ProductoInputModel productoInput)
        {
            var producto = new Producto
            {
                Id = productoInput.Id,
                Nombre = productoInput.Nombre,
                Cantidad = productoInput.Cantidad,
                Unidad = productoInput.Unidad,
                Proveedor = productoInput.Proveedor,
                Costo = productoInput.Costo,
                Precio = productoInput.Precio,
                Margen = productoInput.Margen
            };
            return producto;
        }
    }

}