using Entity;

namespace Verduras.Models
{
    public class LogInputModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
    public class LogViewModel : LogInputModel
    {
        public string Estado { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }        
        public string Token { get; set; }

        public LogViewModel() { }

        public LogViewModel(User usr)
        {
            UserName= usr.UserName;
            Password= usr.Password;
            FirstName= usr.FirstName;
            LastName= usr.LastName;
            Estado = usr.Estado;
            Email = usr.Email;
            MobilePhone = usr.MobilePhone;
        }

    }
}