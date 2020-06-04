using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Datos;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Verduras.Models;
using Verduras.Config;


namespace Verduras.Controllers
{
    [Authorize]
    [Route("api/login")]
    [ApiController]
    public class LoginController: ControllerBase
    {
        private readonly GeneralContext _context;
        private readonly UserService _userService;
        private readonly JwtService _jwtService;
        
        public LoginController(GeneralContext context, IOptions<AppSetting> appSettings)
        {   _context = context;
            var admin = _context.Users.Find("admin");
            if (admin == null)
            {
                _context.Users.Add(new User()
                {
                    UserName="admin",
                    Password="admin",
                    Email="admin@gmail.com",
                    Estado="AC",
                    FirstName="Adminitrador",
                    LastName="",
                    MobilePhone="31800000000"
                }
            );
            var registrosGuardados=_context.SaveChanges();
            }
            _userService = new UserService(context);
            _jwtService = new JwtService(appSettings);
        }

        /*[HttpPost]
        public ActionResult<UsuarioViewModel> Post(LogModel log)
        {
            var usuario = _usuarioService.ConsultarLog(log.Username,log.Password);
            if (usuario!=null)
            {
                return Ok(usuario);
            }
            return BadRequest("Credenciales invalidas");
        }*/

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]LogInputModel model)
        {
            var user = _userService.Validate(model.UserName, model.Password);
            if (user == null) 
                return BadRequest("Username or password is incorrect");
            var response= _jwtService.GenerateToken(user);
            return Ok(response);
        }
       
    }

}