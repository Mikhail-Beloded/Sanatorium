namespace Sanatorium.DAL.Entities
{
    public class ProcedureIllness : EntityBase
    {
        public Procedure Procedure { get; set; }

        public Illness Illness { get; set; }

        public int ProceduresCount { get; set; }
    }
}
