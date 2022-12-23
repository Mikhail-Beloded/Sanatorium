namespace Sanatorium.DAL.Entities
{
    public class RoomPatient
    {
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        public int RoomId { get; set; }

        public Room Room { get; set; }
    }
}
