using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sanatorium.DAL.Context;
using Sanatorium.DAL.Entities;
using System.Linq.Expressions;

namespace Sanatorium.DAL.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private EFContext _db;

        private DbSet<Doctor> _table;

        public DoctorRepository(EFContext db)
        {
            _db= db;
            _table = _db.Set<Doctor>();
        }

        public async Task AddAsync(Doctor doctor, CancellationToken cancellationToken)
        {
            _table.Attach(doctor);
            await _table.AddAsync(doctor, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Doctor doctor, CancellationToken cancellationToken)
        {
            _table.Remove(doctor);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Doctor doctor, CancellationToken cancellationToken)
        {
            _table.Update(doctor);
            _db.Attach<Doctor>(doctor).State = EntityState.Modified;
            _db.Entry<Doctor>(doctor).State = EntityState.Modified;
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Doctor>> GetAll(CancellationToken cancellationToken)
        {
            return await _table.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<List<Doctor>> GetAll(Expression<Func<Doctor, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _table.AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<Doctor?> GetOneAsync(int id, CancellationToken cancellationToken)
        {
            return await _table.FirstOrDefaultAsync<Doctor>(entity => entity.Id == id, cancellationToken);
        }

        public async Task<Doctor?> GetOneForDirectionAsync(int id, string illnessType, CancellationToken cancellationToken)
        {
            var doctors = _table.Include(x => x.Vouchers).Where(x => x.Specialization == illnessType).ToList();
            var workload = new Dictionary<int, double>();
            foreach(var doctor in doctors)
            {
                workload.Add(doctor.Id, (doctor.Vouchers.Count + (((DateTime.Now.Year - doctor.BirthDate.Year)) - 18) * 2) / 100);
            }

            var doctorId = workload.MinBy(kvp => kvp.Value).Key;
            return await GetOneAsync(doctorId, cancellationToken);
        }
    }
}
