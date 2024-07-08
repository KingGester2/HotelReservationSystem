﻿namespace HotelReservationSystem.Core.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public bool IsReserved { get; set; }
    }
}