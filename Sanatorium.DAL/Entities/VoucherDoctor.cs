namespace Sanatorium.DAL.Entities
{
    public class VoucherDoctor 
    {
        public int VoucherId { get; set; }

        public Voucher Voucher { get; set; }

        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }
    }
}