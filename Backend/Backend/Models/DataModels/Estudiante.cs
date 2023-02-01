using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DataModels
{
    public class Estudiante: BaseEntity
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public DateTime DOB { get; set; }

        public ICollection<Curso> Cursos { get; set; } = new List<Curso>();
        public ICollection<User> Users { get; set; } = new List<User>();

    }
}
