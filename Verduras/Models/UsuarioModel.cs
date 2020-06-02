using Entity;
using System;

namespace Verduras.Models
{
    public class UsuarioInputModel
    {
        /*public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }*/
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
    }

    public class UsuarioViewModel : UsuarioInputModel
    {
        public UsuarioViewModel()
        {  
        }
        public UsuarioViewModel(Usuario usuario)
        {
            UserName= usuario.UserName;
            Password= usuario.Password;
            FirstName= usuario.FirstName;
            LastName= usuario.LastName;
            Token= genToken();
        }

        private string genToken(){
            return new DateTime().ToString();
        }
    }

}