using Entity;
using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Datos;
using Microsoft.Data.SqlClient;

namespace Logica
{
    public class VendidoService
    {
        private readonly GeneralContext _context;

        public VendidoService(GeneralContext context)
        {
            _context=context;
        }

        public GuardarResponseVo Guardar(List<Producto> prds, int venta)
        {   prds.ForEach(x=> _context.Vendidos.Add(new Vendido(x, venta)));
            //_context.Vendidos.Add(vendido);
            _context.SaveChanges();
            return new GuardarResponseVo(new Vendido(prds[0], venta));
        }

        public List<Vendido> ConsultarTodos()
        {
            var rta = _context.Vendidos.ToListAsync();
            return rta.Result;
        }

        public List<Vendido> Consultar(int venta)
        {   
            var Val = new SqlParameter("@value",venta);
            var rta = _context.Vendidos.FromSqlRaw("select * from [Verduras].[dbo].[Vendidos] where venta=@value;",Val);
            return rta.ToListAsync().Result;
        }

        public GuardarResponseVo Actualizar(Vendido vendido){
            var fr = _context.Vendidos.Find(vendido.Id);
            if(fr!=null){
                fr.Venta = vendido.Venta;
                fr.Producto= vendido.Producto;
                _context.Vendidos.Update(fr);
                _context.SaveChanges();
                return new GuardarResponseVo(vendido);
            }

            return new GuardarResponseVo($"Error de la Aplicacion: {vendido.Id} no se encuentra registrado.");
        }

    }

    public class GuardarResponseVo
    {
        public GuardarResponseVo(Vendido vendido)
        {
            Error = false;
            Vendido = vendido;
        }
        public GuardarResponseVo(string mensaje)
        {      
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Vendido Vendido { get; set; }
    
    }
    
}
