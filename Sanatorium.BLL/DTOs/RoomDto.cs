﻿namespace Sanatorium.BLL.DTOs
{
    public class RoomDto : DtoBase
    {
        public double Price { get; set; }

        public int Capacity { get; set; }

        public List<VoucherRoomDto> VoucherRooms { get; set; }
    }
}
