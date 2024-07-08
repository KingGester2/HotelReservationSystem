using Microsoft.AspNetCore.Mvc;
using HotelReservationSystem.Application.UseCases;
using HotelReservationSystem.Web.Models;

namespace HotelReservationSystem.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly CreateReservationUseCase _createReservationUseCase;
        private readonly CancelReservationUseCase _cancelReservationUseCase;

        public ReservationController(CreateReservationUseCase createReservationUseCase, CancelReservationUseCase cancelReservationUseCase)
        {
            _createReservationUseCase = createReservationUseCase;
            _cancelReservationUseCase = cancelReservationUseCase;
        }

        [HttpPost]
        public IActionResult CreateReservation([FromBody] CreateReservationRequest request)
        {
            var reservation = _createReservationUseCase.Execute(request.HotelId, request.RoomId, request.CustomerName, request.CheckInDate, request.CheckOutDate);
            return Ok(reservation);
        }

        [HttpDelete("{reservationId}")]
        public IActionResult CancelReservation(int reservationId)
        {
            _cancelReservationUseCase.Execute(reservationId);
            return NoContent();
        }
    }
}
