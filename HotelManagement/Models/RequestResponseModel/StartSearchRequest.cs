namespace HotelManagement.Models.RequestResponseModel;

public class StartSearchRequest
{
    public string DestinationCity { get; set; }
    
    public DateTime CheckInDate { get; set; }
    
    public DateTime CheckOutDate { get; set; }
    
    public int NumberOfRoom { get; set; }
    
    public int NumberOfPassenger { get; set; }
}