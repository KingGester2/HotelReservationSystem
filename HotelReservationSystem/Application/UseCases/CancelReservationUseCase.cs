using HotelReservationSystem.Core.Interfaces;

namespace HotelReservationSystem.Application.UseCases
{
    public class CancelReservationUseCase
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IReservationRepository _reservationRepository;

        public CancelReservationUseCase(IHotelRepository hotelRepository, IReservationRepository reservationRepository)
        {
            _hotelRepository = hotelRepository;
            _reservationRepository = reservationRepository;
        }

        public void Execute(int reservationId)
        {
            var reservation = _reservationRepository.GetReservationById(reservationId);
            if (reservation == null) throw new Exception("Reservation not found");

            var hotel = _hotelRepository.GetHotelById(reservation.HotelId);
            if (hotel == null) throw new Exception("Hotel not found");

            var room = hotel.Rooms.FirstOrDefault(r => r.Id == reservation.RoomId);
            if (room == null) throw new Exception("Room not found");

            room.IsReserved = false;
            _reservationRepository.CancelReservation(reservationId);
        }
    }
}