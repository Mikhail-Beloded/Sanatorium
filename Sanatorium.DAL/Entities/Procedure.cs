namespace Sanatorium.DAL.Entities
{
    public class Procedure : EntityBase
    {
        public string Name { get; set; }

        public int SessionPrice { get; set; }

        public int SessionMinutes { get; set; }

        public List<VoucherProcedure> VoucherProcedures { get; set; }
    }
}
