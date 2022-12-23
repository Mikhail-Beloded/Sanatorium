namespace Sanatorium.BLL.DTOs
{
    public class ProcedureDto
    {
        public string Name { get; set; }

        public int SessionPrice { get; set; }

        public TimeOnly SessionTime { get; set; }

        public List<ProcedureIllnessDto> ProcedureIllness { get; set; }

        public List<ProcedureRecieptDto> ProcedureReciept { get; set; }
    }
}
