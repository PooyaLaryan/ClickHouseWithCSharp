using ClickHouseWithCSharp.Model.MapConfig;
using CS.Report.Grains.Data.Domains;
using Microsoft.EntityFrameworkCore;

namespace ClickHouseWithCSharp
{
    public class AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : DbContext(dbContextOptions)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new FleetEventMapper());            
        }

        public DbSet<FleetEvent> FleetEvents {  get; set; }
    }
}
