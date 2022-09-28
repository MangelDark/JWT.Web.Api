using JWT.Web.Api.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            var allCountry = CountryContanst.countries;
            return Ok(allCountry);
        }
    }
}
