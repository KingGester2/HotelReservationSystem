using HotelReservationSystem.Core.Interfaces;
using HotelReservationSystem.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservationSystem.Infrastructure.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private static readonly List<Hotel> _hotels = new List<Hotel>
        {
            new Hotel
            {
                Id = 1,
                Name = "Sample Hotel",
                Address = "123 Sample Street",
                Rooms = new List<Room>
                {
                    new Room { Id = 1, Number = "101", Type = "Single", Price = 100, IsReserved = false },
                    new Room { Id = 2, Number = "102", Type = "Double", Price = 150, IsReserved = false }
                }
            }
        };

        public Hotel GetHotelById(int hotelId)
        {
            return _hotels.FirstOrDefault(h => h.Id == hotelId);
        }

        public List<Room> GetAvailableRooms(int hotelId)
        {
            var hotel = GetHotelById(hotelId);
            return hotel?.Rooms.Where(r => !r.IsReserved).ToList();
        }
    }
}