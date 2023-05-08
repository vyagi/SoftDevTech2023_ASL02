using Newtonsoft.Json.Linq;

namespace AdapterPattern
{
    public class Detector
    {
        private readonly IThermometer _thermometer;

        public Detector(IThermometer thermometer) => _thermometer = thermometer;

        public Decision Detect() =>
            _thermometer.GetTemperature() switch
            {
                < 18 => Decision.TooCold,
                < 25 => Decision.JustRight,
                _ => Decision.TooHot
            };

        public enum Decision
        {
            TooCold,
            JustRight,
            TooHot
        }
    }

    //The clue of this example:

    public class InternetThermometerAdapter : IThermometer
    {
        private readonly InternetThermometer _thermometer;

        public InternetThermometerAdapter(InternetThermometer thermometer) => _thermometer = thermometer;

        public double GetTemperature() => 
            double.Parse(_thermometer.Themperature.Replace(".",",")) - 273.15;
    }


    //3rd party library - e.g. nuget library

    public class InternetThermometer
    {
        private static readonly HttpClient Client = new();

        public InternetThermometer() => Client.BaseAddress = new Uri("http://api.openweathermap.org/");

        public string Themperature =>
            ((dynamic)JObject.Parse(Client
                .GetAsync("data/2.5/weather?q=Rzeszow&appid=cad76f95258d484b8b7ef48ac4695f8c")
                .Result.Content.ReadAsStringAsync()
                .Result))["main"]["temp"];
    }

    public class MercuryThermometer : IThermometer
    {
        public static readonly Random Random = new();

        public double GetTemperature() => Random.NextDouble() * 40 - 5;
    }

    public interface IThermometer
    {
        double GetTemperature();
    }
}