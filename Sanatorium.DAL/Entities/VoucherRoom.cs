namespace Sanatorium.DAL.Entities
{
    public class VoucherRoom
    {
        public int VoucherId { get; set; }

        public Voucher Voucher { get; set; }

        public int RoomId { get; set; }

        public Room Room { get; set; }

        public int DayCount { get; set; }
    }
}
