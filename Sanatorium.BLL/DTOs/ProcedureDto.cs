namespace Sanatorium.BLL.DTOs
{
    public class ProcedureDto : DtoBase
    {
        public string Name { get; set; }

        public int SessionPrice { get; set; }

        public int SessionMinutes { get; set; }

        public List<VoucherProcedureDto> VoucherProcedures { get; set; }
    }
}
