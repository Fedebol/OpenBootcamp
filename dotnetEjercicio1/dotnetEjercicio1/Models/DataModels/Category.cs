using System.ComponentModel.DataAnnotations;

namespace dotnetEjercicio1.Models.DataModels
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public ICollection<Course> Cursos { get; set; }= new List <Course>();

    }
}
