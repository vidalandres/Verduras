using Entity;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Datos;

namespace Logica
{
    public class VentaService
    {
        private readonly GeneralContext _context;

        public VentaService(GeneralContext context)
        {
            _context=context;
        }

        public GuardarResponseV Guardar(Venta venta)
        {   
            _context.Ventas.Add(venta);
            _context.SaveChanges();
            return new GuardarResponseV(venta);
        }

        public List<Venta> ConsultarTodos()
        {
            var rta = _context.Ventas.ToListAsync();
            return rta.Result;
        }

        public GuardarResponseV Actualizar(Venta venta){
            var fr = _context.Ventas.Find(venta.Id);
            if(fr!=null){
                fr.Vendedor = venta.Vendedor;
                fr.Total = venta.Total;
                fr.Fecha = venta.Fecha;
                _context.Ventas.Update(fr);
                _context.SaveChanges();
                return new GuardarResponseV(venta);
            }

            return new GuardarResponseV($"Error de la Aplicacion: {venta.Id} no se encuentra registrado.");
        }

    }

    public class GuardarResponseV
    {
        public GuardarResponseV(Venta venta)
        {
            Error = false;
            Venta = venta;
        }
        public GuardarResponseV(string mensaje)
        {      
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Venta Venta { get; set; }
    }

    
}
