namespace Bigbangassess.Models
{
    public class HotelwithRoomModel
    {
        public int HotelId { get; set; }
        public string? HotelName { get; set; }
        public string? HotelAddress { get; set; }
        public string? Location { get; set; }
        public int Ratings { get; set; }
        public string? Contact { get; set; }
        public List<RoomDto>? AvailableRooms { get; set; }

        public class RoomDto
        {
            public int RoomId { get; set; }
            public string? RoomType { get; set; }
            public string? Availability { get; set; }
            public decimal Price { get; set; }
        }
    }
}
