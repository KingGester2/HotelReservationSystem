using HotelReservationSystem.Core.Interfaces;
using HotelReservationSystem.Core.Models;

namespace HotelReservationSystem.Application.UseCases
{
    public class CreateReservationUseCase
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IReservationRepository _reservationRepository;

        public CreateReservationUseCase(IHotelRepository hotelRepository, IReservationRepository reservationRepository)
        {
            _hotelRepository = hotelRepository;
            _reservationRepository = reservationRepository;
        }

        public Reservation Execute(int hotelId, int roomId, string customerName, DateTime checkInDate, DateTime checkOutDate)
        {
            var hotel = _hotelRepository.GetHotelById(hotelId);
            if (hotel == null) throw new Exception("Hotel not found");

            var room = hotel.Rooms.FirstOrDefault(r => r.Id == roomId);
            if (room == null || room.IsReserved) throw new Exception("Room not available");

            var reservation = new Reservation
            {
                HotelId = hotelId,
                RoomId = roomId,
                CustomerName = customerName,
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate
            };

            room.IsReserved = true;
            return _reservationRepository.CreateReservation(reservation);
        }
    }
}