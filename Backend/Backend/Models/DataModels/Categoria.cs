using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DataModels
{
    public class Categoria : BaseEntity
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Curso> Cursos { get; set; } = new List<Curso>();
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
