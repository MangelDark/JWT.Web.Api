using JWT.Web.Api.Models;

namespace JWT.Web.Api.Constants
{
    public class EmployeeConstants
    {
        public static List<EmployeeModel> Employees = new List<EmployeeModel>()
        {
            new EmployeeModel() {FirstName = "Tomas", LastName = "Aliaga", Email = "taliaga@gmail.com" },
            new EmployeeModel() {FirstName = "Marcos", LastName = "Gonzalez", Email = "mgonzalez@gmail.com" },
        };
    }
}
