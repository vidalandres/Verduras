using Entity;
using System;
using System.Collections.Generic;
using Datos;

namespace Logica
{
    public class FrutaService
    {
        private readonly ConnectionManager _conexion;
        private readonly FrutaRepository _repositorio;

        public FrutaService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new FrutaRepository(_conexion);
        }

        public GuardarResponse Guardar(Fruta fruta)
        {
            try
            {
                _conexion.Open();
                _repositorio.Guardar(fruta);
                _conexion.Close();
                return new GuardarResponse(fruta);
            }
            catch (Exception e)
            {
                return new GuardarResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }

        public List<Fruta> ConsultarTodos()
        {
            _conexion.Open();
            List<Fruta> frutas = _repositorio.ConsultarTodos();
            _conexion.Close();
            return frutas;
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
