using Microsoft.EntityFrameworkCore;
using Sanatorium.DAL.Entities;

namespace Sanatorium.DAL.Context
{
    public class EFContext : DbContext
    {
        public EFContext()
        {
        }

        public EFContext(DbContextOptions<EFContext> options)
    : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = SanatoriumDB; Trusted_Connection = True; TrustServerCertificate = true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorPatient>().HasKey(x => new { x.PatientId, x.DoctorId });
            modelBuilder.Entity<IllnessPatient>().HasKey(x => new { x.IllnessId, x.PatientId });
            modelBuilder.Entity<ProcedureIllness>().HasKey(x => new { x.ProcedureId, x.IllnessId });
            modelBuilder.Entity<ProcedureReciept>().HasKey(x => new { x.ProcedureId, x.RecieptId });
            modelBuilder.Entity<RoomPatient>().HasKey(x => new { x.PatientId, x.RoomId });
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
