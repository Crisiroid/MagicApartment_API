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
        private readonly ApartmentDBContext _dbContext;
        public ApartmentAPIController(ApartmentDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ApartmentDTO>> getApartments()
        {
            return Ok(_dbContext.Apartments);
        }


        [HttpGet("id", Name = "getApartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ApartmentDTO> getApartment(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            else
            {
                var Apartment = _dbContext.Apartments.FirstOrDefault(u => u.Id == id);
                if (Apartment == null)
                {
                    return NotFound();
                }
                return Ok(Apartment);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ApartmentDTO> createApartment([FromBody] ApartmentDTO apartmentDTO) {

            if (_dbContext.Apartments.FirstOrDefault(u => u.Name.ToLower() == apartmentDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("NameError", "We Already have this apartment");
                return BadRequest();
            }
            if (apartmentDTO == null)
            {
                return BadRequest(apartmentDTO);
            }
            else
            {
                Apartment apartment = new()
                {
                    Name = apartmentDTO.Name, 
                    Meterage = apartmentDTO.Meterage, 
                    Description = apartmentDTO.Description,
                    ImageURL = apartmentDTO.ImageURL,
                    Price = apartmentDTO.Price,
                    OwnerName = apartmentDTO.OwnerName
                };
                _dbContext.Apartments.Add(apartment);
                _dbContext.SaveChanges();

                return CreatedAtRoute("getApartment", new { id = apartmentDTO.Id }, apartmentDTO);
            }

        }

        [HttpDelete("{id:int}", Name = "deleteApartment")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult deleteApartment(int id)
        {

            var apartment = _dbContext.Apartments.FirstOrDefault(u => u.Id == id);
            if(apartment == null)
            {
                return NotFound();
            }

            _dbContext.Apartments.Remove(apartment);
            _dbContext.SaveChanges();
            return NoContent();

        }

        [HttpPut("{id:int}", Name = "updateApartment")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult updateApartment(int id, [FromBody]ApartmentDTO apartmentDTO)
        {
            if(apartmentDTO == null || id != apartmentDTO.Id)
            {
                return BadRequest();
            }

            Apartment apartment = new()
            {
                Id = id,
                Name = apartmentDTO.Name,
                Meterage = apartmentDTO.Meterage,
                Description = apartmentDTO.Description,
                ImageURL = apartmentDTO.ImageURL,
                Price = apartmentDTO.Price,
                OwnerName = apartmentDTO.OwnerName
            };
            _dbContext.Apartments.Update(apartment);
            _dbContext.SaveChanges();

            return NoContent();

        }

    }
}
