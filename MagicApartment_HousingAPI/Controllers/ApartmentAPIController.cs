﻿using MagicApartment_HousingAPI.Data;
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
        public ActionResult<IEnumerable<ApartmentDTO>> getApartments()
        {
            return Ok(ApartmentStore.apartmentList);
        }
        
        
        [HttpGet("id")]
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
                var Apartment = ApartmentStore.apartmentList.FirstOrDefault(u => u.Id == id);
                if(Apartment == null)
                {
                    return NotFound();
                }
                return Ok(Apartment);
            }
        }

        [HttpPost]
        public ActionResult<ApartmentDTO> createApartment([FromBody] ApartmentDTO apartmentDTO) {
        
            if(apartmentDTO == null)
            {
                return BadRequest(apartmentDTO);
            }
            else
            {
                apartmentDTO.Id = ApartmentStore.apartmentList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
                ApartmentStore.apartmentList.Add(apartmentDTO);

                return Ok(apartmentDTO);
            }
        
        }
    }
}
