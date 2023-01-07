namespace Sanatorium.DAL.Entities
{
    public class Illness : EntityBase
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public List<VoucherIllness> VoucherIllnesses { get; set; }
    }
}
