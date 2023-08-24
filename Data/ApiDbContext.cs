using Microsoft.EntityFrameworkCore;


namespace ioLabsApi.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<ApiCall> ApiCalls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=apiCalls.db");
        }
    }
}
