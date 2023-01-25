namespace Sanatorium.DAL.Entities
{
    public class Reciept : EntityBase
    {
        public DateTime CreateDate { get; set; }

        public double Sum { get; set; }

        public string Type { get; set; }

        public int VoucherId { get; set; }

        public Voucher Voucher { get; set; }
    }
}
