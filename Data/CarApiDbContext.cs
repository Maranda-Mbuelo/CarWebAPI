using CarWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWebAPI.Data
{
    public class CarApiDbContext : DbContext
    {
        public CarApiDbContext(DbContextOptions options) : base(options)
        {
        }

        //Db Set Like a table inside SQL Serve!

        public DbSet<CarProperties> Cars { get; set; }
    }
}
