using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBusiness.Models
{
    public class Team
    {
        public int Id { get; set; }
        public int PositionId { get; set; }
       
        [StringLength(maximumLength: 90)]
        public string? ImageUrl { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string FullName { get; set; }
        
        [StringLength(maximumLength: 70)]
        public string? InstaUrl { get; set; }
        [StringLength(maximumLength: 70)]

        public string? FbUrl { get; set; }
        [StringLength(maximumLength: 70)]

        public string? TwitterUrl { get; set; }

        public Position? Position { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }

    }
}
