using Microsoft.EntityFrameworkCore;
using Sanatorium.DAL.Entities;
using System.Security.Cryptography.X509Certificates;

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
            modelBuilder.Entity<VoucherDoctor>().HasKey(x => new { x.VoucherId, x.DoctorId });
            modelBuilder.Entity<VoucherIllness>().HasKey(x => new { x.VoucherId, x.IllnessId });
            modelBuilder.Entity<VoucherProcedure>().HasKey(x => new { x.VoucherId, x.ProcedureId });
            modelBuilder.Entity<VoucherRoom>().HasKey(x => new { x.VoucherId, x.RoomId });
            modelBuilder.Entity<Voucher>().HasOne(x => x.Reciept)
                                          .WithOne(y => y.Voucher)
                                          .HasForeignKey<Reciept>(z => z.VoucherId);
        }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Illness> Illnesses { get; set;}

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Procedure> Procedures { get; set; }

        public DbSet<Reciept> Reciepts { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Voucher> Vouchers { get; set; }

        public DbSet<VoucherDoctor> VoucherDoctors { get; set; }

        public DbSet<VoucherIllness> VoucherIllnesses { get; set; }

        public DbSet<VoucherProcedure> VoucherProcedures { get; set; }

        public DbSet<VoucherRoom> VoucherRooms { get; set; }
    }
}
