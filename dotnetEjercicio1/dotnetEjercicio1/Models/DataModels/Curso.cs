using System.ComponentModel.DataAnnotations;

namespace dotnetEjercicio1.Models.DataModels
{
    public class Curso : BaseEntity
    {
        private const int V = 280;

        [Required, StringLength(maximumLength:50)]
        public string CursoName { get; set; } = string.Empty;
        [Required, StringLength(maximumLength: 280)]
        public string DespShort { get; set; } = string.Empty;
        [Required, StringLength(500, MinimumLength= 280)]
        public string DespLong { get; set; } = string.Empty;
        [Required]
        public string PubObjet { get; set; } = string.Empty;
        [Required]
        public string Objetivos { get; set; } = string.Empty;
        [Required]
        public string Requisitos { get; set; } = string.Empty;
         
        public enum Nivel
        {
            Basico,
            Intermedio,
            Avanzado
        }

    }
}
