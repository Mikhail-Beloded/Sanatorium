namespace Sanatorium.DAL.Entities
{
    public class RoomPatient : EntityBase
    {
        public Patient Patient { get; set; }

        public Room Room { get; set; }
    }
}
