using Sanatorium.BLL.DTOs;

namespace Sanatorium.BLL.IServices
{
    public interface IVoucherService
    {
        Task<List<VoucherDto>> GetAllVouchers(CancellationToken cancellationToken);

        Task AddVoucherAsync(VoucherDto voucherDto, CancellationToken cancellationToken);
    }
}
