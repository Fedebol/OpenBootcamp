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

    }
}
