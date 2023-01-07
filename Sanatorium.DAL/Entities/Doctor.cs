namespace Sanatorium.DAL.Entities
{
    public class Doctor : EntityBase
    {
        public string FullName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Specialization { get; set; }

        public List<VoucherDoctor> VoucherDoctors { get; set; }
    }
}
