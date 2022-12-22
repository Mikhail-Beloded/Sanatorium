namespace Sanatorium.DAL.Entities
{
    public class DoctorPatient : EntityBase
    {
        public Doctor Doctor { get; set; }
        
        public Patient Patient { get; set; }
    }
}
