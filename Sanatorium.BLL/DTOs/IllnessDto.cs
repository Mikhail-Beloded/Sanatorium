namespace Sanatorium.BLL.DTOs
{
    public class IllnessDto : DtoBase
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public List<IllnessPatientDto> IllnessPatients { get; set; }

        public List<ProcedureIllnessDto> ProcedureIllness { get; set; }
    }
}
