using Microsoft.EntityFrameworkCore;
using Sanatorium.DAL.Context;
using Sanatorium.DAL.Entities;
using System.Data;

namespace Sanatorium.DAL.Repositories
{
    public class StatisticRepository : IStatisticsRepository
    {
        private EFContext _db;

        public StatisticRepository(EFContext db)
        {
            _db = db;
        }

        public async Task<List<IllnessStatistic>> GetIllnessStatistic(CancellationToken cancellationToken)
        {
            var result = new List<IllnessStatistic>();
            using (var connection = _db.Database.GetDbConnection().CreateCommand())
            {
                var query = "SELECT TOP(5) i.[Name], (SELECT COUNT(*) FROM dbo.Vouchers AS pi WHERE i.Id = pi.IllnessId) as PatientsCount, (SELECT COUNT(*) FROM dbo.Vouchers AS p) as TotalPatients FROM dbo.Illnesses AS i GROUP BY i.Id, i.[Name] ORDER BY PatientsCount DESC, TotalPatients DESC";
                connection.CommandType = CommandType.Text;
                connection.CommandText = query;

                await _db.Database.OpenConnectionAsync(cancellationToken);
                using (var reader = await connection.ExecuteReaderAsync(cancellationToken))
                {
                    while (await reader.ReadAsync(cancellationToken))
                    {
                        IllnessStatistic temp = new IllnessStatistic { Name = reader.GetString(0), PatientCount = reader.GetInt32(1), TotalPatients = reader.GetInt32(2) };
                        result.Add(temp);
                    }
                }
            }
            return result;
        }

        public async Task<List<NewPatientsStatistics>> GetNewPateintsStatistic(CancellationToken cancellationToken)
        {
            var result = new List<NewPatientsStatistics>();
            using (var connection = _db.Database.GetDbConnection().CreateCommand())
            {
                var query = "SELECT DISTINCT i.[RegistrationDate], (SELECT COUNT(*) FROM dbo.Patients AS pi WHERE i.RegistrationDate = pi.RegistrationDate) as PatientsCount, (SELECT COUNT(*) FROM dbo.Vouchers AS p) as TotalPatients FROM dbo.Patients AS i GROUP BY i.Id, i.[RegistrationDate] ORDER BY PatientsCount DESC, TotalPatients DESC";
                connection.CommandType = CommandType.Text;
                connection.CommandText = query;

                await _db.Database.OpenConnectionAsync(cancellationToken);
                using (var reader = await connection.ExecuteReaderAsync(cancellationToken))
                {
                    while (await reader.ReadAsync(cancellationToken))
                    {
                        NewPatientsStatistics temp = new NewPatientsStatistics { Date = reader.GetString(0), PatientCount = reader.GetInt32(1), TotalPatients = reader.GetInt32(2) };
                        result.Add(temp);
                    }
                }
            }
            return result;
        }

        public async Task<List<ProcedureStatistic>> GetProcedureStatistic(CancellationToken cancellationToken)
        {
            var result = new List<ProcedureStatistic>();
            using (var connection = _db.Database.GetDbConnection().CreateCommand())
            {
                var query = "SELECT TOP(5) p.[Name], (SELECT COUNT(*) FROM dbo.VoucherProcedures AS pi WHERE p.Id = pi.ProcedureId) as PatientsCount, (SELECT COUNT(*) FROM dbo.Vouchers AS t) as TotalPatients FROM dbo.Procedures AS p GROUP BY p.Id, p.[Name] ORDER BY PatientsCount DESC, TotalPatients DESC";
                connection.CommandType = CommandType.Text;
                connection.CommandText = query;

                await _db.Database.OpenConnectionAsync(cancellationToken);
                using (var reader = await connection.ExecuteReaderAsync(cancellationToken))
                {
                    while (await reader.ReadAsync(cancellationToken))
                    {
                        ProcedureStatistic temp = new ProcedureStatistic { Name = reader.GetString(0), PatientCount = reader.GetInt32(1), TotalPatients = reader.GetInt32(2) };
                        result.Add(temp);
                    }
                }
            }
            return result;
        }

        public async Task<List<AgeStatistics>> GetAgeStatistic(CancellationToken cancellationToken)
        {
            var result = new List<AgeStatistics>();
            using (var connection = _db.Database.GetDbConnection().CreateCommand())
            {
                var query = "SELECT DATEDIFF(year, i.[BirthDate], GETDATE()), (SELECT COUNT(*) FROM dbo.Patients AS pi WHERE i.BirthDate = pi.BirthDate) as PatientsCount, (SELECT COUNT(*) FROM dbo.Vouchers AS p) as TotalPatients FROM dbo.Patients AS i GROUP BY i.Id, i.[BirthDate] ORDER BY i.[BirthDate]";
                connection.CommandType = CommandType.Text;
                connection.CommandText = query;

                await _db.Database.OpenConnectionAsync(cancellationToken);
                using (var reader = await connection.ExecuteReaderAsync(cancellationToken))
                {
                    while (await reader.ReadAsync(cancellationToken))
                    {
                        AgeStatistics temp = new AgeStatistics { Age = reader.GetInt32(0), PatientCount = reader.GetInt32(1), TotalPatients = reader.GetInt32(2) };
                        result.Add(temp);
                    }
                }
            }
            return result;
        }
    }
}
