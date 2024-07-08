using HotelReservationSystem.Core.Models;

namespace HotelReservationSystem.Core.Interfaces
{
    public interface IHotelRepository
    {
        Hotel GetHotelById(int hotelId);
        List<Room> GetAvailableRooms(int hotelId);
    }
}
