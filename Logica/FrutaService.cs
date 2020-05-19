using Entity;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Datos;

namespace Logica
{
    public class FrutaService
    {
        private readonly GeneralContext _context;

        public FrutaService(GeneralContext context)
        {
            _context=context;
        }

        public GuardarResponse Guardar(Fruta fruta)
        {
            _context.Frutas.Add(fruta);
            _context.SaveChanges();
            return new GuardarResponse(fruta);
        }

        public List<Fruta> ConsultarTodos()
        {
            var rta = _context.Frutas.ToListAsync();
            return rta.Result;
        }

        public GuardarResponse Actualizar(Fruta fruta){
            var fr = _context.Frutas.Find(fruta.Id);
            if(fr!=null){
                fr.Nombre = fruta.Nombre;
                fr.Proveedor= fruta.Proveedor;
                fr.Cantidad = fruta.Cantidad;
                fr.Unidad = fruta.Unidad;
                _context.Frutas.Update(fr);
                _context.SaveChanges();
                return new GuardarResponse(fruta);
            }

            return new GuardarResponse($"Error de la Aplicacion: {fruta.Id} no se encuentra registrado.");
        }

    }

    public class GuardarResponse
    {
        public GuardarResponse(Fruta fruta)
        {
            Error = false;
            Fruta = fruta;
        }
        public GuardarResponse(string mensaje)
        {      
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Fruta Fruta { get; set; }
    }

    
}
