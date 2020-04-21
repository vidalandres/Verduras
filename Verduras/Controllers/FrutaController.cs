using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
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
        public IConfiguration Configuration { get; }
        
        public FrutaController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _frutaService = new FrutaService(connectionString);
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