using System.ComponentModel.DataAnnotations;

namespace MagicApartment_HousingAPI.Model.DTO
{
    public class ApartmentDTO
    {
        [Key]
        public int Id { get; set; }
        //Limited the length of Apartmnet Name
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Meterage { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        [Required]
        public string Price { get; set; }
    }
}
