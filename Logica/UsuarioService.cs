using Entity;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Datos;

using Microsoft.Data.SqlClient;

namespace Logica
{
    public class UsuarioService
    {
        private readonly GeneralContext _context;

        public UsuarioService(GeneralContext context)
        {
            _context=context;
            /*if(this._context.Usuarios.CountAsync().Result<1){
                var usr = new Usuario();
                usr.Nombre = "Vidal";
                usr.Cedula = "1065";
                usr.Rol = "Admin";
                this._context.Usuarios.Add(usr);
                this._context.SaveChanges();
            }*/
        }

        public GuardarResponseU Guardar(Usuario usuario)
        {   
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return new GuardarResponseU(usuario);
        }

        public List<Usuario> ConsultarTodos()
        {
            var rta = _context.Usuarios.ToListAsync();
            return rta.Result;
        }

        public Usuario ConsultarLog(string username, string password)
        {
            var Un = new SqlParameter("@Un",username);
            var Ps = new SqlParameter("@Ps", password);
            var rta = _context.Usuarios.FromSqlRaw("select top (1)* from [Verduras].[dbo].[Usuarios] where UserName=@Un AND Password=@Ps",Un,Ps).ToListAsync();
            if(rta.Result.Count>0)
                return rta.Result[0];
            return null;
        }

        public GuardarResponseU Actualizar(Usuario usuario){
            var fr = _context.Usuarios.Find(usuario.UserName);
            if(fr!=null){
                fr.FirstName = usuario.FirstName;
                fr.LastName = usuario.LastName;
                fr.Password = usuario.Password;
                _context.Usuarios.Update(fr);
                _context.SaveChanges();
                return new GuardarResponseU(usuario);
            }

            return new GuardarResponseU($"Error de la Aplicacion: {usuario.UserName} no se encuentra registrado.");
        }

    }

    public class GuardarResponseU
    {
        public GuardarResponseU(Usuario usuario)
        {
            Error = false;
            Usuario = usuario;
        }
        public GuardarResponseU(string mensaje)
        {      
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Usuario Usuario { get; set; }
    }

    
}
