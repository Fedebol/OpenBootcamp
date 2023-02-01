using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DataModels
{
    public class User: BaseEntity
    {
        [Required, StringLength(50)]
        public string UserName { get; set; } = string.Empty;
        [Required, StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;

        public ICollection<Curso> Cursos { get; set; } = new List<Curso>();
        public ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
        public ICollection<Contenido> Contenidos { get; set; } = new List<Contenido>();
        public ICollection<Categoria> Categorias { get; set; } = new List<Categoria>();
    }
}
