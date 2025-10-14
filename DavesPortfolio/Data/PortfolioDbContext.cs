using Microsoft.EntityFrameworkCore;
using DavesPortfolio.Models;

namespace DavesPortfolio.Data
{
    public partial class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Name=AzurePortfolio");
        public virtual DbSet<Models.CareerRecord> CareerRecords { get; set; }
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Models.CareerRecord>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.careerIcon).HasMaxLength(255);
                entity.Property(e => e.careerJobTitle).IsRequired().HasMaxLength(150);
                entity.Property(e => e.careerRoleTitle).IsRequired().HasMaxLength(150);
                entity.Property(e => e.careerShortDescription).HasMaxLength(150);
                entity.Property(e => e.careerLongDescription).IsRequired();
                entity.Property(e => e.careerStateDate).IsRequired();
                entity.Property(e => e.careerEndDate);
            });
            OnModelCreatingPartial(model);
        }
        partial void OnModelCreatingPartial(ModelBuilder model);
    }
}
