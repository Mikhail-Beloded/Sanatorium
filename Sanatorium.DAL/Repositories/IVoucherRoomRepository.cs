using Sanatorium.DAL.Entities;

namespace Sanatorium.DAL.Repositories
{
    public interface IVoucherRoomRepository
    {
        Task AddVoucherRoomAsync(VoucherRoom entity, CancellationToken cancellationToken);
    }
}
