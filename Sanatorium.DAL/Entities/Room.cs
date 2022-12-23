namespace Sanatorium.DAL.Entities
{
    public class Room : EntityBase
    {
        public double Price { get; set; }

        public int Capacity { get; set; }

        public List<RoomPatient> RoomPatient { get; set; }
    }
}
