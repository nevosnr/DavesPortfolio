using System.ComponentModel.DataAnnotations;

namespace DavesPortfolio.Models
{
    public class CareerRecord
    {
        public Guid Id { get; set; }

        public string? careerIcon { get; set; }

        [Required]
        [MaxLength(150)]
        public string careerJobTitle { get; set; }

        [Required]
        [MaxLength(150)]
        public string careerRoleTitle { get; set; }

        [MaxLength(150)]
        public string? careerShortDescription { get; set; }

        [Required]
        public string? careerLongDescription { get; set; }

        [Required]
        public DateTime careerStateDate { get; set; }
        public DateTime? careerEndDate { get; set; }
    }
}