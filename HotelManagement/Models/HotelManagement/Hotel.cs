namespace HotelManagement.Models.HotelManagement
{
    public class Hotel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string CityCode { get;set; }

        public string ImageUrl { get; set; }

        public ICollection<RoomType> RoomTypes { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public int Stars { get; set; }
    }
}
