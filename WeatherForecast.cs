<<<<<<< HEAD
using System;

namespace loginclaro
{
	internal class WeatherForecast
	{
		public DateOnly Date { get; set; }

		public Int32 TemperatureC { get; set; }

		public Int32 TemperatureF => 32 + (Int32)(TemperatureC / 0.5556);

		public String? Summary { get; set; }
	}
=======
namespace loginclaro
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
>>>>>>> 5894c4cea8ca4aa51c09059a9684795f2d95a8f2
}
