using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Domain.Models
{
    public class Notes
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
