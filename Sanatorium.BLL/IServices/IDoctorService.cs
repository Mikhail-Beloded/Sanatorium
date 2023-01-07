using Sanatorium.BLL.DTOs;

namespace Sanatorium.BLL.IServices
{
    public interface IDoctorService
    {
        Task<List<DoctorDto>> GetAllDoctors(CancellationToken cancellationToken);

        Task RemoveDoctorAsync(int id, CancellationToken cancellationToken);

        Task AddDoctorAsync(DoctorDto doctor, CancellationToken cancellationToken);

        Task UpdateDoctorAsync(DoctorDto doctorDto, CancellationToken cancellationToken);

        Task<DoctorDto> GetOneDoctorAsync(int id, CancellationToken cancellationToken);
    }
}
