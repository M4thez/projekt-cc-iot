using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.AppService.Models;

namespace Projekt.AppService.Controllers;

[ApiController]
[Route("api")]
public class MeasureController : ControllerBase
{
  private readonly ProjektDb db;

  public MeasureController(ProjektDb db)
  {
    this.db = db;
  }

  [HttpGet("measurements")]
  public async Task<ActionResult> GetAll()
  {
    return Ok(await db.Measurements.ToListAsync());
  }

  [HttpGet("measurements/{id}")]
  public async Task<ActionResult<Measurement>> GetMeasurement(int id)
  {
    var measurement = await db.Measurements.FindAsync(id);

    if (measurement == null)
    {
      return NotFound();
    }
    return measurement;
  }

  [HttpGet("measurements/last")]
  public async Task<ActionResult<Measurement>> GetLast()
  {
    // var measurement = await db.Measurements.FindAsync(id);

    var lastMeasure = db.Measurements
                       .OrderByDescending(p => p.Id)
                       .FirstOrDefault();

    if (lastMeasure == null)
    {
      return NotFound();
    }
    return lastMeasure;
  }


  [HttpPost("measurements")]
  public async Task<ActionResult<Measurement>> PostMeasurement(Measurement measurement)
  {
    db.Measurements.Add(measurement);
    await db.SaveChangesAsync();

    return CreatedAtAction(nameof(GetMeasurement), new { id = measurement.Id }, measurement);
  }

  [HttpGet("control/last")]
  public async Task<ActionResult<ControlTemp>> GetControlTemp()
  {
    var lastControl = db.ControlTemps
                       .OrderByDescending(p => p.Id)
                       .FirstOrDefault();

    if (lastControl == null)
    {
      return NotFound();
    }
    return lastControl;
  }

  [HttpPost("control")]
  public async Task<ActionResult<ControlTemp>> PostControlTemp(ControlTemp controlTemp)
  {
    db.ControlTemps.Add(controlTemp);
    await db.SaveChangesAsync();

    return CreatedAtAction(nameof(GetControlTemp), new { id = controlTemp.Id }, controlTemp);
  }
}
