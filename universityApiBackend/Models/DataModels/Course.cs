using System.ComponentModel.DataAnnotations;

namespace universityApiBackend.Models.DataModels
{
    public class Course:BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required,StringLength(280)]
        public string ShortDescription { get; set; } = string.Empty;
        [Required]
        public string LongDescription { get; set; } = string.Empty;
        [Required]
        public string TargetAudiences { get; set; } = string.Empty;
        [Required]
        public string Goals { get; set; } = string.Empty;
        [Required]
        public string Requirement { get; set; } = string.Empty;
        [Required]
        public int Level { get; set; }
    }
}
