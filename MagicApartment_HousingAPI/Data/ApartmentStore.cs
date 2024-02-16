using MagicApartment_HousingAPI.Model.DTO;

namespace MagicApartment_HousingAPI.Data
{
    public static class ApartmentStore
    {
        public static List<ApartmentDTO> apartmentList  = new List<ApartmentDTO>
            {
                new ApartmentDTO{Id = 1, Name = "Test one", Description = "Brand New, beautiful design", Meterage = "100m"},
                new ApartmentDTO{Id = 2, Name = "Test two", Description = "Slightly Old", Meterage  = "200m"}
            };
    }
}
