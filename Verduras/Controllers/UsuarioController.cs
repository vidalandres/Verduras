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
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController: ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        
        public UsuarioController(GeneralContext _context)
        {
            _usuarioService = new UsuarioService(_context);
        }
        // GET: api/Usuario
        [HttpGet]
        public IEnumerable<UsuarioViewModel> Gets()
        {
            var usuarios = _usuarioService.ConsultarTodos().Select(p=> new UsuarioViewModel(p));
            return usuarios;
        }

        // POST: api/Usuario
        [HttpPost]
        public ActionResult<UsuarioViewModel> Post(UsuarioInputModel usuarioInput)
        {
            Usuario usuario = MapearUsuario(usuarioInput);
            var response = _usuarioService.Guardar(usuario);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Usuario);
        }

        [HttpPut]
        public ActionResult<UsuarioViewModel> Put(Usuario usuario)
        {
            var response = _usuarioService.Actualizar(usuario);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Usuario);
            
        }

        private Usuario MapearUsuario(UsuarioInputModel usuarioInput)
        {
            var usuario = new Usuario
            {
                UserName= usuarioInput.UserName,
                Password= usuarioInput.Password,
                FirstName= usuarioInput.FirstName,
                LastName= usuarioInput.LastName,
            };
            return usuario;
        }
    }

}