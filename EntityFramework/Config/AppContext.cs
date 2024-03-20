using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EntityFramework
{
    public class AppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<UserEntity> Users { get; set; }

        // Объекты таблицы Books
        public DbSet<BookEntity> Books { get; set; }


        // Объекты таблицы Companies
        public DbSet<CompanyEntity> Companies { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=NIK\SQLEXPRESS;Database=EF;Trusted_Connection=True;");
        }
    }
}