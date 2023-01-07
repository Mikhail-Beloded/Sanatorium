using Sanatorium.DAL.Entities;

namespace Sanatorium.BLL.DTOs
{
    public class PatientDto : DtoBase
    {
        public string FullName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string RegistrationDate { get; set; }

        public string VacineList { get; set; }

        public string WorkPlace { get; set; }

        public List<VoucherDto> Vouchers { get; set; }
    }
}
