using Sanatorium.BLL.DTOs;
using Sanatorium.DAL.Paging;

namespace Sanatorium.BLL.IServices
{
    public interface IPatientService
    {
        Task AddPateintAsync(PatientDto patientDto, CancellationToken cancellationToken);

        Task RemovePateintAsync(int id, CancellationToken cancellationToken);

        Task<PatientDto> GetOnePatientAsync(int id, CancellationToken cancellationToken);

        Task<PagedList<PatientDto>> GetPagePatientAsync(PageParameters pageParameters, CancellationToken cancellationToken);
    }
}
