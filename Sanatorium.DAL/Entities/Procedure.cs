namespace Sanatorium.DAL.Entities
{
    public class Procedure : EntityBase
    {
        public string Name { get; set; }

        public int SessionPrice { get; set; }

        public TimeOnly SessionTime { get; set; }
    }
}
