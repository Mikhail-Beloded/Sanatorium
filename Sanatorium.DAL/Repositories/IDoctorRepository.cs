using Sanatorium.DAL.Entities;
using System.Linq.Expressions;

namespace Sanatorium.DAL.Repositories
{
    public interface IDoctorRepository
    {
        Task AddAsync(Doctor doctor, CancellationToken cancellationToken);

        Task DeleteAsync(Doctor doctor, CancellationToken cancellationToken);

        Task UpdateAsync(Doctor doctor, CancellationToken cancellationToken);

        Task<Doctor?> GetOneAsync(int id, CancellationToken cancellationToken);

        Task<List<Doctor>> GetAll(CancellationToken cancellationToken);

        Task<List<Doctor>> GetAll(Expression<Func<Doctor, bool>> predicate, CancellationToken cancellationToken);

        Task<Doctor?> GetOneForDirectionAsync(int id, string illnessType, CancellationToken cancellationToken);
    }
}
