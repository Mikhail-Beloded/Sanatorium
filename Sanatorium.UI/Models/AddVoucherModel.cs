using Sanatorium.BLL.DTOs;

namespace Sanatorium.UI.Models
{
    public class AddVoucherModel
    {
        public DateTime CreationDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int PatientId { get; set; }

        public int RoomId { get; set; }

        public int DayCount { get; set; }

        public int IllnessId { get; set; }

        public int IllnessGrade { get; set; }

        public RecieptDto Reciept { get; set; }

        public List<VoucherRoomDto> VoucherRooms { get; set; }

        public List<VoucherProcedureDto> VoucherProcedures { get; set; }
    }
}
