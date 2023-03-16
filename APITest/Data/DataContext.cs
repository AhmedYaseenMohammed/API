using Microsoft.EntityFrameworkCore;

namespace APITest.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<UploadFile> UploadFile { get; set; }

    }
}
