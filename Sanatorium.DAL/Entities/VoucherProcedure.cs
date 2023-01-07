namespace Sanatorium.DAL.Entities
{
    public class VoucherProcedure
    {
        public int VoucherId { get; set; }

        public Voucher Voucher { get; set; }

        public int ProcedureId { get; set; }

        public Procedure Procedure { get; set; }

        public int ProcedureCount { get; set; }
    }
}
