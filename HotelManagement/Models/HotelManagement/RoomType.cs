namespace HotelManagement.Models.HotelManagement
{
    public class RoomType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int NumberOfBed { get; set; }

        public string ImageUrlsJsonString { get; set; }

        public decimal PricePerNight { get; set; }

        public ICollection<AmenityMapping>? Amenities { get; set; }
    }
}
