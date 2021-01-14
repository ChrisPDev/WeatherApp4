using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading;

namespace WeatherApp4
{
    public partial class MainPage : ContentPage
    {
        private string Location { get; set; } = "Hjørring";
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        const string APPID = "542ffd081e67f4512b705f89d2a611b2";

        WeatherForcast forecast1 = new WeatherForcast
        {
            name = "",
            dt = "",
            dt2 = "",
            main = "",
            description = "",
            day = "",
            speed = "",
            pressure = "",
            humidity = "",
            icon = ""
        };

        WeatherForcast forecast2 = new WeatherForcast
        {
            name = "",
            dt = "",
            day = "",
            speed = "",
            icon = ""
        };

        WeatherForcast forecast3 = new WeatherForcast
        {
            name = "",
            dt = "",
            day = "",
            speed = "",
            icon = ""
        };

        WeatherForcast forecast4 = new WeatherForcast
        {
            name = "",
            dt = "",
            day = "",
            speed = "",
            icon = ""
        };

        WeatherForcast forecast5 = new WeatherForcast
        {
            name = "",
            dt = "",
            day = "",
            speed = "",
            icon = ""
        };

        public MainPage()
        {
            InitializeComponent();
            dataBind();
            GetCoordinates();
        }

        private void GetWeatherForecast(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_search.Text))
            {
                DateTime dates = DateTime.UtcNow;
                string search = tb_search.Text;
                int day = 5;
                string url = $"http://api.openweathermap.org/data/2.5/forecast/daily?q={search}&units=metric&cnt={day}&APPID={APPID}";

                using (WebClient web = new WebClient())
                {
                    var json = web.DownloadString(url);
                    var Object = JsonConvert.DeserializeObject<WeatherForcast>(json);
                    WeatherForcast forcast = Object;
                    var iconCode1 = $"{forcast.list[0].weather[0].icon}";
                    var iconCode2 = $"{forcast.list[1].weather[0].icon}";
                    var iconCode3 = $"{forcast.list[2].weather[0].icon}";
                    var iconCode4 = $"{forcast.list[3].weather[0].icon}";
                    var iconCode5 = $"{forcast.list[4].weather[0].icon}";
                    var iconUrl1 = $"http://openweathermap.org/img/w/{iconCode1}.png";
                    var iconUrl2 = $"http://openweathermap.org/img/w/{iconCode2}.png";
                    var iconUrl3 = $"http://openweathermap.org/img/w/{iconCode3}.png";
                    var iconUrl4 = $"http://openweathermap.org/img/w/{iconCode4}.png";
                    var iconUrl5 = $"http://openweathermap.org/img/w/{iconCode5}.png";
                    forecast1.icon = iconUrl1;
                    forecast2.icon = iconUrl2;
                    forecast3.icon = iconUrl3;
                    forecast4.icon = iconUrl4;
                    forecast5.icon = iconUrl5;

                    // Day 1
                    forecast1.dt2 = $"Date & time: { dates.AddSeconds(3600) }";
                    forecast1.dt = $"Weekday: { getDate(forcast.list[0].dt).DayOfWeek }";
                    forecast1.name = $"City: { forcast.city.name }";
                    forecast1.day = $"Temperature: { forcast.list[0].temp.day }\u00B0";
                    forecast1.speed = $"Wind: { forcast.list[0].speed }km/h";
                    forecast1.pressure = $"Pressure: { forcast.list[0].pressure }";
                    forecast1.humidity = $"Humidity: { forcast.list[0].humidity }%";

                    // Day 2
                    forecast2.name = $"City: { forcast.city.name }";
                    forecast2.dt = $"Weekday: { getDate(forcast.list[1].dt).DayOfWeek }";
                    forecast2.day = $"Temperature: { forcast.list[1].temp.day }\u00B0";
                    forecast2.speed = $"Wind: { forcast.list[1].speed }km/h";

                    // Day 3
                    forecast3.name = $"City: { forcast.city.name }";
                    forecast3.dt = $"Weekday: { getDate(forcast.list[2].dt).DayOfWeek }";
                    forecast3.day = $"Temperature: { forcast.list[2].temp.day }\u00B0";
                    forecast3.speed = $"Wind: { forcast.list[2].speed }km/h";

                    // Day 4
                    forecast4.name = $"City: { forcast.city.name }";
                    forecast4.dt = $"Weekday: { getDate(forcast.list[3].dt).DayOfWeek }";
                    forecast4.day = $"Temperature: { forcast.list[3].temp.day }\u00B0";
                    forecast4.speed = $"Wind: { forcast.list[3].speed }km/h";

                    // Day 5
                    forecast5.name = $"City: { forcast.city.name }";
                    forecast5.dt = $"Weekday: { getDate(forcast.list[4].dt).DayOfWeek }";
                    forecast5.day = $"Temperature: { forcast.list[4].temp.day }\u00B0";
                    forecast5.speed = $"Wind: { forcast.list[4].speed }km/h";
                }
                tb_search.Text = "";
            }
        }

        public void getForecast()
        {
            DateTime dates = DateTime.UtcNow;
            int day = 5;
            string url = $"http://api.openweathermap.org/data/2.5/forecast/daily?q={Location}&units=metric&cnt={day}&APPID={APPID}";

            using (WebClient web = new WebClient())
            {
                var json = web.DownloadString(url);
                var Object = JsonConvert.DeserializeObject<WeatherForcast>(json);
                WeatherForcast forcast = Object;
                var iconCode1 = $"{forcast.list[0].weather[0].icon}";
                var iconCode2 = $"{forcast.list[1].weather[0].icon}";
                var iconCode3 = $"{forcast.list[2].weather[0].icon}";
                var iconCode4 = $"{forcast.list[3].weather[0].icon}";
                var iconCode5 = $"{forcast.list[4].weather[0].icon}";
                var iconUrl1 = $"http://openweathermap.org/img/w/{iconCode1}.png";
                var iconUrl2 = $"http://openweathermap.org/img/w/{iconCode2}.png";
                var iconUrl3 = $"http://openweathermap.org/img/w/{iconCode3}.png";
                var iconUrl4 = $"http://openweathermap.org/img/w/{iconCode4}.png";
                var iconUrl5 = $"http://openweathermap.org/img/w/{iconCode5}.png";
                forecast1.icon = iconUrl1;
                forecast2.icon = iconUrl2;
                forecast3.icon = iconUrl3;
                forecast4.icon = iconUrl4;
                forecast5.icon = iconUrl5;

                // Day 1
                forecast1.dt2 = $"Date & time: { dates.AddSeconds(3600) }";
                forecast1.dt = $"Weekday: { getDate(forcast.list[0].dt).DayOfWeek }";
                forecast1.name = $"City: { forcast.city.name }";
                forecast1.day = $"Temperature: { forcast.list[0].temp.day }\u00B0";
                forecast1.speed = $"Wind: { forcast.list[0].speed }km/h";
                forecast1.pressure = $"Pressure: { forcast.list[0].pressure }";
                forecast1.humidity = $"Humidity: { forcast.list[0].humidity }%";

                // Day 2
                forecast2.name = $"City: { forcast.city.name }";
                forecast2.dt = $"Weekday: { getDate(forcast.list[1].dt).DayOfWeek }";
                forecast2.day = $"Temperature: { forcast.list[1].temp.day }\u00B0";
                forecast2.speed = $"Wind: { forcast.list[1].speed }km/h";

                // Day 3
                forecast3.name = $"City: { forcast.city.name }";
                forecast3.dt = $"Weekday: { getDate(forcast.list[2].dt).DayOfWeek }";
                forecast3.day = $"Temperature: { forcast.list[2].temp.day }\u00B0";
                forecast3.speed = $"Wind: { forcast.list[2].speed }km/h";

                // Day 4
                forecast4.name = $"City: { forcast.city.name }";
                forecast4.dt = $"Weekday: { getDate(forcast.list[3].dt).DayOfWeek }";
                forecast4.day = $"Temperature: { forcast.list[3].temp.day }\u00B0";
                forecast4.speed = $"Wind: { forcast.list[3].speed }km/h";

                // Day 5
                forecast5.name = $"City: { forcast.city.name }";
                forecast5.dt = $"Weekday: { getDate(forcast.list[4].dt).DayOfWeek }";
                forecast5.day = $"Temperature: { forcast.list[4].temp.day }\u00B0";
                forecast5.speed = $"Wind: { forcast.list[4].speed }km/h";
            }
        }

        void dataBind()
        {
            lbl_date_1.BindingContext = forecast1;
            lbl_day_1.BindingContext = forecast1;
            lbl_city_1.BindingContext = forecast1;
            lbl_temp_1.BindingContext = forecast1;
            lbl_wind_1.BindingContext = forecast1;
            lbl_pressure_1.BindingContext = forecast1;
            lbl_humidity_1.BindingContext = forecast1;
            image1.BindingContext = forecast1;

            lbl_day_2.BindingContext = forecast2;
            lbl_city_2.BindingContext = forecast2;
            lbl_temp_2.BindingContext = forecast2;
            lbl_wind_2.BindingContext = forecast2;
            image2.BindingContext = forecast2;

            lbl_day_3.BindingContext = forecast3;
            lbl_city_3.BindingContext = forecast3;
            lbl_temp_3.BindingContext = forecast3;
            lbl_wind_3.BindingContext = forecast3;
            image3.BindingContext = forecast3;

            lbl_day_4.BindingContext = forecast4;
            lbl_city_4.BindingContext = forecast4;
            lbl_temp_4.BindingContext = forecast4;
            lbl_wind_4.BindingContext = forecast4;
            image4.BindingContext = forecast4;

            lbl_day_5.BindingContext = forecast5;
            lbl_city_5.BindingContext = forecast5;
            lbl_temp_5.BindingContext = forecast5;
            lbl_wind_5.BindingContext = forecast5;
            image5.BindingContext = forecast5;
        }

        DateTime getDate(double millisecond)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local).ToLocalTime();
            day = day.AddSeconds(millisecond).ToLocalTime();
            return day;
        }

        private async void GetCoordinates()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    Latitude = location.Latitude;
                    Longitude = location.Longitude;
                    Location = await GetCity(location);

                    getForecast();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private async Task<string> GetCity(Location location)
        {
            var places = await Geocoding.GetPlacemarksAsync(location);
            var currentPlace = places?.FirstOrDefault();

            if (currentPlace != null)
            {
                return $"{currentPlace.Locality}, {currentPlace.CountryName}";
            }

            return null;
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height); //must be called
        }
    }
}
