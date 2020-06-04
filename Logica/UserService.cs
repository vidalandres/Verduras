using Entity;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Datos;

using Microsoft.Data.SqlClient;

namespace Logica
{
    public class UserService
    {
        private readonly GeneralContext _context;

        public UserService(GeneralContext context)
        {
            _context=context;
            /*if(this._context.Users.CountAsync().Result<1){
                var usr = new User();
                usr.Nombre = "Vidal";
                usr.Cedula = "1065";
                usr.Rol = "Admin";
                this._context.Users.Add(usr);
                this._context.SaveChanges();
            }*/
        }

        public GuardarResponseUsr Guardar(User user)
        {   
            _context.Users.Add(user);
            _context.SaveChanges();
            return new GuardarResponseUsr(user);
        }

        public List<User> ConsultarTodos()
        {
            var rta = _context.Users.ToListAsync();
            return rta.Result;
        }

        public User Validate(string username, string password)
        {
            var Un = new SqlParameter("@Un",username);
            var Ps = new SqlParameter("@Ps", password);
            //_context.Users.FirstAsync(x => x.UserName == )
            var rta = _context.Users.FromSqlRaw("select top (1)* from [Verduras].[dbo].[Users] where UserName=@Un AND Password=@Ps",Un,Ps).ToListAsync();
            if(rta.Result.Count>0)
                return rta.Result[0];
            return null;
        }

        public GuardarResponseUsr Actualizar(User user){
            var fr = _context.Users.Find(user.UserName);
            if(fr!=null){
                fr.FirstName = user.FirstName;
                fr.LastName = user.LastName;
                fr.Password = user.Password;
                _context.Users.Update(fr);
                _context.SaveChanges();
                return new GuardarResponseUsr(user);
            }

            return new GuardarResponseUsr($"Error de la Aplicacion: {user.UserName} no se encuentra registrado.");
        }

    }

    public class GuardarResponseUsr
    {
        public GuardarResponseUsr(User user)
        {
            Error = false;
            User = user;
        }
        public GuardarResponseUsr(string mensaje)
        {      
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public User User { get; set; }
    }

    
}
