using Entity;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Datos;

namespace Logica
{
    public class UsuarioService
    {
        private readonly GeneralContext _context;

        public UsuarioService(GeneralContext context)
        {
            _context=context;
            if(this._context.Usuarios.CountAsync().Result<1){
                var usr = new Usuario();
                usr.Nombre = "Vidal";
                usr.Cedula = "1065";
                usr.Rol = "Admin";
                this._context.Usuarios.Add(usr);
                this._context.SaveChanges();
            }
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

        public GuardarResponseU Actualizar(Usuario usuario){
            var fr = _context.Usuarios.Find(usuario.Cedula);
            if(fr!=null){
                fr.Nombre = usuario.Nombre;
                fr.Rol= usuario.Rol;
                _context.Usuarios.Update(fr);
                _context.SaveChanges();
                return new GuardarResponseU(usuario);
            }

            return new GuardarResponseU($"Error de la Aplicacion: {usuario.Cedula} no se encuentra registrado.");
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
