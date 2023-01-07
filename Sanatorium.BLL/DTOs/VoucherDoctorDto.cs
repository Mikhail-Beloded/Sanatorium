namespace Sanatorium.BLL.DTOs
{
    public class VoucherDoctorDto
    {
        public int VoucherId { get; set; }

        public VoucherDto Voucher { get; set; }

        public int DoctorId { get; set; }

        public DoctorDto Doctor { get; set; }
    }
}
