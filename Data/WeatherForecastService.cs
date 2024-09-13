namespace myorange_pmproject.Data;
using Microsoft.EntityFrameworkCore;

public class WeatherForecastService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

   private readonly PizzaStoreContext _db;

    public WeatherForecastService(PizzaStoreContext db)
    {
        _db = db;
    }


    public Task<WeatherForecast[]> GetForecastAsync(DateOnly startDate)
    {
        return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = startDate.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray());
    }

    public async Task<List<PizzaSpecial>> GetSpecials()
    {
        return (await _db.Specials.ToListAsync()).OrderByDescending(s => s.BasePrice).ToList();
    }
}
