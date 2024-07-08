namespace HotelReservationSystem.Web.Models
{
    public class CreateReservationRequest
    {
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public string CustomerName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}