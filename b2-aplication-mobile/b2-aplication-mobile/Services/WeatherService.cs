using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using b2_aplication_mobile.Models;
using b2_aplication_mobile.Services;

namespace App1.Service
{
    class WeatherService
    {
        const string key = "3d13d25c0c34fa3c3db183ad6b8cdff4";
        const string url = "http://api.openweathermap.org/data/2.5/weather";
        public static async Task<Weather> GetWeather(string zipCode)
        {
            string queryString = $"{url}?zip={zipCode},fr&appid={key}&units=metric";
            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if (results["weather"] != null)
            {
                Weather weather = new Weather();
                weather.Title = results["name"];
                weather.Temperature = results["main"]["temp"] + "°C";
                weather.Wind = results["Wind"]["Speed"] + "km/h";
                weather.Humidity = results["main"]["humidity"] + "%";
                weather.Visibility = results["visibility"];

                DateTime time = new DateTime(1970, 1, 1, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);

                weather.Sunrise = sunrise.ToString("HH:mm:ss") + " UTC";
                weather.Sunrise = sunset.ToString("HH:mm:ss") + " UTC";

                return weather;
            }
            return null;
        }
    }
}
