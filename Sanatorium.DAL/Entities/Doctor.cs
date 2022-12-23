namespace Sanatorium.DAL.Entities
{
    public class Doctor : EntityBase
    {
        public string FullName { get; set; }

        public DateOnly BirthDate { get; set; }

        public string Gender { get; set; }

        public string PhoneNumver { get; set; }

        public string Specialization { get; set; }

        public List<DoctorPatient> DoctorPatient { get; set; }
    }
}
