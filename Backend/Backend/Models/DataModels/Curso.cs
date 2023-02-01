using System.ComponentModel.DataAnnotations;


namespace Backend.Models.DataModels
{

    public enum Nivel
    {
        Basico,
        Intermedio,
        Avanzado
    }

    public class Curso : BaseEntity
    {
        [Required, StringLength(50)]
        public string Nombre { get; set; } = string.Empty;
        [Required, StringLength(280)]
        public string DescripcionCorta { get; set; } = string.Empty;
        [Required]
        public string DescripcionLarga { get; set; } = string.Empty;
        [Required]
        public string PublicoObjetivo { get; set; } = string.Empty;
        [Required]
        public string Objetivos { get; set; } = string.Empty;
        [Required]
        public string Requisitos { get; set; } = string.Empty;
        [Required]
        public Nivel Nivel { get; set; } = Nivel.Basico;

        [Required]
        public ICollection<Categoria> Categorias { get; set; } = new List<Categoria>();

        [Required]
        public Contenido Contenido { get; set; } = new Contenido();

        [Required]
        public ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();

    }
}
