using Sanatorium.BLL.DTOs;
using Sanatorium.BLL.IServices;
using Sanatorium.BLL.Maping;
using Sanatorium.DAL.Repositories;

namespace Sanatorium.BLL.Services
{
    public class VoucherRoomService : IVoucherRoomService
    {
        private readonly IVoucherRoomRepository _repository;

        private readonly Mapper _mapper = new Mapper();

        public VoucherRoomService(IVoucherRoomRepository repository)
        {
            _repository= repository;
        }
        public async Task AddVoucherRoomAsync(VoucherRoomDto voucher, CancellationToken cancellationToken)
        {
            var entity = _mapper.MapFromDto(voucher);
            await _repository.AddVoucherRoomAsync(entity, cancellationToken);
        }
    }
}