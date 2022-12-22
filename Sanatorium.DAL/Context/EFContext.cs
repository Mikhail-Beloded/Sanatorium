using Microsoft.EntityFrameworkCore;
using Sanatorium.DAL.Entities;

namespace Sanatorium.DAL.Context
{
    public class EFContext : DbContext
    {
        public EFContext() { }

        public EFContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = SanatoriumDB; Trusted_Connection = True;");
        }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<DoctorPatient> DoctorsPatients { get; set; }

        public DbSet<Illness> Illnesses { get; set;}

        public DbSet<IllnessPatient> IllnessesPatients { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Procedure> Procedures { get; set; }

        public DbSet<ProcedureIllness> ProceduresIllnesses { get; set;}

        public DbSet<ProcedureReciept> ProceduresReciepts { get; set; }

        public DbSet<Reciept> Reciepts { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomPatient> RoomsPatients { get;set; }

        public DbSet<Voucher> Vouchers { get; set; }
    }
}
