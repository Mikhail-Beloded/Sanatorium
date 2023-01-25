using Sanatorium.DAL.Entities;

namespace Sanatorium.DAL.Repositories
{
    public interface IVoucherRepository
    {
        Task AddAsync(Voucher voucher, CancellationToken cancellationToken);

        Task<List<Voucher>> GetAll(CancellationToken cancellationToken);

        Task<Voucher?> GetOneAsync(int id, CancellationToken cancellationToken);

        Task<List<Voucher>> GetAllVouchersWithoutDoctors(CancellationToken cancellationToken);

        Task<List<Voucher>> GetAllVouchersWithoutProcedures(CancellationToken cancellationToken);

        Task UpdateAsync(Voucher voucher, CancellationToken cancellationToken);
    }
}
