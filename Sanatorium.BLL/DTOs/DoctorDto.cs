using Sanatorium.DAL.Entities;

namespace Sanatorium.BLL.DTOs
{
    public class DoctorDto : DtoBase
    {
        public string FullName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Specialization { get; set; }

        public List<VoucherDoctor> VoucherDoctors { get; set; }
    }
}
