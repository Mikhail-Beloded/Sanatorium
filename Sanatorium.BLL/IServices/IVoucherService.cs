using Sanatorium.BLL.DTOs;

namespace Sanatorium.BLL.IServices
{
    public interface IVoucherService
    {
        Task<List<VoucherDto>> GetAllVouchers(CancellationToken cancellationToken);

        Task<List<VoucherDto>> GetAllVouchersWithoutDoctors(CancellationToken cancellationToken);

        Task AddVoucherAsync(VoucherDto voucherDto, CancellationToken cancellationToken);

        Task<byte[]> GenerateDirectionPdf(int id, CancellationToken cancellationToken);

        Task<List<VoucherDto>> GetAllVouchersWithoutProcedures(CancellationToken cancellationToken);
    }
}
