
using HotelReservationSystem.Core.Models;

namespace HotelReservationSystem.Core.Interfaces
{
    public interface IReservationRepository
    {
        Reservation CreateReservation(Reservation reservation);
        void CancelReservation(int reservationId);
        Reservation GetReservationById(int reservationId);
    }
}