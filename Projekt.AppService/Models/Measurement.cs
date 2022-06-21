namespace Projekt.AppService.Models
{
  public class Measurement
  {
    public int Id { get; set; }

    public float TemperatureC { get; set; }

    public float Humidity { get; set; }
    public string DateMeasured { get; set; }

    // Add DateAdded maybe
  }
}