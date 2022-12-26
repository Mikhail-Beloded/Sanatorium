namespace Sanatorium.BLL.DTOs
{
    public class DoctorDto : DtoBase
    {
        public string FullName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public string PhoneNumver { get; set; }

        public string Specialization { get; set; }
    }
}
