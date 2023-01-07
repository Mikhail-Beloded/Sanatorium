namespace Sanatorium.BLL.DTOs
{
    public class VoucherRoomDto
    {
        public int VoucherId { get; set; }

        public VoucherDto Voucher { get; set; }

        public int RoomId { get; set; }

        public RoomDto Room { get; set; }

        public int DayCount { get; set; }
    }
}
