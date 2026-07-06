using Microsoft.EntityFrameworkCore;
using thoth_api.Domain;

namespace thoth_api.Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Profile> Profiles { get; set; }
    }
}
