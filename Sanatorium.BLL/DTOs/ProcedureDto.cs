namespace Sanatorium.BLL.DTOs
{
    public class ProcedureDto : DtoBase
    {
        public string Name { get; set; }

        public int SessionPrice { get; set; }

        public DateTime SessionTime { get; set; }

        public List<ProcedureIllnessDto> ProcedureIllness { get; set; }

        public List<ProcedureRecieptDto> ProcedureReciept { get; set; }
    }
}
