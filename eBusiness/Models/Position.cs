using System.ComponentModel.DataAnnotations;

namespace eBusiness.Models
{
    public class Position
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:30)]
        public string Name { get; set; }
        public List<Team>? Teams { get; set; }
    }
}
