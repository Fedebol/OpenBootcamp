using dotnetEjercicio1.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace dotnetEjercicio1.DataAccess
{
    public class UniversityDBContext: DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options): base(options)
        {

        }

        // Add DbSets (tables of our Data base)

        public DbSet<User>? Users { get; set; }
        public DbSet<Course>? Cursos { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Chapter>? Chapters { get; set; }

    }
}
