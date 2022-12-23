using Sanatorium.BLL.DTOs;

namespace Sanatorium.BLL.IServices
{
    public interface IPatientService
    {
        Task AddPateintAsync(PatientDto patientDto, CancellationToken cancellationToken);

        Task RemovePateintAsync(int id, CancellationToken cancellationToken);

        Task<PatientDto> GetOnePatientAsync(int id, CancellationToken cancellationToken);
    }
}
