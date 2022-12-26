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

            var patient1 = new Patient
            {
                FullName = "Test",

                BirthDate = DateTime.Now,

                Gender = "male",

                Address = "Kharkiv",

                PhoneNumber= "12345",

                Email = "smth@gmail.com",

                RegistrationDate = DateTime.Now,

                VacineList = "afsdfsafd",

                WorkPlace = "Kharkiv",
            };

            var patient2 = new Patient
            {
                FullName = "Test2",

                BirthDate = DateTime.Now,

                Gender = "male",

                Address = "Kharkiv",

                PhoneNumber = "12345",

                Email = "smth@gmail.com",

                RegistrationDate = DateTime.Now,

                VacineList = "afsdfsafd",

                WorkPlace = "Kharkiv",
            };

            var patient3 = new Patient
            {
                FullName = "Test3",

                BirthDate = DateTime.Now,

                Gender = "male",

                Address = "Kharkiv",

                PhoneNumber = "12345",

                Email = "smth@gmail.com",

                RegistrationDate = DateTime.Now,

                VacineList = "afsdfsafd",

                WorkPlace = "Kharkiv",
            };

            var patientroom1 = new RoomPatient
            {
                Room = room1,
                Patient = patient1,
            };

            var patientroom2 = new RoomPatient
            {
                Room = room1,
                Patient = patient2,
            };

            var patientroom3 = new RoomPatient
            {
                Room = room2,
                Patient = patient3,
            };

            db.Rooms.AddRange(room1, room2);

            patient1.RoomPatient = new List<RoomPatient> { patientroom1 };
            patient2.RoomPatient = new List<RoomPatient> { patientroom2 };
            patient3.RoomPatient = new List<RoomPatient> { patientroom3 };

            db.Patients.AddRange(patient1, patient2, patient3); 
            db.SaveChanges();
        }
    }
}
