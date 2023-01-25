using Sanatorium.BLL.DTOs;

namespace Sanatorium.BLL.IServices
{
    public interface IStatisticService
    {
        Task<List<IllnessStasticDto>> GetIllnessStatistic(CancellationToken cancellationToken);

        Task<List<ProcedureStatisticDto>> GetProcedureStatistic(CancellationToken cancellationToken);

        Task<List<NewPatientsStatisticsDto>> GetNewPatientsStatistic(CancellationToken cancellationToken);

        Task<List<AgeStatisticDto>> GetAgeStatistic(CancellationToken cancellationToken);
    }
}
