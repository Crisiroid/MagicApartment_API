using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicApartment_HousingAPI.Model
{
    public class Apartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Meterage { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string Price { get; set; }
        public string OwnerName { get; set; }
        public DateTime CreateionDate { get; set; }
    }
}
