using Sanatorium.BLL.DTOs;
using Sanatorium.DAL.Entities;
using System.Linq.Expressions;

namespace Sanatorium.BLL.IServices
{
    public interface IPatientService
    {
        Task<List<PatientDto>> GetAllPatients(CancellationToken cancellationToken);

        Task<List<PatientDto>> GetPatientsOrdered(CancellationToken cancellationToken);

        Task<List<PatientDto>> GetAllPatients(Expression<Func<Patient, bool>> predicate, CancellationToken cancellationToken);

        Task AddPateintAsync(PatientDto patientDto, CancellationToken cancellationToken);

        Task RemovePateintAsync(int id, CancellationToken cancellationToken);

        Task UpdatePatientAsync(PatientDto patientDto, CancellationToken cancellationToken);

        Task<PatientDto> GetOnePatientAsync(int id, CancellationToken cancellationToken);
    }
}
