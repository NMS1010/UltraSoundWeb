using System.ComponentModel.DataAnnotations;

namespace UltraSoundWeb.Entities
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
