namespace Sanatorium.DAL.Entities
{
    public class IllnessPatient
    {
        public Illness Illness { get; set; }

        public Patient Patient { get; set; }

        public int IllnessDegree { get; set; }
    }
}
