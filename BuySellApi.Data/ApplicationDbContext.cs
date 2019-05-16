using BuySellApi.Core;
using Microsoft.EntityFrameworkCore;

namespace BuySellApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Advertisement> Advertisements { get; set; }
    }
}
