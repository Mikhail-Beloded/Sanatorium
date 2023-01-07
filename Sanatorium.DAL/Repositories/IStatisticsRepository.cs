using Sanatorium.DAL.Entities;

namespace Sanatorium.DAL.Repositories
{
    public interface IStatisticsRepository
    {
        Task<List<IllnessStatistic>> GetIllnessStatistic(CancellationToken cancellationToken);

        Task<List<ProcedureStatistic>> GetProcedureStatistic(CancellationToken cancellationToken);

        Task<List<NewPatientsStatistics>> GetNewPateintsStatistic(CancellationToken cancellationToken);

        Task<List<AgeStatistics>> GetAgeStatistic(CancellationToken cancellationToken);
    }
}
