using System.ComponentModel.DataAnnotations;

namespace Sanatorium.DAL.Entities
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
