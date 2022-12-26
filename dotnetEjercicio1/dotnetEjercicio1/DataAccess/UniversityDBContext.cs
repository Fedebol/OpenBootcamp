using Microsoft.EntityFrameworkCore;

namespace dotnetEjercicio1.DataAccess
{
    public class UniversityDBContext: DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options): base(options)
        {

        }

        // TODO: Add DbSets (tables of our Data base)
    }
}
