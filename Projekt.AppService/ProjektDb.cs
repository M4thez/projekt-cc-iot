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
    public DbSet<ControlTemp> ControlTemps { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      var measurementEntity = modelBuilder.Entity<Measurement>();
      measurementEntity.ToTable("Measurements");
      measurementEntity.Property(m => m.TemperatureC).IsRequired();
      measurementEntity.Property(m => m.Humidity).IsRequired();
      measurementEntity.Property(m => m.DateMeasured).IsRequired().HasMaxLength(128);

      var controlTempEntity = modelBuilder.Entity<ControlTemp>();
      controlTempEntity.ToTable("ControlTemps");
      controlTempEntity.Property(m => m.ControlTemperature).IsRequired();
    }
  }
}