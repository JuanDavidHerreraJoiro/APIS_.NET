using System.ComponentModel.DataAnnotations;

namespace universityApiBackend.Models.DataModels
{
    public class Category:BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<Course> courses { get; set; } = new List<Course>();

    }
}
