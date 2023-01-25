using Sanatorium.BLL.DTOs;

namespace Sanatorium.BLL.IServices
{
    public interface IProcedureService
    {
        Task<List<ProcedureDto>> GetAllProcedures(CancellationToken cancellationToken);

        Task AddProcedureAsync(ProcedureDto procedure, CancellationToken cancellationToken);

        Task RemoveProcedureAsync(int id, CancellationToken cancellationToken);

        Task<ProcedureDto> GetOneProcedureAsync(int id, CancellationToken cancellationToken);

        Task UpdateProcedureAsync(ProcedureDto procedure, CancellationToken cancellationToken);
    }
}
