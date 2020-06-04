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
    [Route("api/user")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly UserService _userService;
        
        public UserController(GeneralContext _context)
        {
            _userService = new UserService(_context);
        }
        // GET: api/User
        [HttpGet]
        public IEnumerable<LogViewModel> Gets()
        {
            var users = _userService.ConsultarTodos().Select(p=> new LogViewModel(p));
            return users;
        }

        // POST: api/User
        [HttpPost]
        public ActionResult<LogViewModel> Post(LogViewModel userInput)
        {
            User user = MapearUser(userInput);
            var response = _userService.Guardar(user);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.User);
        }

        [HttpPut]
        public ActionResult<LogViewModel> Put(User user)
        {
            var response = _userService.Actualizar(user);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.User);
            
        }

        private User MapearUser(LogViewModel userInput)
        {
            var user = new User
            {
                UserName= userInput.UserName,
                Password= userInput.Password,
                FirstName= userInput.FirstName,
                LastName= userInput.LastName,
                Estado = userInput.Estado,
                Email = userInput.Email,
                MobilePhone = userInput.MobilePhone
            };
            return user;
        }
    }

}