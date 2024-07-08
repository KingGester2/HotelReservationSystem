using Microsoft.AspNetCore.Mvc;
using HotelReservationSystem.Core.Interfaces;

namespace HotelReservationSystem.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        [HttpGet("{hotelId}")]
        public IActionResult GetHotel(int hotelId)
        {
            var hotel = _hotelRepository.GetHotelById(hotelId);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

        [HttpGet("{hotelId}/available-rooms")]
        public IActionResult GetAvailableRooms(int hotelId)
        {
            var rooms = _hotelRepository.GetAvailableRooms(hotelId);
            return Ok(rooms);
        }
    }
}