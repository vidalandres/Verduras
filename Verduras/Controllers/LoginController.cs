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
    [Route("api/login")]
    [ApiController]
    public class LoginController: ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        
        public LoginController(GeneralContext _context)
        {
            _usuarioService = new UsuarioService(_context);
        }

        [HttpPost]
        public ActionResult<UsuarioViewModel> Post(LogModel log)
        {
            var usuario = _usuarioService.ConsultarLog(log.Username,log.Password);
            if (usuario!=null)
            {
                return Ok(usuario);
            }
            return BadRequest("Credenciales invalidas");
        }

       
    }

}