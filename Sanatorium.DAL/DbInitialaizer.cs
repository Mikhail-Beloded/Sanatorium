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
                Capacity = 2,
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
                FullName = "Іванов Іван Іванович",

                BirthDate = new DateTime(1960, 9, 15),

                Gender = "чоловіча",

                Address = "Харків",

                PhoneNumber = "+380504547412",

                Email = "ivanov@gmail.com",

                RegistrationDate = "02.01.2023",

                VacineList = "COVID-19: Coronavac",

                WorkPlace = "інженер",
            };

            var patient5 = new Patient
            {
                FullName = "Висоцький Володимир Семенович",

                BirthDate = new DateTime(1938, 1, 25),

                Gender = "чоловіча",

                Address = "Харків",

                PhoneNumber = "+380958587114",

                Email = "visockiy@gmail.com",

                RegistrationDate = "02.01.2023",

                VacineList = "-",

                WorkPlace = "співак",
            };

            var patient6 = new Patient
            {
                FullName = "Петренко Валентина Петрівна",

                BirthDate = new DateTime(2004, 1, 26),

                Gender = "жіноча",

                Address = "Київ",

                PhoneNumber = "+380504589154",

                Email = "petrenko@gmail.com",

                RegistrationDate = "01.01.2023",

                VacineList = "-",

                WorkPlace = "програміст",
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
                Name = "массаж",
                SessionPrice = 1000,
                SessionMinutes = 30,
            };

            var procedure2 = new Procedure
            {
                Name = "інгаляції",
                SessionPrice = 200,
                SessionMinutes = 15,
            };

            var procedure3 = new Procedure
            {
                Name = "ароматерапія",
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
                FullName = "Білодід Михайло Олександрович",

                BirthDate = DateTime.Now,

                Gender = "чоловіча",

                PhoneNumber = "+380995326869",

                Specialization = "серцеві захворювання",
            };

            var doctor2 = new Doctor
            {
                FullName = "Зайцев Віктор Іванович",

                BirthDate = DateTime.Now,

                Gender = "чоловіча",

                PhoneNumber = "+380995384769",

                Specialization = "дихальні захворювання",
            };

            var doctor3 = new Doctor
            {
                FullName = "Болтов Олег Олександрович",

                BirthDate = DateTime.Now,

                Gender = "чоловіча",

                PhoneNumber = "+380989526869",

                Specialization = "шкірні захворювання",
            };

            var vocherDoctor1 = new VoucherDoctor { Voucher = voucher1, Doctor = doctor1 };
            var vocherDoctor2 = new VoucherDoctor { Voucher = voucher2, Doctor = doctor2 };
            var vocherDoctor3 = new VoucherDoctor { Voucher = voucher3, Doctor = doctor3 };

            voucher1.VoucherDoctors = new List<VoucherDoctor> { vocherDoctor1 };
            voucher2.VoucherDoctors = new List<VoucherDoctor> { vocherDoctor2 };
            voucher3.VoucherDoctors = new List<VoucherDoctor> { vocherDoctor3 };

            var illness1 = new Illness
            {
                Name = "інфаркт",
                Type = "серцеві захворювання"
            };

            var illness2 = new Illness
            {
                Name = "туберкулез",
                Type = "дихальні захворювання"
            };

            var illness3 = new Illness
            {
                Name = "алергія",
                Type = "шкірні захворювання"
            };

            var voucherIllness1 = new VoucherIllness { Voucher = voucher1, Illness = illness1, IllnessGrade = 1 };
            var voucherIllness2 = new VoucherIllness { Voucher = voucher2, Illness = illness2, IllnessGrade = 3 };
            var voucherIllness3 = new VoucherIllness { Voucher = voucher3, Illness = illness3, IllnessGrade = 1 };

            voucher1.VoucherIllnesses = new List<VoucherIllness> { voucherIllness1 };
            voucher2.VoucherIllnesses = new List<VoucherIllness> { voucherIllness2 };
            voucher3.VoucherIllnesses = new List<VoucherIllness> { voucherIllness3 };

            var reciept1 = new Reciept
            {
                CreateDate = DateTime.Now,
                Sum = 2000,
                Type = "паперова",
                Voucher = voucher1
            };

            var reciept2 = new Reciept
            {
                CreateDate = DateTime.Now,
                Sum = 5000,
                Type = "паперова",
                Voucher = voucher2
            };

            var reciept3 = new Reciept
            {
                CreateDate = DateTime.Now,
                Sum = 1000,
                Type = "електронна",
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
