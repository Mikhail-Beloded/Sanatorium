namespace Sanatorium.DAL.Entities
{
    public class ProcedureReciept
    {
        public int ProcedureId { get; set; }

        public Procedure Procedure { get; set; }

        public int RecieptId { get; set; }

        public Reciept Reciept { get; set; }

        public int DoneProceduresCount { get; set; }
    }
}
