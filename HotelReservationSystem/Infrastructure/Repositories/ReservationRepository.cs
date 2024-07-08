using HotelReservationSystem.Core.Interfaces;
using HotelReservationSystem.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservationSystem.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private static readonly List<Reservation> _reservations = new List<Reservation>();

        public Reservation CreateReservation(Reservation reservation)
        {
            reservation.Id = _reservations.Count + 1;
            _reservations.Add(reservation);
            return reservation;
        }

        public void CancelReservation(int reservationId)
        {
            var reservation = _reservations.FirstOrDefault(r => r.Id == reservationId);
            if (reservation != null)
            {
                _reservations.Remove(reservation);
            }
        }

        public Reservation GetReservationById(int reservationId)
        {
            return _reservations.FirstOrDefault(r => r.Id == reservationId);
        }
    }
}