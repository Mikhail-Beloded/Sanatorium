using Sanatorium.BLL.DTOs;

namespace Sanatorium.BLL.IServices
{
    public interface IIllnessService
    {
        Task<List<IllnessDto>> GetAllIllnesses(CancellationToken cancellationToken);

        Task AddIllnessAsync(IllnessDto illness, CancellationToken cancellationToken);

        Task RemoveIllnessAsync(int id, CancellationToken cancellationToken);

        Task<IllnessDto> GetOneIllnessAsync(int id, CancellationToken cancellationToken);

        Task UpdateIllnessAsync(IllnessDto illness, CancellationToken cancellationToken);
    }
}
