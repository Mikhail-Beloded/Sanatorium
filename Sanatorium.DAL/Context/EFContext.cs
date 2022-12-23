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
            optionsBuilder.UseSqlServer("workstation id=SanatoriymDb.mssql.somee.com;packet size=4096;user id=MykhailoBilodid_SQLLogin_1;pwd=e26jbwq1hh;data source=SanatoriymDb.mssql.somee.com;persist security info=False;initial catalog=SanatoriymDb");
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
