namespace Sanatorium.BLL.DTOs
{
    public class VoucherIllnessDto
    {
        public int VoucherId { get; set; }

        public VoucherDto Voucher { get; set; }

        public int IllnessId { get; set; }

        public IllnessDto Illness { get; set; }

        public int IllnessGrade { get; set; }
    }
}
