using System.ComponentModel.DataAnnotations;

namespace universityApiBackend.Models.DataModels
{
    public enum Level
    {
        Basic,
        Medium,
        Advanced,
        Expert
    }
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
        public Level Level { get; set; }

        public ICollection<Category> Categories { get; set; } = new List<Category>();

        public Chapters Chapters { get; set; } //= new Chapters(); 

        public ICollection<Student> Students { get; set; } = new List<Student>();


    }
}
