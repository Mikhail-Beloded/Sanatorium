using Sanatorium.DAL.Entities;

namespace Sanatorium.BLL.DTOs
{
    public class VoucherProcedureDto
    {
        public int VoucherId { get; set; }

        public VoucherDto Voucher { get; set; }

        public int ProcedureId { get; set; }

        public ProcedureDto Procedure { get; set; }

        public int ProcedureCount { get; set; }
    }
}
