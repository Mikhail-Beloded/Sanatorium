namespace Sanatorium.BLL.DTOs
{
    public class PatientDto
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

        public List<IllnessPatientDto> IllnessPatient { get; set; }
    }
}
