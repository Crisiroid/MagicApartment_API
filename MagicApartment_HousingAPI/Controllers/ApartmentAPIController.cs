using MagicApartment_HousingAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace MagicApartment_HousingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Apartment> getApartments()
        {
            return new List<Apartment>
            {
                new Apartment{Id = 1, Name = "Test one"},
                new Apartment{Id = 2, Name = "Test two"}
            };
        }
    }
}
