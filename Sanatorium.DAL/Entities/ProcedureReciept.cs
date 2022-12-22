namespace Sanatorium.DAL.Entities
{
    public class ProcedureReciept : EntityBase
    {
        public Procedure Procedure { get; set; }

        public Reciept Reciept { get; set; }

        public int DoneProceduresCount { get; set; }
    }
}
