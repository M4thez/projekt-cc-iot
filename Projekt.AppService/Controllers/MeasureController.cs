using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.AppService.Models;

namespace Projekt.AppService.Controllers;

[ApiController]
[Route("api/measurement")]
public class MeasureController : ControllerBase
{
  private readonly ProjektDb db;

  public MeasureController(ProjektDb db)
  {
    this.db = db;
  }

  [HttpGet]
  public async Task<ActionResult> GetAll()
  {
    return Ok(await db.Measurements.ToListAsync());
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Measurement>> GetMeasurement(int id)
  {
    var measurement = await db.Measurements.FindAsync(id);

    if (measurement == null)
    {
      return NotFound();
    }
    return measurement;
  }

  [HttpPost]
  public async Task<ActionResult<Measurement>> PostMeasurement(Measurement measurement)
  {
    db.Measurements.Add(measurement);
    await db.SaveChangesAsync();

    return CreatedAtAction(nameof(GetMeasurement), new { id = measurement.Id }, measurement);
  }
}
