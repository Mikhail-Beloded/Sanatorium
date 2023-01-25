using Sanatorium.DAL.Context;
using Sanatorium.DAL.Entities;

namespace Sanatorium.DAL
{
    public static class DbInitialaizer
    {
        public static void Initialize(EFContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var room1 = new Room
            {
                Price = 100,
                Capacity = 5,
            };

            var room2 = new Room
            {
                Price = 200,
                Capacity = 2,
            };

            var room3 = new Room
            {
                Price = 500,
                Capacity = 1,
            };

            var room4 = new Room
            {
                Price = 100,
                Capacity = 5,
            };

            var room5 = new Room
            {
                Price = 200,
                Capacity = 1,
            };

            var room6 = new Room
            {
                Price = 100,
                Capacity = 5,
            };

            var room7 = new Room
            {
                Price = 500,
                Capacity = 1,
            };

            var patient4 = new Patient
            {
                FullName = "Adam Smith",

                BirthDate = new DateTime(1960, 9, 15),

                Gender = "male",

                Address = "Kharkiv",

                PhoneNumber = "+380504547412",

                Email = "smith@gmail.com",

                RegistrationDate = "02.01.2023",

                VacineList = "COVID-19: Coronavac",

                WorkPlace = "driver",
            };

            var patient5 = new Patient
            {
                FullName = "Ben Potter",

                BirthDate = new DateTime(1938, 1, 25),

                Gender = "male",

                Address = "Kharkiv",

                PhoneNumber = "+380958587114",

                Email = "potter@gmail.com",

                RegistrationDate = "02.01.2023",

                VacineList = "-",

                WorkPlace = "singer",
            };

            var patient6 = new Patient
            {
                FullName = "Lucie Brown",

                BirthDate = new DateTime(2004, 1, 26),

                Gender = "female",

                Address = "Kiyv",

                PhoneNumber = "+380504589154",

                Email = "brown@gmail.com",

                RegistrationDate = "01.01.2023",

                VacineList = "-",

                WorkPlace = "programmer",
            };

            var voucher1 = new Voucher
            {
                CreationDate = DateTime.Now.Date,

                ExpirationDate = DateTime.Now.Date,

                Patient = patient6,
            };

            var voucher2 = new Voucher
            {
                CreationDate = DateTime.Now.Date,

                ExpirationDate = DateTime.Now.Date,

                Patient = patient5,
            };

            var voucher3 = new Voucher
            {
                CreationDate = DateTime.Now.Date,

                ExpirationDate = DateTime.Now.Date,

                Patient = patient4,
            };

            var voucherRoom4 = new VoucherRoom
            {
                Room = room4,
                Voucher = voucher3,
                DayCount = 5,
            };

            var voucherRoom5 = new VoucherRoom
            {
                Room = room6,
                Voucher = voucher2,
                DayCount = 8,
            };

            var voucherRoom6 = new VoucherRoom
            {
                Room = room5,
                Voucher = voucher1,
                DayCount = 7,
            };

            voucher1.VoucherRooms = new List<VoucherRoom> { voucherRoom6 };
            voucher2.VoucherRooms = new List<VoucherRoom> { voucherRoom5 };
            voucher3.VoucherRooms = new List<VoucherRoom> { voucherRoom4 };

            var procedure1 = new Procedure
            {
                Name = "massage",
                SessionPrice = 1000,
                SessionMinutes = 30,
            };

            var procedure2 = new Procedure
            {
                Name = "inhalation",
                SessionPrice = 200,
                SessionMinutes = 15,
            };

            var procedure3 = new Procedure
            {
                Name = "aromatherapy",
                SessionPrice = 500,
                SessionMinutes = 60,
            };

            var voucherProcedure1 = new VoucherProcedure { Procedure = procedure1, Voucher = voucher1, ProcedureCount = 5 };
            var voucherProcedure2 = new VoucherProcedure { Procedure = procedure2, Voucher = voucher1, ProcedureCount = 2 };
            var voucherProcedure3 = new VoucherProcedure { Procedure = procedure3, Voucher = voucher2, ProcedureCount = 3 };
            var voucherProcedure4 = new VoucherProcedure { Procedure = procedure3, Voucher = voucher3, ProcedureCount = 3 };

            voucher1.VoucherProcedures = new List<VoucherProcedure> { voucherProcedure1, voucherProcedure2 };
            voucher2.VoucherProcedures = new List<VoucherProcedure> { voucherProcedure3 };
            voucher3.VoucherProcedures = new List<VoucherProcedure> { voucherProcedure4 };

            var doctor1 = new Doctor
            {
                FullName = "Bilodid Mykhailo Oleksandrovych",

                BirthDate = DateTime.Now,

                Gender = "male",

                PhoneNumber = "+380995326869",

                Specialization = "heart illnesses",

                Vouchers = new List<Voucher> { voucher1 }
            };

            var doctor2 = new Doctor
            {
                FullName = "Visockiy Volodymyr Semenovich",

                BirthDate = DateTime.Now,

                Gender = "male",

                PhoneNumber = "+380995384769",

                Specialization = "breath illnesses",

                Vouchers = new List<Voucher> { voucher2}
            };

            var doctor3 = new Doctor
            {
                FullName = "Jack Adams",

                BirthDate = DateTime.Now,

                Gender = "male",

                PhoneNumber = "+380989526869",

                Specialization = "skin illnesses",

                Vouchers = new List<Voucher> { voucher3}
            };

            voucher1.Doctor = doctor1;
            voucher2.Doctor = doctor2;
            voucher3.Doctor = doctor3;

            var illness1 = new Illness
            {
                Name = "heart attack",
                Type = "heart illnesses",
                Vouchers = new List<Voucher> { voucher1}
            };

            var illness2 = new Illness
            {

                Name = "tuberculosis",
                Type = "breath illnesses",
                Vouchers = new List<Voucher> { voucher2}
            };

            var illness3 = new Illness
            {
                Name = "allergy",
                Type = "skin illnesses",
                Vouchers = new List<Voucher> { voucher3}
            };

            voucher1.Illness = illness1;
            voucher2.Illness = illness2;
            voucher3.Illness = illness3;

            var reciept1 = new Reciept
            {
                CreateDate = DateTime.Now,
                Sum = 2000,
                Type = "paper",
                Voucher = voucher1
            };

            var reciept2 = new Reciept
            {
                CreateDate = DateTime.Now,
                Sum = 5000,
                Type = "paper",
                Voucher = voucher2
            };

            var reciept3 = new Reciept
            {
                CreateDate = DateTime.Now,
                Sum = 1000,
                Type = "electronic",
                Voucher = voucher3
            };

            db.Reciepts.AddRange(reciept1, reciept2, reciept3);
            db.Procedures.AddRange(procedure1, procedure2, procedure3);
            db.Illnesses.AddRange(illness1, illness2, illness3);
            db.Doctors.AddRange(doctor1, doctor2, doctor3);
            db.Vouchers.AddRange(voucher1, voucher2, voucher3);
            db.Patients.AddRange(patient4, patient5, patient6); 
            db.Rooms.AddRange(room1, room2, room3, room4, room5, room6, room7);

            db.SaveChanges();
        }
    }
}