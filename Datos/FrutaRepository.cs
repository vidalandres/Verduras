using System.Collections.Generic;  
using System.Data.SqlClient;
using Entity;

namespace Datos
{
    public class FrutaRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<Fruta> _frutas = new List<Fruta>();

        public FrutaRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }

        public void Guardar(Fruta fruta)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into [frutas].[dbo].[fruta] (Id,Nombre,Cantidad,Unidad,Proveedor)
                                                    values (@Id,@Nombre,@Cantidad,@Unidad,@Proveedor)";
                command.Parameters.AddWithValue("@Id", fruta.Id);
                command.Parameters.AddWithValue("@Nombre", fruta.Nombre);
                command.Parameters.AddWithValue("@Cantidad", fruta.Cantidad);
                command.Parameters.AddWithValue("@Unidad", fruta.Unidad);
                command.Parameters.AddWithValue("@Proveedor", fruta.Proveedor);
                var filas = command.ExecuteNonQuery();
            }

        }

        public List<Fruta> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Fruta> frutas = new List<Fruta>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from [frutas].[dbo].[fruta]";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Fruta fruta = DataReaderMapToFruta(dataReader);
                        frutas.Add(fruta);
                    }
                }
            }
            return frutas;
        }

        private Fruta DataReaderMapToFruta(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
                Fruta fruta = new Fruta();
                fruta.Id = System.Convert.ToInt32(dataReader["Id"]);
                fruta.Nombre = (string)dataReader["Nombre"];
                fruta.Cantidad = System.Convert.ToDouble(dataReader["Cantidad"]);
                fruta.Unidad = (string)dataReader["Unidad"];
                fruta.Proveedor = (string)dataReader["Proveedor"];
                return fruta;
        }
    }
}




