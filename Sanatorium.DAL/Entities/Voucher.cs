namespace Sanatorium.DAL.Entities
{
    public class Voucher : EntityBase
    {
        public DateTime CreationDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public Patient Patient { get; set; }

        public Reciept Reciept { get; set; }

        public List<VoucherDoctor> VoucherDoctors { get; set; }

        public List<VoucherRoom> VoucherRooms { get; set; }

        public List<VoucherProcedure> VoucherProcedures { get; set; }

        public List<VoucherIllness> VoucherIllnesses { get; set; }
    }
}
