namespace Sanatorium.DAL.Entities
{
    public class Voucher : EntityBase
    {
        public DateTime CreationDate { get; set; }

        public string Illness { get; set; }

        public int DayCount { get; set; }

        public Patient Patient { get; set; }
    }
}
