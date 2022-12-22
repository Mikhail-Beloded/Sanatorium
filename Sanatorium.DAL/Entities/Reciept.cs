namespace Sanatorium.DAL.Entities
{
    public class Reciept : EntityBase
    {
        public DateTime CreateDate { get; set; }

        public double Sum { get; set; }

        public string Type { get; set; }

        public Patient Patient { get; set; }
    }
}
