using CQRS.Meetup.Write.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Meetup.Infra
{
    //todo gub : change name project ? (like infra)
    public class CQRSContext : DbContext
    {
        private const string connectionString = "Server=localhost;Database=CQRS;Trusted_Connection=True;";

        public CQRSContext() : base(){}

        public CQRSContext(DbContextOptions<CQRSContext> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
