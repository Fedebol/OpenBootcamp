using System.ComponentModel.DataAnnotations;

namespace dotnetEjercicio1.Models.DataModels
{
    public class Chapter : BaseEntity
    {
        public int CursoId { get; set; }
        public virtual Course Curso { get; set; } = new Course();

        [Required]
        public string List = string.Empty;
    }
}
