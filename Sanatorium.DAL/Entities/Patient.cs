namespace Sanatorium.DAL.Entities
{
    public class Patient : EntityBase
    {
        public string FullName { get; set; }

        public DateOnly BirthDate { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string VacineList { get; set; }

        public string WorkPlace { get; set; }
    }
}
