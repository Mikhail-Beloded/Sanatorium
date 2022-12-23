namespace Sanatorium.DAL.Entities
{
    public class ProcedureIllness
    {
        public int ProcedureId { get; set; }

        public Procedure Procedure { get; set; }

        public int IllnessId { get; set; }

        public Illness Illness { get; set; }

        public int ProceduresCount { get; set; }
    }
}
