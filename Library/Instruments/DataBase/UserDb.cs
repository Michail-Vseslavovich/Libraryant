using Library.Instruments.Dto;
using Microsoft.EntityFrameworkCore;

namespace Library.Instruments.DataBase
{
    public class UserDb : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserDb()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=usersdb;Username=postgres;Password=здесь_указывается_пароль_от_postgres");
        }
    }
}
