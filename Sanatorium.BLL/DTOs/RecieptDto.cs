namespace Sanatorium.BLL.DTOs
{
    public class RecieptDto : DtoBase
    {
        public DateTime CreateDate { get; set; }

        public double Sum { get; set; }

        public string Type { get; set; }

        public int VoucherId { get; set; }

        public VoucherDto Voucher { get; set; }
    }
}
