﻿using Sanatorium.BLL.DTOs;
using Sanatorium.BLL.IServices;
using Sanatorium.BLL.Maping;
using Sanatorium.DAL.Entities;
using Sanatorium.DAL.Paging;
using Sanatorium.DAL.Repositories;

namespace Sanatorium.BLL.Services
{
    public class PatientService : IPatientService
    {
        private readonly IGenericRepository<Patient> _repository;

        private readonly Mapper _mapper = new Mapper();

        public PatientService(IGenericRepository<Patient> repository)
        {
            _repository = repository;
        }

        public async Task AddPateintAsync(PatientDto patientDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.MapFromDto(patientDto);
            await _repository.AddAsync(entity, cancellationToken);
        }

        public async Task<PatientDto> GetOnePatientAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetOneAsync(id, cancellationToken);
            if(entity == null)
            {
                throw new ArgumentNullException();
            }
            return _mapper.MapToDto(entity);
        }

        public async Task<PagedList<PatientDto>> GetPagePatientAsync(PageParameters pageParameters, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetPageAsync(pageParameters, cancellationToken);
            var dtos = _mapper.MapToDto(entities);
            return dtos;
        }

        public async Task RemovePateintAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetOneAsync(id, cancellationToken);
            await _repository.DeleteAsync(entity, cancellationToken);
        }
    }
}
