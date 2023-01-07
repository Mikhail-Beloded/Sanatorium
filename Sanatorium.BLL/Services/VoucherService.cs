using Sanatorium.BLL.DTOs;
using Sanatorium.BLL.IServices;
using Sanatorium.BLL.Maping;
using Sanatorium.DAL.Entities;
using Sanatorium.DAL.Repositories;
using System.Linq.Expressions;

namespace Sanatorium.BLL.Services
{
    public class VoucherService : IVoucherService
    {
        private readonly IGenericRepository<Voucher> _repository;

        private Mapper _mapper = new();

        public VoucherService(IGenericRepository<Voucher> repository) 
        {
            _repository= repository;
        }

        public async Task AddVoucherAsync(VoucherDto voucherDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.MapFromDto(voucherDto);
            await _repository.AddAsync(entity, cancellationToken);
        }

        public async Task<List<VoucherDto>> GetAllVouchers(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAll(cancellationToken);
            return _mapper.MapToDto(entities);
        }
    }
}
