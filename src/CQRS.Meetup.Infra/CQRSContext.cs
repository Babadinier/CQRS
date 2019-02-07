using CQRS.Meetup.Write.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Meetup.Infra
{
    public class CQRSContext : DbContext
    {
        public CQRSContext(DbContextOptions<CQRSContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
