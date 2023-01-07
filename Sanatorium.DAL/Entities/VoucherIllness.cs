namespace Sanatorium.DAL.Entities
{
    public class VoucherIllness
    {
        public int VoucherId { get; set; }

        public Voucher Voucher { get; set; }

        public int IllnessId { get; set; }

        public Illness Illness { get; set;}

        public int IllnessGrade { get; set; }
    }
}
