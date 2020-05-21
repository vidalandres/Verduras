using Entity;

namespace Verduras.Models
{
    public class UsuarioInputModel
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
    }

    public class UsuarioViewModel : UsuarioInputModel
    {
        public UsuarioViewModel()
        {  
        }
        public UsuarioViewModel(Usuario usuario)
        {
            Cedula = usuario.Cedula;
            Nombre = usuario.Nombre;
            Rol = usuario.Rol;
        }
    }

}