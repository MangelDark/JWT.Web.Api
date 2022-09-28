using JWT.Web.Api.Models;

namespace JWT.Web.Api.Constants
{
    public class CountryContanst
    {
        public static List<CountryModel> countries = new List<CountryModel>()
        {
            new CountryModel() { Name = "Republica Dominicana" },
            new CountryModel() { Name = "Estados Unidos" },
            new CountryModel() { Name = "Puerto Rico" },
            new CountryModel() { Name = "Jamaica" },
        };
    }
}
