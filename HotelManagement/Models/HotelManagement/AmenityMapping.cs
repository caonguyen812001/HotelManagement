namespace HotelManagement.Models.HotelManagement
{
    public class AmenityMapping
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public Guid RoomTypeId { get; set; }
    }
}
