namespace Sanatorium.BLL.DTOs
{
    public class VoucherDto : DtoBase
    {
        public DateTime CreationDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public int IllnessId { get; set; }

        public int IllnessDegree { get; set; }

        public PatientDto Patient { get; set; }

        public RecieptDto Reciept { get; set; }

        public DoctorDto Doctor { get; set; }

        public IllnessDto Illness { get; set; }

        public List<VoucherRoomDto> VoucherRooms { get; set; }

        public List<VoucherProcedureDto> VoucherProcedures { get; set; }
    }
}
