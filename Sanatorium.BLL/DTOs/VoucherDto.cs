namespace Sanatorium.BLL.DTOs
{
    public class VoucherDto : DtoBase
    {
        public DateTime CreationDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int PatientId { get; set; }

        public RecieptDto Reciept { get; set; }

        public List<VoucherDoctorDto> VoucherDoctors { get; set; }

        public List<VoucherRoomDto> VoucherRooms { get; set; }

        public List<VoucherProcedureDto> VoucherProcedures { get; set; }

        public List<VoucherIllnessDto> VoucherIllnesses { get; set; }
    }
}
