using System.ComponentModel.DataAnnotations;

namespace MagicApartment_HousingAPI.Model.DTO
{
    public class ApartmentDTO
    {
        public int Id { get; set; }
        //Limited the length of Apartmnet Name
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
