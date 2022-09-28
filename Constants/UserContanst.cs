using JWT.Web.Api.Models;

namespace JWT.Web.Api.Constants
{
    public class UserContanst
    {

        public static List<UserModel> Users = new List<UserModel>()
        {

            new UserModel() { UserName = "Miguel Angel",LastName= "Sanchez Peralta",EmailAddress = "miguel_@hotmail.com",Rol = "Administrador",Password = "Admin1234"},
            new UserModel() { UserName = "Angel Miguel",LastName= "Sanchez Peralta",EmailAddress = "angerl_@hotmail.com",Rol = "Vendedor",Password = "Admin1234"}

        };


    }
}
