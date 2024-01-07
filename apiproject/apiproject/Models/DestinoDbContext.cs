using apiproject.Models;
using Microsoft.EntityFrameworkCore;
namespace apiproject.Models
{
    public class DestinoDbContext : DbContext
    {

        public DestinoDbContext(DbContextOptions<DestinoDbContext> options) : base(options)
        { }

       
        public DbSet<Destinos> Destinos { get; set; }

    }
}
