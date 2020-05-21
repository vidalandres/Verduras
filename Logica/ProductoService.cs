using Entity;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Datos;

namespace Logica
{
    public class ProductoService
    {
        private readonly GeneralContext _context;

        public ProductoService(GeneralContext context)
        {
            _context=context;
        }

        public GuardarResponse Guardar(Producto producto)
        {   
            producto.GenPrecio();
            _context.Productos.Add(producto);
            _context.SaveChanges();
            return new GuardarResponse(producto);
        }

        public List<Producto> ConsultarTodos()
        {
            var rta = _context.Productos.ToListAsync();
            return rta.Result;
        }

        public GuardarResponse Actualizar(Producto producto){
            var fr = _context.Productos.Find(producto.Id);
            if(fr!=null){
                fr.Nombre = producto.Nombre;
                fr.Proveedor= producto.Proveedor;
                fr.Cantidad = producto.Cantidad;
                fr.Unidad = producto.Unidad;
                fr.Costo = producto.Costo;
                fr.Margen = producto.Margen;
                fr.GenPrecio();
                _context.Productos.Update(fr);
                _context.SaveChanges();
                return new GuardarResponse(producto);
            }

            return new GuardarResponse($"Error de la Aplicacion: {producto.Id} no se encuentra registrado.");
        }

    }

    public class GuardarResponse
    {
        public GuardarResponse(Producto producto)
        {
            Error = false;
            Producto = producto;
        }
        public GuardarResponse(string mensaje)
        {      
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Producto Producto { get; set; }
    }

    
}
