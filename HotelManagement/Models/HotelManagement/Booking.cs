namespace HotelManagement.Models.HotelManagement
{
    public class Booking
    {
        public Guid Id { get; set; }

        public string BookingReferences {  get; set; }

        public string FirstName {  get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public Guid HotelId { get; set; }

        public ICollection<RoomType> RomType { get; set; }

        public ICollection<Hotel> Hotel { get; set; }

        public int NumberOfRoom { get; set; }

        public decimal SumPrice { get; set; }

        public int NumberOfTraveller { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckoutDate { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public Status BookingStatus { get; set; }

    }
    public enum Status
    {
        WaitToConfirm = 0,
        Confirmed = 1,
        Done = 2
    }
}
