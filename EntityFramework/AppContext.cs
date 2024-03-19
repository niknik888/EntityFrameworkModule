using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework
{
    public class AppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<UserEntity> Users { get; set; }

        // Объекты таблицы Users
        public DbSet<BookEntity> Books { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=NIK\SQLEXPRESS;Database=EF;Trusted_Connection=True;");
        }
    }
}