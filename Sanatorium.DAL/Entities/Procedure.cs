namespace Sanatorium.DAL.Entities
{
    public class Procedure : EntityBase
    {
        public string Name { get; set; }

        public int SessionPrice { get; set; }

        public DateTime SessionTime { get; set; }

        public List<ProcedureIllness> ProcedureIllness { get; set; }

        public List<ProcedureReciept> ProcedureReciept { get; set; }
    }
}
