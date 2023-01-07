using Sanatorium.BLL.DTOs;
using Sanatorium.BLL.IServices;
using Sanatorium.BLL.Maping;
using Sanatorium.DAL.Repositories;

namespace Sanatorium.BLL.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IStatisticsRepository _repository;

        private readonly Mapper _mapper = new();

        public StatisticService(IStatisticsRepository repository)
        {
            _repository= repository;
        }

        public async Task<List<AgeStatisticDto>> GetAgeStatistic(CancellationToken cancellationToken)
        {
            var statistic = await _repository.GetAgeStatistic(cancellationToken);
            return _mapper.MapToDto(statistic);
        }

        public async Task<List<IllnessStasticDto>> GetIllnessStatistic(CancellationToken cancellationToken)
        {
            var statistic = await _repository.GetIllnessStatistic(cancellationToken);
            return _mapper.MapToDto(statistic);
        }

        public async Task<List<NewPatientsStatisticsDto>> GetNewPatientsStatistic(CancellationToken cancellationToken)
        {
            var statistic = await _repository.GetNewPateintsStatistic(cancellationToken);
            return _mapper.MapToDto(statistic);
        }

        public async Task<List<ProcedureStatisticDto>> GetProcedureStatistic(CancellationToken cancellationToken)
        {
            var statistic = await _repository.GetProcedureStatistic(cancellationToken);
            return _mapper.MapToDto(statistic);
        }
    }
}