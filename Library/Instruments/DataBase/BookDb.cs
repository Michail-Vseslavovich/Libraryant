using Library.Instruments.Dto;
using Microsoft.EntityFrameworkCore;

namespace Library.Instruments.DataBase
{
    public class BookDb : DbContext
    {
        public DbSet<BookDTO> UnmoderatedBooks { get; set; }
        public DbSet<BookDTO> SaveToReedBooks { get; set; }

        public BookDb()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=usersdb;Username=postgres;Password=здесь_указывается_пароль_от_postgres");
        }
    }
}
