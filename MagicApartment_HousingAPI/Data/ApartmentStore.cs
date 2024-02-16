using MagicApartment_HousingAPI.Model.DTO;

namespace MagicApartment_HousingAPI.Data
{
    public static class ApartmentStore
    {
        public static List<ApartmentDTO> apartmentList  = new List<ApartmentDTO>
            {
                new ApartmentDTO{Id = 1, Name = "Test one"},
                new ApartmentDTO{Id = 2, Name = "Test two"}
            };
    }
}
