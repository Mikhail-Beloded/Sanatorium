using Sanatorium.BLL.DTOs;
using Sanatorium.BLL.IServices;

namespace Sanatorium.BLL.Services
{
    public class PatientService : IPatientService
    {
        public Task AddPateintAsync(PatientDto patientDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<PatientDto> GetOnePatientAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemovePateintAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
