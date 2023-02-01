using Backend.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccess
{
    public class BackBDContext: DbContext
    {
        public BackBDContext(DbContextOptions<BackBDContext> options): base(options) 
        {
            
        }
        public DbSet<User>? Users { get; set; }
        public DbSet<Curso>? Cursos { get; set; }
        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Estudiante>? Estudiantes { get; set; }
        public DbSet<Contenido>? Contenidos { get; set; }


    }
}
