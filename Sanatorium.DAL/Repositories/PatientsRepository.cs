using Microsoft.EntityFrameworkCore;
using Sanatorium.DAL.Context;
using Sanatorium.DAL.Entities;
using System.Data;
using System.Linq.Expressions;

namespace Sanatorium.DAL.Repositories
{
    public class PatientsRepository : IPatientRepositoy
    {
        private EFContext _db;

        private DbSet<Patient> _table;

        public PatientsRepository(EFContext db)
        {
            _db = db;
            _table = _db.Set<Patient>();
        }

        public async Task AddPatientAsync(Patient patient, CancellationToken cancellationToken)
        {
            {
                _table.Attach(patient);
                await _table.AddAsync(patient, cancellationToken);
                await _db.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task DeletePatientAsync(Patient patient, CancellationToken cancellationToken)
        {
            _table.Remove(patient);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Patient>> GetAllPatients(CancellationToken cancellationToken)
        {
            return await _table.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<List<Patient>> GetAllPatients(Expression<Func<Patient, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _table.AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<Patient?> GetOneAsync(int id, CancellationToken cancellationToken)
        {
            return await _table.FirstOrDefaultAsync<Patient>(entity => entity.Id == id, cancellationToken);
        }

        public async Task<List<Patient>> GetPatientsOrdered(CancellationToken cancellationToken)
        {
            var result = new List<Patient>();
            using (var connection = _db.Database.GetDbConnection().CreateCommand())
            {
                var query = "SELECT * FROM dbo.Patients AS p ORDER BY p.FullName";
                connection.CommandType = CommandType.Text;
                connection.CommandText = query;

                await _db.Database.OpenConnectionAsync(cancellationToken);
                using (var reader = await connection.ExecuteReaderAsync(cancellationToken))
                {
                    while (await reader.ReadAsync(cancellationToken))
                    {
                        Patient temp = new Patient { Id = reader.GetInt32(0), FullName = reader.GetString(1), BirthDate = reader.GetDateTime(2), Gender = reader.GetString(3), Address = reader.GetString(4), PhoneNumber = reader.GetString(5), Email = reader.GetString(6), RegistrationDate = reader.GetString(7), VacineList = reader.GetString(8), WorkPlace = reader.GetString(9)};
                        result.Add(temp);
                    }
                }
            }
            return result;
        }

        public async Task UpdatePatientAsync(Patient patient, CancellationToken cancellationToken)
        {
            _table.Update(patient);
            _db.Attach<Patient>(patient).State = EntityState.Modified;
            _db.Entry<Patient>(patient).State = EntityState.Modified;
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
