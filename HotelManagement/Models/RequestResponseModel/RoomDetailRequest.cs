namespace HotelManagement.Models.RequestResponseModel;

public class RoomDetailRequest
{
    public string HotelId { get; set; }
    
    public DateTime CheckInDate { get; set; }
    
    public DateTime CheckOutDate { get; set; }
    
    public string RoomId { get; set; }
}