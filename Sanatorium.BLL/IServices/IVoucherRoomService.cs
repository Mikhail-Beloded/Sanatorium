using Sanatorium.BLL.DTOs;

namespace Sanatorium.BLL.IServices
{
    public interface IVoucherRoomService
    {
        Task AddVoucherRoomAsync(VoucherRoomDto voucher, CancellationToken cancellationToken);
    }
}
