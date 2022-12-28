using System.ComponentModel.DataAnnotations;

namespace dotnetEjercicio1.Models.DataModels
{
    public enum Nivel
    {
        Basico,
        Intermedio,
        Avanzado
    }

    public class Course : BaseEntity
    {
        
        [Required, StringLength(50)]
        public string CursoName { get; set; } = string.Empty;
        [Required, StringLength(280)]
        public string DespShort { get; set; } = string.Empty;
        [Required]
        public string DespLong { get; set; } = string.Empty;
        [Required]
        public string PubObjet { get; set; } = string.Empty;
        [Required]
        public string Objetivos { get; set; } = string.Empty;
        [Required]
        public string Requisitos { get; set; } = string.Empty;

        public Nivel Nivel { get; set; } = Nivel.Basico;

        [Required]
        public ICollection<Category> Categorias { get; set; } = new List<Category>();

        [Required]
        public Chapter Chapters { get; set; } = new Chapter();

        [Required]
        public ICollection<Student> Students { get; set; } = new List<Student>();

    }
}
