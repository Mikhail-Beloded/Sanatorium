using Sanatorium.BLL.DTOs;
using Sanatorium.BLL.IServices;
using Sanatorium.BLL.Maping;
using Sanatorium.DAL.Entities;
using Sanatorium.DAL.Repositories;

namespace Sanatorium.BLL.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IGenericRepository<Doctor> _repository;

        private Mapper _mapper = new Mapper();

        public DoctorService(IGenericRepository<Doctor> repository)
        {
            _repository= repository;
        }

        public async Task AddDoctorAsync(DoctorDto doctor, CancellationToken cancellationToken)
        {
            var entity = _mapper.MapFromDto(doctor);
            await _repository.AddAsync(entity, cancellationToken);
        }

        public async Task<List<DoctorDto>> GetAllDoctors(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAll(cancellationToken);
            return _mapper.MapToDto(entities);
        }

        public async Task<DoctorDto> GetOneDoctorAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetOneAsync(id, cancellationToken);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            return _mapper.MapToDto(entity);
        }

        public async Task RemoveDoctorAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetOneAsync(id, cancellationToken);
            await _repository.DeleteAsync(entity, cancellationToken);
        }

        public async Task UpdateDoctorAsync(DoctorDto doctorDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.MapFromDto(doctorDto);
            await _repository.UpdateAsync(entity, cancellationToken);
        }
    }
}
