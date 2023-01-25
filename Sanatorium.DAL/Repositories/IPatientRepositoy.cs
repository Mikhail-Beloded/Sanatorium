using Sanatorium.DAL.Entities;
using System.Linq.Expressions;

namespace Sanatorium.DAL.Repositories
{
    public interface IPatientRepositoy
    {
        Task AddPatientAsync(Patient patient, CancellationToken cancellationToken);

        Task DeletePatientAsync(Patient patient, CancellationToken cancellationToken);

        Task UpdatePatientAsync(Patient patient, CancellationToken cancellationToken);

        Task<Patient?> GetOneAsync(int id, CancellationToken cancellationToken);

        Task<List<Patient>> GetAllPatients(CancellationToken cancellationToken);

        Task<List<Patient>> GetAllPatients(Expression<Func<Patient, bool>> predicate, CancellationToken cancellationToken);

        Task<List<Patient>> GetPatientsOrdered(CancellationToken cancellationToken);
    }
}