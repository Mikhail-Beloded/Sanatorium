namespace Sanatorium.DAL.Entities
{
    public class IllnessPatient
    {
        public int IllnessId { get; set; }

        public Illness Illness { get; set; }

        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        public int IllnessDegree { get; set; }
    }
}
