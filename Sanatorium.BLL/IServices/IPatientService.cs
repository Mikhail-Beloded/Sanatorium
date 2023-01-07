using Sanatorium.BLL.DTOs;

namespace Sanatorium.BLL.IServices
{
    public interface IPatientService
    {
        Task<List<PatientDto>> GetAllPatients(CancellationToken cancellationToken);

        Task AddPateintAsync(PatientDto patientDto, CancellationToken cancellationToken);

        Task RemovePateintAsync(int id, CancellationToken cancellationToken);

        Task UpdatePatientAsync(PatientDto patientDto, CancellationToken cancellationToken);

        Task<PatientDto> GetOnePatientAsync(int id, CancellationToken cancellationToken);
    }
}
