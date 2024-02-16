using MagicApartment_HousingAPI.Data;
using MagicApartment_HousingAPI.Model;
using MagicApartment_HousingAPI.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MagicApartment_HousingAPI.Controllers
{
    //If the name of Controller gets changed, the API url will be changed as well. BE CAREFUL
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<ApartmentDTO> getApartments()
        {
            return ApartmentStore.apartmentList;
        }
    }
}
