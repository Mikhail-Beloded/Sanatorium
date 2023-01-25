using Sanatorium.DAL.Entities;

namespace Sanatorium.DAL.Repositories
{
    public interface IRecieptRepository
    {
        Task DeleteRecieptAsync(Reciept reciept, CancellationToken cancellationToken);

        Task<Reciept?> GetOneAsync(int id, CancellationToken cancellationToken);

        Task<List<Reciept>> GetAll(CancellationToken cancellationToken);

        Task<Reciept?> GetOneWithPatient(int id, CancellationToken cancellationToken);
    }
}
