namespace Sanatorium.DAL.Entities
{
    public class Voucher : EntityBase
    {
        public DateTime CreationDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public Patient Patient { get; set; }

        public Doctor? Doctor { get; set; }

        public Illness Illness { get; set; }

        public int IllnessDegree { get; set; }

        public Reciept Reciept { get; set; }

        public List<VoucherRoom> VoucherRooms { get; set; }

        public List<VoucherProcedure> VoucherProcedures { get; set; }
    }
}