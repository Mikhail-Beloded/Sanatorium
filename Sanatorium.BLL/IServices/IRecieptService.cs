using Sanatorium.BLL.DTOs;

namespace Sanatorium.BLL.IServices
{
    public interface IRecieptService
    {
        Task DeleteRecieptAsync(int id, CancellationToken cancellationToken);

        Task<RecieptDto?> GetOneAsync(int id, CancellationToken cancellationToken);

        Task<List<RecieptDto>> GetAll(CancellationToken cancellationToken);

        Task<byte[]> GeneratePdfReciept(int id, CancellationToken cancellationToken);
    } 
}
