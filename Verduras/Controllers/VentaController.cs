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

using System.IO;

namespace Verduras.Controllers
{
    [Route("api/venta")]
    [ApiController]
    public class VentaController: ControllerBase
    {
        private readonly VentaService _ventaService;
        private readonly VendidoService _vendidoService;
        
        public VentaController(GeneralContext _context)
        {
            _ventaService = new VentaService(_context);
            _vendidoService = new VendidoService(_context);
        }
        // GET: api/Venta
        [HttpGet]
        public IEnumerable<Venta> Gets()
        {
            //var ventas = _ventaService.ConsultarTodos().Select(p=> new VentaViewModel(p));
            var ventas = _ventaService.ConsultarTodos();
            return ventas;
        }

        // GET: api/Venta
        [HttpGet("{id}")]
        public IEnumerable<Vendido> GetsVendidos(int id)
        {
            //this.genLog($"Ha entrado => {id}");
            var ventas = _vendidoService.Consultar(id);
            return ventas;
        }


        // POST: api/Venta
        [HttpPost]
        public ActionResult<Venta> Post(VentaInputModel ventaInput)
        {
            Venta venta = MapearVenta(ventaInput);
            var response = _ventaService.Guardar(venta);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            var response_ = _vendidoService.Guardar(ventaInput.Productos,response.Venta.Id);
            return Ok(response.Venta);
        }

        [HttpPut]
        public ActionResult<VentaViewModel> Put(Venta venta)
        {
            var response = _ventaService.Actualizar(venta);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Venta);
            
        }

        private Venta MapearVenta(VentaInputModel ventaInput)
        {
            ventaInput.GenUtilidad();
            var venta = new Venta
            {
                Id = ventaInput.Id,
                Vendedor = ventaInput.Vendedor,
                //Productos = ventaInput.Productos,
                Total = ventaInput.Total,
                Utilidad = ventaInput.Utilidad,
                Fecha = ventaInput.Fecha
            };
            return venta;
        }

        
    }

}