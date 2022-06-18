using Projekt.AppService.Models;
using Microsoft.EntityFrameworkCore;

namespace Projekt.AppService
{
  public class ProjektDb : DbContext
  {
    public ProjektDb(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Measurement> Measurements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      var measurementEntity = modelBuilder.Entity<Measurement>();
      measurementEntity.ToTable("Measurements");
      measurementEntity.Property(m => m.TemperatureC).IsRequired();
      measurementEntity.Property(m => m.Humidity).IsRequired();
    }
  }
}