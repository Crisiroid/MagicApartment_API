using MagicApartment_HousingAPI.Data;
using MagicApartment_HousingAPI.Model;
using MagicApartment_HousingAPI.Model.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


[Route("api/Apartment")]
[ApiController]
public class ApartmentAPIController : ControllerBase
{
    private readonly ApartmentDBContext _dbContext; 
    public ApartmentAPIController(ApartmentDBContext dBContext)
    {
        _dbContext = dBContext;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ApartmentDTO>> getApartments()
    {
        return Ok(_dbContext.Apartments);
    }

    [HttpGet("{id:int}", Name = "getApartment")]
    public ActionResult getApartment(int id)
    {
        if(id == null)
        {
            return BadRequest("There is no id");
        }


        var apartment = _dbContext.Apartments.FirstOrDefault(u => u.Id == id);
        if(apartment == null)
        {
            return NotFound();
        }

        return Ok(apartment);
    }

    [HttpPost]
    public ActionResult createApartment([FromBody] ApartmentDTO apartmentDTO)
    {
        if(apartmentDTO == null)
        {
            return BadRequest();
        }

        var apartment = new Apartment
        {
            Id = apartmentDTO.Id, 
            Name = apartmentDTO.Name,
            Description = apartmentDTO.Description, 
            ImageURL = apartmentDTO.ImageURL, 
            Meterage = apartmentDTO.Meterage, 
            OwnerName = apartmentDTO.OwnerName, 
            Price = apartmentDTO.Price,
        };

        _dbContext.Apartments.Add(apartment);
        _dbContext.SaveChanges();
        return Ok();

    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public ActionResult deleteApartment(int id)
    {
        if(id == null)
        {
            return BadRequest();
        }


        var apartment = _dbContext.Apartments.FirstOrDefault(u => u.Id == id);

        if(apartment == null)
        {
            return NotFound();
        }

        _dbContext.Apartments.Remove(apartment);

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id:int}")]
    public ActionResult updateApartment(int id, [FromBody] ApartmentDTO apartmentDTO)
    {
        if (id == null || id != apartmentDTO.Id)
        {
            return BadRequest();
        }

        var apartment = new Apartment
        {
            Id = apartmentDTO.Id,
            Name = apartmentDTO.Name,
            Description = apartmentDTO.Description,
            ImageURL = apartmentDTO.ImageURL,
            Meterage = apartmentDTO.Meterage,
            OwnerName = apartmentDTO.OwnerName,
            Price = apartmentDTO.Price,
        };

        _dbContext.Apartments.Update(apartment);
        _dbContext.SaveChanges();

        return NoContent();

    }
}