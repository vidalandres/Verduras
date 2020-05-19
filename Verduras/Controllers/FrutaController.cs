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
    [Route("api/fruta")]
    [ApiController]
    public class FrutaController: ControllerBase
    {
        private readonly FrutaService _frutaService;
        
        public FrutaController(GeneralContext _context)
        {
            _frutaService = new FrutaService(_context);
        }
        // GET: api/Fruta
        [HttpGet]
        public IEnumerable<FrutaViewModel> Gets()
        {
            var frutas = _frutaService.ConsultarTodos().Select(p=> new FrutaViewModel(p));
            return frutas;
        }

        // POST: api/Fruta
        [HttpPost]
        public ActionResult<FrutaViewModel> Post(FrutaInputModel frutaInput)
        {
            Fruta fruta = MapearFruta(frutaInput);
            var response = _frutaService.Guardar(fruta);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Fruta);
        }

        [HttpPut]
        public ActionResult<FrutaViewModel> Put(Fruta fruta)
        {
            var response = _frutaService.Actualizar(fruta);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Fruta);

            return BadRequest();
            
        }

        private Fruta MapearFruta(FrutaInputModel frutaInput)
        {
            var fruta = new Fruta
            {
                Id = frutaInput.Id,
                Nombre = frutaInput.Nombre,
                Cantidad = frutaInput.Cantidad,
                Unidad = frutaInput.Unidad,
                Proveedor = frutaInput.Proveedor
            };
            return fruta;
        }
    }

}