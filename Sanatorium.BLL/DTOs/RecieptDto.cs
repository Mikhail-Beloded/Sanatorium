namespace Sanatorium.BLL.DTOs
{
    public class RecieptDto
    {
        public DateTime CreateDate { get; set; }

        public double Sum { get; set; }

        public string Type { get; set; }

        public PatientDto Patient { get; set; }

        public List<ProcedureRecieptDto> ProcedureReciept { get; set; }
    }
}
