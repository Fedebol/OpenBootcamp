using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DataModels
{
    public class Contenido: BaseEntity
    {
        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; } = new Curso();
        public ICollection<User> Users { get; set; } = new List<User>();
        [Required]
        public string List = string.Empty;
    }
}
