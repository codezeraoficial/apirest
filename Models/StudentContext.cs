using Microsoft.EntityFrameworkCore;

namespace apirest.Models
{
    public class StudentContext: DbContext
    {
        public StudentContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
    }
}